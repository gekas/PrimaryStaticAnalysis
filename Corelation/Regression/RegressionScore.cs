using System;

namespace CorelationAnalisys
{
    class RegressionScore
    {
        public string Name { get; set; }
        public virtual double Value { get; set; }
        public virtual double Dispersion { get; set; }
        public virtual double Statistic { get { return GetStatistic(); } }
        public virtual double Quantil { get; set; }
        public virtual bool IsSignificant { get { return Math.Abs(Statistic) > Quantil; } }

        public virtual double IntervalBelowBorder { get { return GetBelowBorder(); } protected set { } }

        public virtual double IntervalTopBorder { get { return GetTopBorder(); } }

        protected virtual double GetStatistic()
        {
            return Value / Math.Sqrt(Dispersion);
        }

        protected virtual double GetBelowBorder()
        {
            return Value - Quantil * Math.Sqrt(Dispersion);
        }

        protected virtual double GetTopBorder()
        {
            return Value + Quantil * Math.Sqrt(Dispersion);
        }
    }

    class ParabolicalScoreA : RegressionScore
    {
        private double restDisp;
        private int N;

        public ParabolicalScoreA(double _restDisp, int _N)
        {
            restDisp = _restDisp;
            N = _N;
        }

        protected override double GetBelowBorder()
        {
            return Value - Quantil * Math.Sqrt(restDisp) / N;
        }

        protected override double GetTopBorder()
        {
            return Value + Quantil * Math.Sqrt(restDisp) / N;
        }
    }

    class ParabolicalScoreB : RegressionScore
    {
        private double restDisp;
        private int N;
        private double standartDeviation;
        public ParabolicalScoreB(double _restDisp, int _N, double _standartDeviation)
        {
            restDisp = _restDisp;
            N = _N;
            standartDeviation = _standartDeviation;
        }

        protected override double GetBelowBorder()
        {
            return Value - Quantil * Math.Sqrt(restDisp) / (standartDeviation * N);
        }

        protected override double GetTopBorder()
        {
            return Value + Quantil * Math.Sqrt(restDisp) / (standartDeviation * N);
        }
    }

    class ParabolicalScoreC : RegressionScore
    {
        private double restDisp;
        private int N;
        private double phi2Pow2Sum;
        public ParabolicalScoreC(double _restDisp, int _N, double _phi2Pow2Sum)
        {
            restDisp = _restDisp;
            N = _N;
            phi2Pow2Sum = _phi2Pow2Sum;
        }

        protected override double GetBelowBorder()
        {
            return Value - Quantil * Math.Sqrt(restDisp) / Math.Sqrt(phi2Pow2Sum);
        }

        protected override double GetTopBorder()
        {
            return Value + Quantil * Math.Sqrt(restDisp) / Math.Sqrt(phi2Pow2Sum);
        }
    }
}
