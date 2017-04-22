using System;
using System.Collections.Generic;
using System.Linq;
using PrimaryStaticAnalysis.DAL;
using Utils;

namespace CorelationAnalisys.BL
{
    class CorelationRelation : CorelationCoef
    {
        List<double> xData = new List<double>();
        List<double> yData = new List<double>();

        public List<CorelationRelationClass> DataClasses { get; private set; } = new List<CorelationRelationClass>();
        double k; // количество классов 

        private int N => xData.Count;
        double alpha;
        public override string Name => "Кореляционное отношение";
        public CorelationRelation(List<double> _xData, List<double> _yData, double _alpha)
        {
            alpha = _alpha;
            xData = _xData;
            yData = _yData;
            k = 1 + 1.44 * Math.Log(xData.Count);
            k = Math.Floor(k);
            ReorganizeData(xData, yData, k);
        }

        /// <summary>
        /// Если p^2 = 0 - кореляционная связь отсутсвует
        /// </summary>
        /// <returns></returns>
        public override double GetCoef()
        {
            var yavg = StatCharacteristicModel.Average.GetAverage(yData);

            double topSum = 0;
            double bottomSum = 0;
            for (int i = 0; i < Math.Floor(k); i++)
            {
                var yAvgInClass = StatCharacteristicModel.Average.GetAverage(DataClasses[i].Y);
                topSum += DataClasses[i].Y.Count * (yAvgInClass - yavg) * (yAvgInClass - yavg);

                for(int j = 0; j < DataClasses[i].Y.Count; j++)
                {
                    bottomSum += (DataClasses[i].Y[j] - yavg)*(DataClasses[i].Y[j] - yavg);
                }
            }

            return Math.Sqrt(topSum/bottomSum);
        }

        public override double GetStatistic()
        {
            var coef = GetCoef();
            return (coef * coef / (k - 1))
                    / ((1 - coef * coef) / (N - k));
        }

        public override double GetQuantil()
        {
            return Quantiles.f_Fisher(1 - alpha, k-1, N-k);
        }

        /// <summary>
        /// If TRUE then кореляція значуща, є кореляційний зв'язок
        /// </summary>
        /// <returns></returns>
        public override bool IsSignificant()
        {
            return GetStatistic() > GetQuantil();
        }

        public override double? GetBelowBorder()
        {
            return null;
        }

        public override double? GetTopBorder()
        {
            return null;
        }

        private void ReorganizeData(List<double> xData, List<double> yData, double k)
        {
            var xmax = xData.Max();
            var xmin = xData.Min();

            var h = (xmax - xmin) / k;

            for(int i = 1; i <= k; i++)
            {
                var gi = xmin + (i - 1) * h;
                var gnext = xmin + (i) * h;
                var xl = (gi + gnext) / 2;

                var curClass = new CorelationRelationClass() { X = xl };

                var ys = new List<double>();
                for (int j = 0; j < xData.Count; j++)
                    if (xData[j] >= gi && xData[j] < gnext)
                        ys.Add(yData[j]);

                curClass.Y = ys;

                DataClasses.Add(curClass);
            }
        }
    }

    public class CorelationRelationClass
    {
        public double X;
        public List<double> Y = new List<double>();
    }
}
