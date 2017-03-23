using PrimaryStaticAnalysis.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimaryStaticAnalysis.BL
{
    static class Formulas
    {
        public static double GetEmpericalFunctionValue(double x, VariationRow variationRow)
        {
            double empericalValue = 0;
            var variants = variationRow.Variants;

            if (x > variants[variants.Count - 1].Value)
            {
                empericalValue = 1;
            }
            else
            {
                for (int i = 0; i < variants.Count; i++)
                {
                    if (x <= variants[i].Value) // X <= Xi
                    {
                        for (int j = 0; j < i; j++) empericalValue += variants[j].Frequency;
                        empericalValue /= variationRow.DataCount;
                        break;
                    }
                }
            }

            return empericalValue;
        }

        public static int GetNumberOfClasses(int dataNumber)
        {
            var log = Math.Log10(dataNumber);
            return Convert.ToInt32(1 + 3.22 * log);
        }

        public static double GetStep(VariationRow variationRow, int intervalsNumber)
        {
            var maxValue = variationRow.Variants.OrderByDescending(variant => variant.Value).First().Value;
            var minValue = variationRow.Variants.OrderBy(variant => variant.Value).First().Value;

            return (maxValue - minValue) / intervalsNumber; // Размах вариации / количество классов (интервалов)
        }
    }

    public static class NormalDistribution
    {
        public static double ProbabilityDensity(double x, double m, double sigma)
        {
            var ePower = (((x - m) * (x - m)) / (2 * sigma * sigma));
            double first = 1 / (sigma * Math.Sqrt(2 * Math.PI) * Math.Pow(Math.E, ePower));

            return first;
        }

        public static double DensityFunction(double x, double m, double sigma)
        {
            var u = (x - m) / sigma;

            double b1 = 0.31938153;
            double b2 = -0.356563782;
            double b3 = 1.781477937;
            double b4 = -1.821255978;
            double b5 = 1.330274429;

            double p = 0.2316419;
            double t = 1 / (1 + p * u);

            double second = (Math.Exp(-(u * u) / 2) * (b1 * t + b2 * t * t + b3 * t * t * t + b4 * t * t * t * t + b5 * t * t * t * t * t)) / Math.Sqrt(2 * Math.PI);

            return 1 - second;
        }

        /// <summary>
        ///  μ — математическое ожидание (среднее значение), медиана и мода распределения, а параметр σ — среднеквадратическое отклонение
        /// </summary>
        /// <returns></returns>
        public static double GetMScore(List<double> data)
        {
            return StatCharacteristicModel.Average.GetAverage(data);
        }

        /// <summary>
        ///  μ — математическое ожидание (среднее значение), медиана и мода распределения, а параметр σ — среднеквадратическое отклонение
        /// </summary>
        /// <returns></returns>
        public static double GetSigmaScore(List<double> data)
        {
            return StatCharacteristicModel.StandartDeviationNotSkew.GetValue(data);
        }
    }
}
