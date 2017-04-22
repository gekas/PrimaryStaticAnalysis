using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimaryStaticAnalysis.DAL
{
    public static class StatCharacteristicModel
    {
        public static double GetMedian(List<double> data)
        {
            double median;
            var newData = new List<double>(data);

            newData.Sort();
            if (newData.Count % 2 == 0)
            {
                median = (newData[newData.Count / 2] + newData[newData.Count / 2 + 1]) / 2;
            }
            else
            {
                median = newData[newData.Count / 2 + 1];
            }

            return median;
        }

        public static double ConfidentialBelowBorder(double score, double sigma)
        {
            return score - 2 * sigma;
        }

        public static double ConfidentialTopBorder(double score, double sigma)
        {
            return score + 2 * sigma;
        }

        #region Characteristis

        // x штрих
        public static class Average
        {
            public static double GetAverage(List<double> data)
            {
                return data.Sum() / data.Count;
            }

            public static double GetMarkDeviation(List<double> data)
            {
                double S = StandartDeviationNotSkew.GetValue(data);
                return S / Math.Sqrt(data.Count);
            }
        }

        // S^
        public struct StandartDeviationSkew
        {
            public static double GetValue(List<double> data)
            {
                double standartDeviation;

                double average = Average.GetAverage(data);
                // standartDeviation = Math.Sqrt(data.Sum(d => (d - average) * (d - average)) / data.Count);
                standartDeviation = Math.Sqrt(data.Sum(d => d*d - average*average) / data.Count);
                return standartDeviation;
            }

            public static double GetDeviation(List<double> data)
            {
                double S = StandartDeviationSkew.GetValue(data);
                return S / Math.Sqrt(2 * data.Count);
            }
        }

        // S
        public static class StandartDeviationNotSkew
        {
            public static double GetValue(List<double> data)
            {
                double standartDeviation;
                double average = Average.GetAverage(data);

                double exp1 = data.Sum(d => Math.Pow(d - average, 2));
                standartDeviation = Math.Sqrt(exp1 / (data.Count - 1));

                return standartDeviation;
            }

            public static double GetDeviation(List<double> data)
            {
                double S = StandartDeviationNotSkew.GetValue(data);
                return S / Math.Sqrt(2 * data.Count);
            }
        }

        // A^
        public static class AsymmetryCoefficientSkew
        {
            public static double GetValue(List<double> data)
            {
                double assymetryCoef;
                double standartDeviationSkew = StandartDeviationSkew.GetValue(data);
                double average = Average.GetAverage(data);

                assymetryCoef = data.Sum(d => Math.Pow((d - average), 3)) / (data.Count * Math.Pow(standartDeviationSkew, 3));
                return assymetryCoef;
            }
        }

        // A штрих
        public static class AsymmetryCoefficientNotSkew
        {
            public static double GetValue(List<double> data)
            {
                double acs = AsymmetryCoefficientSkew.GetValue(data);
                double N = data.Count;

                return acs * Math.Sqrt(N * (N - 1)) / (N - 2); ;
            }

            public static double GetDeviation(List<double> data)
            {
                double N = data.Count;

                return Math.Sqrt(6 * (N - 2) / ((N + 1) * (N + 3)));
            }
        }

        // E^
        public static class ExcessCoefSkew
        {
            /*
            Характеризует островершинность функции
            Е > 0 наиболее острее
            Е = 0 умеренно
            Е < 0 плавнее
            */
            public static double GetValue(List<double> data)
            {
                int N = data.Count;
                double sigma = StandartDeviationSkew.GetValue(data);
                double average = Average.GetAverage(data);

                double numenator = data.Sum(d => Math.Pow(d - average, 4)); // числитель
                double denominator = (N * Math.Pow(sigma, 4)); // знаменатель
                return numenator  / denominator;
            }
        }

        // E штрих
        public static class ExcessNotSkew
        {
            /*
                функція щільності симетрична, якщо A = 0; у разі A > 0 функція щільності лівоасиметрична; при A < 0 – правоасиметрична
            */
            public static double GetValue(List<double> data)
            {
                double N = data.Count;
                double excessCoefSkew = ExcessCoefSkew.GetValue(data);

                return ((N * N - 1) / ((N - 2) * (N - 3))) * ((excessCoefSkew - 3) + 6 / (N + 1));
            }

            public static double GetDeviation(List<double> data)
            {
                double N = data.Count;

                return Math.Sqrt(
                                (24 / N)
                                * (1 - (225 / (15 * N + 124))));
            }
        }

        // χ штрих
        public static class KontrekstsessCoef
        {
            /*
            характеризует форму распределения
            ˆχ < 0,515, розподіл є гостровершинний; при ˆχ > 0,63 має місце форма розподілу типу шапіто(приклад – рівномірний розподіл)
            */
            public static double GetValue(List<double> data)
            {
                var excessCoef = ExcessCoefSkew.GetValue(data);
                return 1 / Math.Sqrt(excessCoef);
            }

            public static double GetDeviation(List<double> data)
            {
                double excessSkew = ExcessCoefSkew.GetValue(data);
                double N = data.Count;

                return Math.Sqrt(Math.Abs(excessSkew) / (29 * N)) * Math.Pow(Math.Pow(Math.Abs(excessSkew * excessSkew - 1), 3), 1 / 4);
            }
        }

        // W штрих
        public static class PirsonCoef
        {
            /*
            характеризує якість вибірки, відображає відносну варіабельність даних у частках відносно середнього та дозволяє порівнювати варіабельність наборів даних, наведених у різних одиницях виміру. Якщо W <1, вибірка вважається якісною, тобто величина розсіювання відповідає середньому арифметичному; поміж двох вибірок кращою вважається та, для якої значення коефіцієнта W менше, тобто менша варіабельність
            */
            public static double GetValue(List<double> data)
            {
                var standartDeviation = StandartDeviationNotSkew.GetValue(data);
                double average = Average.GetAverage(data);

                return standartDeviation / average;
            }

            public static double GetDeviation(List<double> data)
            {
                double W = PirsonCoef.GetValue(data);
                double N = data.Count;

                return W * Math.Sqrt((1 + 2 * W * W) / (2 * N));
            }
        }

        #endregion
    }
}
