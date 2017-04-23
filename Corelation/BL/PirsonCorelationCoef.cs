using PrimaryStaticAnalysis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace CorelationAnalisys.BL
{
    class PirsonCorelationCoef : CorelationCoef
    {
        public List<double> x { get; private set; } = new List<double>();
        public List<double> y { get; private set; } = new List<double>();

        private double alpha;
        private int N => x.Count;
        public override string Name => "Коэффициент Пирсона";
        public PirsonCorelationCoef(List<double> x, List<double> y, double alpha)
        {
            this.alpha = alpha;
            this.x = x;
            this.y = y;
        }

        public override double GetCoef()
        {
            var xy = x.Zip(y, (i, j) => i * j).ToList();
            var xyAvg = StatCharacteristicModel.Average.GetAverage(xy);
            var xAvg = StatCharacteristicModel.Average.GetAverage(x);
            var yAvg = StatCharacteristicModel.Average.GetAverage(y);

            var xDispSkew = StatCharacteristicModel.StandartDeviationSkew.GetValue(x);

            var yDispSkew = StatCharacteristicModel.StandartDeviationSkew.GetValue(y);

            return (xyAvg - xAvg * yAvg) / (xDispSkew * yDispSkew);
        }

        public override double GetStatistic()
        {
            var r = GetCoef();

            return r * Math.Sqrt(N - 2) / Math.Sqrt(1 - r * r);
        }

        public override double GetQuantil()
        {
            return Quantiles.t_Student(1 - alpha / 2, N - 2);
        }

        public override double? GetBelowBorder()
        {
            var r = GetCoef();

            //var u = Quantiles.u_Normal(1- alpha/2);
            //return r + r * (1 - r * r) / (2 * N) - u * (1 - r * r) / Math.Sqrt(N-1);
            var t = GetQuantil();
            return r - t * Math.Sqrt((1 - r * r) / (N - 2));
        }

        public override double? GetTopBorder()
        {
            var r = GetCoef();

            //var u = Quantiles.u_Normal(1 - alpha / 2);
            //return r + r * (1 - r * r) / (2 * N) + u * (1 - r * r) / Math.Sqrt(N - 1);

            var t = GetQuantil();
            return r + t * Math.Sqrt((1 - r * r) / (N - 2));
        }
    }
}
