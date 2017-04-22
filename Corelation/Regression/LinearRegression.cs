using PrimaryStaticAnalysis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace CorelationAnalisys.Regression
{
    class LinearRegression
    {
        List<double> xData = new List<double>();
        List<double> yData = new List<double>();
        double alpha;

        public List<RegressionScore> Scores { get; private set; }

        private RegressionScore a0;
        private RegressionScore a1;

        public LinearRegression(List<double> _xData, List<double> _yData, double _alpha)
        {
            xData = _xData;
            yData = _yData;
            alpha = _alpha;
            CalculateScores();
        }

        public double Calculate(double x)
        {
            return a0.Value + a1.Value * x;
        }

        private void CalculateScores()
        {
            var xavg = StatCharacteristicModel.Average.GetAverage(xData);
            var yavg = StatCharacteristicModel.Average.GetAverage(yData);

            var xy = xData.Zip(yData, (x, y) => x * y).ToList();
            var xPow2 = xData.Select(x => x * x).ToList();

            var xyavg = StatCharacteristicModel.Average.GetAverage(xy);
            var xPow2avg = StatCharacteristicModel.Average.GetAverage(xPow2);

            var a1Value = (xyavg - xavg * yavg) / (xPow2avg - xavg * xavg);

            var a0Value = yavg - a1Value * xavg;
            var quantil = Quantiles.t_Student(1 - alpha / 2, xData.Count - 2);

            a0 = new RegressionScore()
            {
                Name = "a0",
                Value = a0Value,
                Quantil = quantil
            };

            a1 = new RegressionScore() { Name = "a1", Value = a1Value, Quantil = quantil };
            Scores = new List<RegressionScore> { a0, a1 };

            a0.Dispersion = GetDispA0();
            a0.Statistic = a0Value / Math.Sqrt(GetDispA0());
            a0.IntervalBelowBorder = GetBelowBorder(a0);
            a0.IntervalTopBorder = GetTopBorder(a0);

            a1.Dispersion = GetDispA1();
            a1.Statistic = a1Value / Math.Sqrt(GetDispA1());
            a1.IntervalBelowBorder = GetBelowBorder(a1);
            a1.IntervalTopBorder = GetTopBorder(a1);
        }

        private double GetDispA0()
        {
            var residuesDisp = ResiduesDisp();

            var xPow2Sum = xData.Sum(x => x*x);
            var Npow2 = xData.Count * xData.Count;
            var xDispersion = StatCharacteristicModel.StandartDeviationSkew.GetValue(xData);
            xDispersion *= xDispersion;

            return residuesDisp * xPow2Sum / (Npow2 * xDispersion);
        }

        private double GetDispA1()
        {
            var residuesDisp = ResiduesDisp();
            var N = xData.Count;
            var xDispersion = StatCharacteristicModel.StandartDeviationSkew.GetValue(xData);
            xDispersion *= xDispersion;

            return N * residuesDisp / (N * N * xDispersion);
        }

        private double GetBelowBorder(RegressionScore  score)
        {
            return score.Value - score.Quantil * Math.Sqrt(score.Dispersion);
        }

        private double GetTopBorder(RegressionScore score)
        {
            return score.Value + score.Quantil * Math.Sqrt(score.Dispersion);
        }

        // Sзал^2
        private double ResiduesDisp()
        {
            double sum = 0;
            for (int i = 0; i < yData.Count; i++)
            {
                sum += (yData[i] - Calculate(xData[i])) * (yData[i] - Calculate(xData[i]));
            }

            return sum / (xData.Count - Scores.Count);
        }
    }
}
