using System.Collections.Generic;

namespace CorelationAnalisys.BL
{
    class ResidualAnalysis
    {
        private Regression lr;
        public List<Residual> Residuals { get; }

        public ResidualAnalysis(Regression _lr)
        {
            lr = _lr;

            Residuals = new List<Residual>();
            for (int i = 0; i < lr.N; i++)
            {
                var f = lr.Calculate(lr.xData[i]);
                Residuals.Add(new Residual { RegressionValue = f, ResidualValue = lr.yData[i] - f });
            }
        }
    }

    class Residual
    {
        public double RegressionValue { get; set; }
        public double ResidualValue { get; set; }
    }
}
