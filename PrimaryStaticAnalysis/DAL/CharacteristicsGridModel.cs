using System.Windows.Forms;

namespace PrimaryStaticAnalysis.DAL
{
    public class CharacteristicsGridModel
    {
        public const string SCORE_CELL = "Mark";
        public const string AVERAGE_DEVIATION_CELL = "AvrgDeviation";
        public const string BELOW_BORDER_CELL = "BelowBorder";
        public const string TOP_BORDER_CELL = "TopBorder";

        public DataGridViewRow Average { get; private set; }
        public DataGridViewRow Median { get; private set; }

        /// <summary>
        /// Рассеивание значений выборки относительно Мат. ожидания
        /// </summary>
        public DataGridViewRow StandartDeviationNotSkew { get; private set; }
        public DataGridViewRow StandartDeviationSkew { get; private set; }

        /// <summary>
        /// Степень не семитричности
        /// </summary>
        public DataGridViewRow AsymetryCoef { get; private set; }

        /// <summary>
        /// Острота пика распределения случайной величины
        /// </summary>
        public DataGridViewRow ExcessCoef { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DataGridViewRow KontrexcessCoef { get; private set; }
        public DataGridViewRow PirsonCoef { get; private set; }

        public CharacteristicsGridModel(DataGridView dgv)
        {
            Average = new DataGridViewRow();
            Average.HeaderCell.Value = "Среднее";
            Median = new DataGridViewRow();
            Median.HeaderCell.Value = "Медиана";
            StandartDeviationNotSkew = new DataGridViewRow();
            StandartDeviationNotSkew.HeaderCell.Value = "Среднеквадр. отклонение";
            StandartDeviationSkew = new DataGridViewRow();
            StandartDeviationSkew.HeaderCell.Value = "Среднеквадр. отклонение (смещенное)";
            AsymetryCoef = new DataGridViewRow();
            AsymetryCoef.HeaderCell.Value = "Коефициент асиметрии";
            ExcessCoef = new DataGridViewRow();
            ExcessCoef.HeaderCell.Value = "Коефициент эксцесса";
            KontrexcessCoef = new DataGridViewRow();
            KontrexcessCoef.HeaderCell.Value = "Коефициент контрэксцесса";
            PirsonCoef = new DataGridViewRow();
            PirsonCoef.HeaderCell.Value = "Вариация пирсона";

            dgv.Rows.AddRange(Average, Median, StandartDeviationNotSkew, AsymetryCoef, ExcessCoef, KontrexcessCoef, PirsonCoef);
        }
    }
}
