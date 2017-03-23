using System.Windows.Forms;

namespace PrimaryStaticAnalysis.DAL
{
    static class CharacteristicsGridModel
    {
        public const string SCORE_CELL = "Mark";
        public const string AVERAGE_DEVIATION_CELL = "AvrgDeviation";
        public const string BELOW_BORDER_CELL = "BelowBorder";
        public const string TOP_BORDER_CELL = "TopBorder";

        public static DataGridViewRow Average { get; private set; }
        public static DataGridViewRow Median { get; private set; }
        public static DataGridViewRow StandartDeviationNotSkew { get; private set; }
        public static DataGridViewRow StandartDeviationSkew { get; private set; }
        public static DataGridViewRow AsymetryCoef { get; private set; }
        public static DataGridViewRow ExcessCoef { get; private set; }
        public static DataGridViewRow KontrexcessCoef { get; private set; }
        public static DataGridViewRow PirsonCoef { get; private set; }

        static CharacteristicsGridModel()
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
        }
    }
}
