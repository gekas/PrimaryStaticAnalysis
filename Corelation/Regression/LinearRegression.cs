using CorelationAnalisys.BL;
using PrimaryStaticAnalysis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace CorelationAnalisys
{
    class LinearRegression : Regression
    {
        public override List<double> xData { get; protected set; }
        double xavg;
        public override List<double> yData { get; protected set; }
        public override double yavg { get; protected set; }
        public override int N => xData.Count;
        public override DetermCoef DeterminationCoef { get; }

        readonly double alpha;
        readonly double quantil;
        public double ResiduesDisp { get; private set; }

        public override List<RegressionScore> Scores { get; protected set; }

        private RegressionScore a0;
        private RegressionScore a1;

        public LinearRegression(List<double> _xData, List<double> _yData, double _alpha)
        {
            xData = _xData;
            yData = _yData;
            xavg = StatCharacteristicModel.Average.GetAverage(xData);
            yavg = StatCharacteristicModel.Average.GetAverage(yData);
            alpha = _alpha;
            quantil = Quantiles.t_Student(1 - alpha / 2, N - 2);
            
            CalculateScores();
            DeterminationCoef = new DetermCoef(this, alpha);
        }

        public override double Calculate(double x)
        {
            return a0.Value + a1.Value * x;
        }

        private void CalculateScores()
        {
            var xy = xData.Zip(yData, (x, y) => x * y).ToList();
            var xPow2 = xData.Select(x => x * x).ToList();

            var xyavg = StatCharacteristicModel.Average.GetAverage(xy);
            var xPow2avg = StatCharacteristicModel.Average.GetAverage(xPow2);

            var a1Value = (xyavg - xavg * yavg) / (xPow2avg - xavg * xavg);

            var a0Value = yavg - a1Value * xavg;
           

            a0 = new RegressionScore()
            {
                Name = "a0",
                Value = a0Value,
                Quantil = quantil
            };

            a1 = new RegressionScore() { Name = "a1", Value = a1Value, Quantil = quantil };
            Scores = new List<RegressionScore> { a0, a1 };
            ResiduesDisp = GetResiduesDisp();

            a0.Dispersion = GetDispA0();

            a1.Dispersion = GetDispA1();
            //a1.Statistic = a1Value / Math.Sqrt(GetDispA1());
        }

        private double GetDispA0()
        {
            var xPow2Sum = xData.Sum(x => x*x);
            var Npow2 = N*N;
            var xDispersion = StatCharacteristicModel.StandartDeviationSkew.GetValue(xData);
            xDispersion *= xDispersion;

            return ResiduesDisp * xPow2Sum / (Npow2 * xDispersion);
        }

        private double GetDispA1()
        {
            var xDispersion = StatCharacteristicModel.StandartDeviationSkew.GetValue(xData);
            xDispersion *= xDispersion;

            return N * ResiduesDisp / (N * N * xDispersion);
        }

        // Sзал^2
        private double GetResiduesDisp()
        {
            double sum = 0;
            for (int i = 0; i < yData.Count; i++)
            {
                sum += (yData[i] - Calculate(xData[i])) * (yData[i] - Calculate(xData[i]));
            }

            return sum / (N - Scores.Count);
        }

        public override double GetRegressionIntervalBelow(double x)
        {
            var dispersion = ResiduesDisp / N + a1.Dispersion * (x - xavg) * (x - xavg);

            return Calculate(x) - quantil * Math.Sqrt(dispersion);
        }

        public override double GetRegressionIntervalTop(double x)
        {
            var dispersion = ResiduesDisp / N + a1.Dispersion * (x - xavg) * (x - xavg);

            return Calculate(x) + quantil * Math.Sqrt(dispersion);
        }

        public override double GetPrognosisIntervalBelow(double x)
        {
            var dispersion = ResiduesDisp / N + a1.Dispersion * (x - xavg) * (x - xavg) + ResiduesDisp;

            return Calculate(x) - quantil * Math.Sqrt(dispersion);
        }

        public override double GetPrognosisIntervalTop(double x)
        {
            var dispersion = ResiduesDisp / N + a1.Dispersion * (x - xavg) * (x - xavg) + ResiduesDisp;

            return Calculate(x) + quantil * Math.Sqrt(dispersion);
        }
    }
}
