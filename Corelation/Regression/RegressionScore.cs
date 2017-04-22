using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorelationAnalisys.Regression
{
    class RegressionScore
    {
        public string Name { get; set;}
        public virtual double Value { get; set; }
        public virtual double Dispersion { get; set; }
        public virtual double Statistic { get; set; }
        public virtual double Quantil { get; set; }
        public virtual bool IsSignificant { get { return Math.Abs(Statistic) > Quantil; } }
        public virtual double IntervalBelowBorder { get; set; }
        public virtual double IntervalTopBorder { get; set; }
    }
}
