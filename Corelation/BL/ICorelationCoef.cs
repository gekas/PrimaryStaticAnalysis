using System;

namespace CorelationAnalisys.BL
{
    public abstract class CorelationCoef
    {
        public abstract string Name { get; }
        public abstract double GetCoef();
        public abstract double GetStatistic();
        public abstract double GetQuantil();
        public abstract double? GetBelowBorder();
        public abstract double? GetTopBorder();

        /// <summary>
        /// Если |t|<= квантиль, то считается что коефициент кореляции равный нулю (не значимый)
        /// </summary>
        /// <returns></returns>
        public virtual bool IsSignificant()
        {
            return Math.Abs(GetStatistic()) > GetQuantil();
        }
    }
}
