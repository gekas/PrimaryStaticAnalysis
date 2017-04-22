using PrimaryStaticAnalysis.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CorelationAnalisys.BL
{
    class KendallCorelationCoef : CorelationCoef
    {
        public List<double> x { get; private set; } = new List<double>();
        public List<double> y { get; private set; } = new List<double>();

        private double alpha;
        private int N => x.Count;

        public override string Name => "Коэффициент Кендалла";

        public KendallCorelationCoef(List<double> x, List<double> y, double alpha)
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
            if (xRanged.Ranks.Where(r => r.Items.Count > 1).Count() == 0
                 && yRanged.Ranks.Where(r => r.Items.Count > 1).Count() == 0)
            {
                double S = 0;
                for (int i = 0; i < N - 1; i++)
                {
                    for (int j = i + 1; j < N; j++)
                    {
                        double yiRank = yRanged.Selection.Where(itm => itm.value == y[i]).First().rank;
                        double yjRank = yRanged.Selection.Where(itm => itm.value == y[j]).First().rank;

                        S += yiRank < yjRank ? 1
                               : yiRank > yjRank ? -1
                                   : 0;
                    }     
                }
                    

                coef = S / (0.5 * N * (N - 1));
            }
            else
            {
                double S = 0;
                for (int i = 0; i < N - 1; i++)
                {
                    for (int j = i + 1; j < N; j++)
                    {
                        double xiRank = xRanged.Selection.Where(itm => itm.value == x[i]).First().rank;
                        double xjRank = xRanged.Selection.Where(itm => itm.value == x[j]).First().rank;

                        double yiRank = yRanged.Selection.Where(itm => itm.value == y[i]).First().rank;
                        double yjRank = yRanged.Selection.Where(itm => itm.value == y[j]).First().rank;

                        S += yiRank < yjRank && xiRank != xjRank ? 1
                               : yiRank > yjRank && xiRank != xjRank ? -1
                                   : 0;
                    }
                       
                }

                var C = xRanged.Ranks.Where(r => r.Count > 1).Sum(x => x.rank * (x.rank - 1)) / 2;
                var D = yRanged.Ranks.Where(r => r.Count > 1).Sum(y => y.rank * (y.rank - 1)) / 2;

                coef = S / Math.Sqrt((0.5 * N * (N - 1) - C) * (0.5 * N * (N - 1) - D));
            }

            return coef;
        }

        public override double GetStatistic()
        {
            var t = GetCoef();

            var u = t * Math.Sqrt(9 * N * (N - 1)) / Math.Sqrt(2 * (2 * N + 5));
            return u;
        }

        public override double GetQuantil()
        {
            return Quantiles.u_Normal(1 - alpha / 2);
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
