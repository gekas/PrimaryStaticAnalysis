using PrimaryStaticAnalysis.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace CorelationAnalisys.BL
{
    public class SpearmanCorelationCoef : CorelationCoef
    {
        public List<double> x { get; private set; } = new List<double>();
        public List<double> y { get; private set; } = new List<double>();

        private double alpha;
        private int N => x.Count;

        public override string Name => "Коэффициент Спирмена";

        public SpearmanCorelationCoef(List<double> x, List<double> y, double alpha)
        {
            this.alpha = alpha;
            this.x = x;
            this.y = y;
        }

        public override double GetCoef()
        {
            var xRanged = new RankSelection();
            xRanged.AddSelection(x);

            var yRanged = new RankSelection();
            yRanged.AddSelection(y);

            double coef = 0;
            double rangedSum = 0;
            for (int i = 0; i < N; i++)
            {
                double xiRank = xRanged.Selection.Where(itm => itm.value == x[i]).First().rank;
                double yiRank = yRanged.Selection.Where(itm => itm.value == y[i]).First().rank;
                rangedSum += (xiRank - yiRank) * (xiRank - yiRank);
            }

            if (xRanged.Ranks.Where(r => r.Items.Count > 1).Count() == 0
                && yRanged.Ranks.Where(r => r.Items.Count > 1).Count() == 0)
            {
                coef = 1 - (6 * rangedSum) / (N * (N * N - 1));
            }
            else
            {
                var A = xRanged.Ranks.Where(r => r.Items.Count > 1).Sum(x => x.Count * x.Count * x.Count - x.Count) / 12;
                var B = yRanged.Ranks.Where(r => r.Items.Count > 1).Sum(y => y.Count * y.Count * y.Count - y.Count) / 12;

                double NsExp = N * (N * N - 1) / 6;
                double top = NsExp - rangedSum - A - B;
                double bottom = Math.Sqrt((NsExp - 2 * A) * (NsExp - 2 * B));

                coef = top / bottom;
            }

            return coef;
        }

        private bool AllRankNumbersAreInteger()
        {
            var countOfNotIntegerRankNumbers = 0;

            for (int i = 0; i < N; i++)
            {
                countOfNotIntegerRankNumbers += x.Where(xi => xi != Math.Truncate(xi)).Count();
                countOfNotIntegerRankNumbers += y.Where(yi => yi != Math.Truncate(yi)).Count();
            }

            return countOfNotIntegerRankNumbers == 0;
        }

        public override double GetQuantil()
        {
            return Quantiles.t_Student(1 - alpha / 2, N - 2);
        }

        public override double GetStatistic()
        {
            var t = GetCoef();
            double statistic = t * Math.Sqrt(N - 2) / Math.Sqrt(1 - t * t);

            return statistic;
        }

        public override double? GetTopBorder()
        {
            return null;
        }

        public override double? GetBelowBorder()
        {
            return null;
        }
    }
}
