using PrimaryStaticAnalysis.DAL;

namespace PrimaryStaticAnalysis.BL
{
    public class PirsonCriteria
    {
        // Критерій згоди Пірсона χ2
        public static double GetPirsonCriteria(IntervalVariationRow intervalVariationRow, double m, double sigma)
        {
            double pirsonCriteria = 0;
            int N = intervalVariationRow.N;

            foreach (var intervalVariant in intervalVariationRow.IntervalVariants)
            {
                var ni0 = GetTeoreticalFrequency(intervalVariant, N, m, sigma);
                pirsonCriteria += ((intervalVariant.Frequency - ni0) * (intervalVariant.Frequency - ni0))
                                  / ni0;
            }

            return pirsonCriteria;
        }

        private static double GetTeoreticalFrequency(IntervalVariant iv, int N, double m, double sigma)
        {
            double Pi;

            Pi = NormalDistribution.DensityFunction(iv.Interval.Item2, m, sigma) - NormalDistribution.DensityFunction(iv.Interval.Item1, m, sigma);
            return N * Pi;
        }
    }
}
