using PrimaryStaticAnalysis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace PrimaryStaticAnalysis.BL
{
    public static class SelectionsHomogeneity
    {
        public static double alpha = 0.05;

        public interface IHomogeneity
        {
            string Name { get; }

            double Statistic { get; }

            double Quantil { get; }
        }

        public class DispertionHomogeneition : IHomogeneity
        {
            public string Name => "Дисперсия";
            public double Statistic { get; }

            public double Quantil { get; }

            public DispertionHomogeneition(List<double> firstSequence, List<double> secondSequence)
            {
                var d1 = NormalDistribution.GetDispersion(firstSequence);
                var d2 = NormalDistribution.GetDispersion(secondSequence);

                Statistic = d1 >= d2 ? d1 / d2 : d2 / d1;
                var v1 = firstSequence.Count - 1;
                var v2 = secondSequence.Count - 1;

                Quantil = Quantiles.f_Fisher(1 - alpha, v1, v2);
            }
        }

        public class DependendAverageHomogeneition : IHomogeneity
        {
            public string Name => "Средние зависимые";

            public double Quantil { get; }

            public double Statistic { get; }

            public DependendAverageHomogeneition(List<double> firstSequence, List<double> secondSequence)
            {
                List<double> zSelection = firstSequence.Zip(secondSequence, (x, y) => x - y).ToList();

                var N = zSelection.Count;
                var zAvg = StatCharacteristicModel.Average.GetAverage(zSelection);
                var sigma = NormalDistribution.GetSigmaScore(zSelection);

                Statistic = zAvg * Math.Sqrt(N) / sigma;
                Statistic = double.IsNaN(Statistic) ? 0 : Statistic;

                Quantil = Quantiles.t_Student(1 - alpha / 2, N - 1);
            }
        }

        public class IndependendAverageHomogeneition : IHomogeneity
        {
            public string Name => "Средние независимые";

            public double Quantil { get; }

            public double Statistic { get; }

            public IndependendAverageHomogeneition(List<double> firstSequence, List<double> secondSequence)
            {
                int N1 = firstSequence.Count;
                int N2 = secondSequence.Count;

                double d1 = NormalDistribution.GetDispersion(firstSequence);
                double d2 = NormalDistribution.GetDispersion(secondSequence);

                double avg1 = StatCharacteristicModel.Average.GetAverage(firstSequence);
                double avg2 = StatCharacteristicModel.Average.GetAverage(secondSequence);

                Quantil = Quantiles.t_Student(1 - alpha / 2, N1 + N2 - 2);

                if (N1 + N2 > 25)
                {
                    Statistic = (avg1 - avg2) / Math.Sqrt(d1 / N1 + d2 / N2);
                }
                else
                {
                    Statistic = ((avg1 - avg2) / Math.Sqrt(((N1 - 1) * d1 + (N2 - 1) * d2) / N1 + N2 - 2)) * Math.Sqrt(N1 * N2 / (N1 + N2));
                }

                Statistic = double.IsNaN(Statistic) ? 0 : Statistic;
            }
        }

        public class IndependedWilcoxonSignedRanksHomogeneition : IHomogeneity
        {
            public string Name => "Вилкоксон независимые";

            public double Quantil { get; }

            public double Statistic { get; }

            public IndependedWilcoxonSignedRanksHomogeneition(List<double> firstSequence, List<double> secondSequence)
            {
                int N1 = firstSequence.Count;
                int N2 = secondSequence.Count;

                Quantil = Quantiles.u_Normal(1 - alpha / 2);
                RankSelection z = new RankSelection();
                var fsNumber = z.AddSelection(firstSequence);
                z.AddSelection(secondSequence);

                var W = z.Selection.Where(i => i.selection == fsNumber).Select(r => r.rank).Sum();
                var E = (N1 * (N1 + N2 + 1)) / 2;
                var D = N1 * N2 * (N1 + N2 + 1) / 12;

                Statistic = (W - E) / Math.Sqrt(D);
                Statistic = double.IsNaN(Statistic) ? 0 : Statistic;
            }
        }

        public class DependedWilcoxonSignedRanksHomogeneition : IHomogeneity
        {
            public string Name => "Вилкоксон зависимые";
            public double Quantil { get; }
            public double Statistic { get; }

            public DependedWilcoxonSignedRanksHomogeneition(List<double> firstSequence, List<double> secondSequence)
            {
                var z = firstSequence.Zip(secondSequence, (x, y) => x - y).Where(i => i != 0).ToList();
                var N = z.Count;
                z.Sort((x, y) => x.CompareTo(y));
                List<Tuple<double, int>> signSeria = z.Select(x => new Tuple<double, int>(Math.Abs(x), x > 0 ? 1 : 0)).ToList();
                signSeria.Sort((x, y) => x.Item1.CompareTo(y.Item1));

                List<double> zAbs = z.Select(Math.Abs).ToList();

                RankSelection zAbsRanged = new RankSelection();
                zAbsRanged.AddSelection(zAbs);
                var T = zAbsRanged.Selection.Zip(signSeria, (r, a) => r.rank * a.Item2).Sum();
                var ET = N * (N + 1) / 4;

                double DT;
                if (zAbsRanged.Selection.Select(i => i.rank).Distinct().Count() == zAbsRanged.Selection.Count())
                {
                    DT = N * (N + 1) * (2 * N + 1) / 24;
                }
                else
                {
                    DT = (N * (N + 1) * (2 * N + 1) - zAbsRanged.Ranks.Sum(r => r.Count * (r.Count - 1) * (r.Count + 1)) / 2) / 24;
                }

                Statistic = (T - ET) / Math.Sqrt(DT);
                Statistic = double.IsNaN(Statistic) ? 0 : Statistic;
                Quantil = Quantiles.u_Normal(1 - alpha / 2);
            }
        }
    }
}
