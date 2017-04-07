using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimaryStaticAnalysis.DAL
{
    class DensityKvantilA
    {
        public double Alpha => alpha;
        private double alpha;
        private Dictionary<int, double> kvantils = new Dictionary<int, double>();

        public DensityKvantilA(double alpha, Dictionary<int, double> kvantils)
        {
            this.alpha = alpha;

            foreach(var kvp in kvantils)
            {
                this.kvantils.Add(kvp.Key, kvp.Value);
            }
            
        }

        public double this[int m]
        {
            get
            {
                return kvantils[m];
            }
        }
    }
}
