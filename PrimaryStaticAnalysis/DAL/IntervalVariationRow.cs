using System;
using System.Collections.Generic;
using System.Linq;
using PrimaryStaticAnalysis.BL;

namespace PrimaryStaticAnalysis.DAL
{
    class IntervalVariationRow
    {
        public List<IntervalVariant> IntervalVariants = new List<IntervalVariant>();

        public IntervalVariationRow(VariationRow variationRow, int intervalsCount)
        {
            var h = Formulas.GetStep(variationRow, intervalsCount);

            var beginInterval = variationRow.Variants.First().Value - h / 2;
            while (beginInterval < variationRow.Variants.Last().Value)
            {
                double endInterval = beginInterval + h;
                double frequency = 0;
                double relativeFrequency = 0;
                double empericalFunction = 0;

                for (int i = 0; i < variationRow.Variants.Count; i++)
                {
                    if (variationRow.Variants[i].Value >= beginInterval && variationRow.Variants[i].Value < endInterval)
                    {
                        frequency += variationRow.Variants[i].Frequency;
                        relativeFrequency += variationRow.Variants[i].RelativeFrequency;
                    }
                }

                double cumFreq = relativeFrequency;
                if (IntervalVariants.Count > 0)
                {
                    cumFreq += IntervalVariants.Last().CummulatedFrequenct;
                }

                empericalFunction = cumFreq;

                IntervalVariants.Add(new IntervalVariant
                {
                    Interval = new Tuple<double, double>(beginInterval, beginInterval + h),
                    Frequency = frequency,
                    RelativeFrequency = relativeFrequency,
                    CummulatedFrequenct = cumFreq,
                    EmpericalFunction = empericalFunction
                });

                beginInterval += h;
            }
        }
    }

    public class IntervalVariant
    {
        public Tuple<double, double> Interval { get; set; }
        public double Frequency { get; set; }
        public double RelativeFrequency { get; set; }
        public double CummulatedFrequenct { get; set; }
        public double EmpericalFunction { get; set; }

    }
}
