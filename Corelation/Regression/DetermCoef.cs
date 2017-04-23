using CorelationAnalisys.BL;
using PrimaryStaticAnalysis.DAL;
using Utils;

namespace CorelationAnalisys
{
    class DetermCoef
    {
        Regression lr;
        double? value;
        public double Value { get { if (!value.HasValue) value = GetValue(); return value.Value; } }
        double? statistic;
        public double Statistic { get { if (!statistic.HasValue) statistic = GetStatistic(); return statistic.Value; } }
        public double Quantil { get { return Quantiles.f_Fisher(1-alpha/2,lr.Scores.Count, lr.N-lr.Scores.Count-1); } }
        private double alpha;
        public bool IsSignificant { get { return Statistic > Quantil; } }
        public DetermCoef(Regression _lr, double _alpha)
        {
            lr = _lr;
            alpha = _alpha;
        }

        private double GetValue()
        {
            //var yDispersion = StatCharacteristicModel.StandartDeviationSkew.GetValue(lr.yData);
            //yDispersion *= yDispersion;

            //return 1 - (lr.N - lr.Scores.Count) * lr.ResiduesDisp / (lr.N * yDispersion);

            double top = 0;
            double bottom = 0;
            for (int i = 0; i < lr.N; i++)
            {
                top += (lr.yData[i] - lr.Calculate(lr.xData[i])) * (lr.yData[i] - lr.Calculate(lr.xData[i]));
                bottom += (lr.yData[i] - lr.yavg) * (lr.yData[i] - lr.yavg);
            }

            return 1 - top / bottom;
        }

        private double GetStatistic()
        {
            return Value / (1 - Value) * (lr.N - lr.Scores.Count - 1) / lr.Scores.Count;
        }
    }
}
