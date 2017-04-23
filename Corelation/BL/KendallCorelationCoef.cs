using PrimaryStaticAnalysis.BL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using ZedGraph;

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

            List<PointD> unionSeriaSortedByX =
xRanged.ranks.Zip(yRanged.ranks.ToList(), (x, y) => new PointD(x, y)).OrderBy(p => p.X).ToList();

            List<double> rx = unionSeriaSortedByX.Select(p => p.X).ToList();
            List<double> ry = unionSeriaSortedByX.Select(p => p.Y).ToList();

            unionSeriaSortedByX.Select(p => p.X).ToList();
            double S = 0;
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    if (rx[i] != rx[j])
                    {
                        S += ry[j].CompareTo(ry[i]);
                    }
                }

            }

            var C = xRanged.Ranks.Where(r => r.Count > 1).Sum(xr => xr.Count * (xr.Count - 1)) / 2;
            var D = yRanged.Ranks.Where(r => r.Count > 1).Sum(yr => yr.Count * (yr.Count - 1)) / 2;

            coef = S / Math.Sqrt((0.5 * N * (N - 1) - C) * (0.5 * N * (N - 1) - D));

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
