using System.Collections.Generic;

namespace CorelationAnalisys.BL
{
    abstract class Regression
    {
        public abstract int N { get; }
        public abstract List<double> xData { get; protected set; }
        public abstract List<double> yData { get; protected set; }
        public abstract double yavg { get; protected set; }
        public abstract List<RegressionScore> Scores { get; protected set; }
        public abstract DetermCoef DeterminationCoef { get; }
        public abstract double Calculate(double x);
        public abstract double GetRegressionIntervalBelow(double x);
        public abstract double GetRegressionIntervalTop(double x);
        public abstract double GetPrognosisIntervalBelow(double x);
        public abstract double GetPrognosisIntervalTop(double x);
    }
}
