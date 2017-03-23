using PrimaryStaticAnalysis.BL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimaryStaticAnalysis.DAL
{
    public class VariationRow
    {
        private List<double> data = new List<double>();

        public int DataCount { get { return data.Count; } }

        public List<Variant> Variants { get; set; } = new List<Variant>();

        public VariationRow(List<double> data)
        {
            this.data = data;
            data.Sort();

            foreach (double value in data)
            {
                if (Variants.Where(v => v.Value == value).Count() > 0) continue;

                var frequency = data.FindAll(v => v == value).Count;
                double relFreq = (double)frequency / data.Count();

                double cumFreq = relFreq;
                if(Variants.Count > 0)
                {
                    cumFreq += Variants.Last().CummulatedFrequency;
                }

                Variants.Add(new Variant { Value = value,
                                           Frequency = frequency,
                                           CummulatedFrequency = cumFreq,
                                           RelativeFrequency = relFreq,
                                           EmpericalFunction = cumFreq
                             });
            }

            Variants.Sort();

            //foreach (var variant in Variants) variant.EmpericalFunction = Math.Round(Formulas.GetEmpericalFunctionValue(variant.Value, this), 2);
        }
    }

    public class Variant : IComparable<Variant>
    {
        public double Value { get; set; }
        public double Frequency { get; set; }
        public double RelativeFrequency { get; set; }
        public double CummulatedFrequency { get; set; }
        public double EmpericalFunction { get; set; }

        public int CompareTo(Variant other)
        {
            int comparingResult;

            if (other != null)
            {
                comparingResult = this.Value.CompareTo(other.Value);
            }
            else
            {
                comparingResult = 1;
            }

            return comparingResult;
        }
    }
}
