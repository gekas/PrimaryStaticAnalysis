using PrimaryStaticAnalysis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace CorelationAnalisys.BL
{   // sqrt(a+bx+cx^2)
    class ParabolicRegression : Regression
    {
        public override List<double> xData { get; protected set; }
        private double xavg;
        public override List<double> yData { get; protected set; }
        public override double yavg { get; protected set; }
        private List<double> xDataPow2;
        private double xPow2avg;
        private List<double> xDataPow3;
        private double xPow3avg;
        private double xDataDisp;
        public override int N => xData.Count;
        public override DetermCoef DeterminationCoef { get; }
        private double phi0 { get; set; }

        private RegressionScore A { get; set; }
        private RegressionScore B { get; set; }
        private RegressionScore C { get; set; }

        public override List<RegressionScore> Scores { get; protected set; }

        private double restDisp;
        private double alpha;
        private double quantil;

        private double regressionYavg;

        public ParabolicRegression(List<double> _xData, List<double> _yData, double _alpha)
        {
            alpha = _alpha;
            xData = _xData;
            xavg = StatCharacteristicModel.Average.GetAverage(xData);

            yData = _yData;
            yavg = StatCharacteristicModel.Average.GetAverage(yData);

            xDataPow2 = xData.Select(d => d * d).ToList();
            xPow2avg = StatCharacteristicModel.Average.GetAverage(xDataPow2);

            xDataPow3 = xData.Select(d => d * d * d).ToList();
            xPow3avg = StatCharacteristicModel.Average.GetAverage(xDataPow3);

            xDataDisp = StatCharacteristicModel.StandartDeviationSkew.GetValue(xData);
            xDataDisp *= xDataDisp;

            phi0 = 1;
            quantil = Quantiles.t_Student(1 - alpha / 2, N - 3);

            var a = yavg;
            var b = GetB();
            var c = GetC();

            restDisp = RestDisp(a, b, c);

            A = new ParabolicalScoreA(restDisp, N) { Name = "a0", Value = a, Quantil = quantil };

            var xSd = StatCharacteristicModel.StandartDeviationSkew.GetValue(xData);
            B = new ParabolicalScoreB(restDisp, N, xSd) { Name = "a1", Value = b, Quantil = quantil };

            var phi2Pow2Sum = xData.Sum(x => Math.Pow(Phi2(x), 2));
            C = new ParabolicalScoreC(restDisp, N, phi2Pow2Sum) { Name = "a2", Value = c, Quantil = quantil };

            A.Dispersion = restDisp / N;
            B.Dispersion = restDisp / (N * xDataDisp);
            C.Dispersion = restDisp / phi2Pow2Sum;

            var regressionY = xData.Select(xi => Calculate(xi)).ToList();
            regressionYavg = StatCharacteristicModel.Average.GetAverage(regressionY);

            Scores = new List<RegressionScore>();
            Scores.Add(A);
            Scores.Add(B);
            Scores.Add(C);

            DeterminationCoef = new DetermCoef(this, alpha);
        }

        public override double Calculate(double x)
        {
             return/* Math.Sqrt(*/A.Value + B.Value * x + C.Value * x * x/*)*/;
        }

        public override double GetRegressionIntervalBelow(double x)
        {
            var Syx = GetSyx(x);
            return Calculate(x) - quantil * Syx;
        }

        public override double GetRegressionIntervalTop(double x)
        {
            var Syx = GetSyx(x);
            return Calculate(x) + quantil * Syx;
        }

        public override double GetPrognosisIntervalBelow(double x)
        {
            var Syx0 = GetSyx0(x);

            return Calculate(x) - quantil * Syx0;
        }

        public override double GetPrognosisIntervalTop(double x)
        {
            var Syx0 = GetSyx0(x);

            return Calculate(x) + quantil * Syx0;
        }

        public double GetStatistic(double x)
        {
            var theorYavg = yavg;
            var S = GetSyx(x);
            return (Calculate(x) - theorYavg) / S;
        }

        private double GetSyx(double x)
        {
            var Sb2 = restDisp / (N * xDataDisp);

            var phi2Pow2Sum = xData.Sum(xi => Math.Pow(Phi2(xi), 2));
            var Sc2 = restDisp / phi2Pow2Sum;

            var phi1x = Phi1(x);
            var phi2x = Phi2(x);
            var S = Math.Sqrt(restDisp / N + Sb2 * phi1x * phi1x + Sc2 * phi2x * phi2x);

            return S;
        }

        private double GetSyx0(double x)
        {
            var Sb2 = restDisp / (N * xDataDisp);

            var phi2Pow2Sum = xData.Sum(xi => Math.Pow(Phi2(xi), 2));
            var Sc2 = restDisp / phi2Pow2Sum;

            var phi1 = Phi1(x);
            var phi2 = Phi2(x);

            var S = Math.Sqrt(restDisp * (1 + 1 / N) + Sb2 * phi1 * phi1 + Sc2 * phi2 * phi2);
            return S;
        }

        private double RestDisp(double a, double b, double c)
        {
            double sum = 0;
            for (int i = 0; i < N; i++)
            {
                sum += Math.Pow(yData[i] - a - b * Phi1(xData[i]) - c * Phi2(xData[i]), 2);
            }

            return sum / (N - 3);
        }

        private double Phi1(double x)
        {
            return x - xavg;
        }

        private double Phi2(double x)
        {
            return x * x - (xPow3avg - xPow2avg * xavg) * (x - xavg) / xDataDisp - xPow2avg;
        }

        private double GetB()
        {
            double Btop = 0;
            double Bbottom = 0;
            for (int i = 0; i < N; i++)
            {
                Btop += (xData[i] - xavg) * yData[i];
                Bbottom += (xData[i] - xavg) * (xData[i] - xavg);
            }

            return Btop / Bbottom;
        }

        private double GetC()
        {
            double top = 0;
            double bottom = 0;
            for (int i = 0; i < N; i++)
            {
                var phi2 = Phi2(xData[i]);

                top += phi2 * yData[i];
                bottom += phi2 * phi2;
            }

            return top / bottom;
        }
    }
}
