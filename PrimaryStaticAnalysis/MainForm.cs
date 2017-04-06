using PrimaryStaticAnalysis.BL;
using PrimaryStaticAnalysis.DAL;
using PrimaryStaticAnalysis.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PrimaryStaticAnalysis
{
    public partial class MainForm : Form
    {
        private List<double> dataItems;
        private VariationRow variationRow;
        private IntervalVariationRow iVariationRow;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    dataItems = FileReader.ReadFromFile(openFileDialog.FileName);
                }
                catch (FileLoadException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                // dataItems = FileReader.ReadFromFile(@"C:\\Users\\gekas\\Desktop\\StaticAnalysisAutomatisation_testData.txt");

                FillAllData(dataItems);
            }

            comboBox1.SelectedIndex = 1;
        }

        private void FillAllData(List<double> dataItems)
        {
            variationRow = new VariationRow(dataItems);

            FillVariationTable(variationRow);
            DrawEmpericalChart(variationRow.Variants);

            lblStegesClassesCount.Text = Formulas.GetNumberOfClasses(dataItems.Count).ToString();
            nudIntervalsCount.Value = Formulas.GetNumberOfClasses(variationRow.DataCount);

            iVariationRow = new IntervalVariationRow(variationRow, (int)nudIntervalsCount.Value);
            FillIntervalVariationTable(iVariationRow);
            DrawHistogram(iVariationRow.IntervalVariants, dataItems);

            FillCharacteristicsGrid(dataItems);
        }

        private void FillVariationTable(VariationRow variationRow)
        {
            gvVariationRow.Rows.Clear();

            for (int i = 0; i < variationRow.Variants.Count; i++)
            {
                var rowIndex = gvVariationRow.Rows.Add();
                var variant = variationRow.Variants[i];

                gvVariationRow.Rows[rowIndex].HeaderCell.Value = String.Format("{0}", rowIndex + 1);
                gvVariationRow.Rows[rowIndex].Cells["Value"].Value = variant.Value;
                gvVariationRow.Rows[rowIndex].Cells["Frequency"].Value = variant.Frequency;
                gvVariationRow.Rows[rowIndex].Cells["RelativeFrequency"].Value = String.Format("{0:0.###}", variant.RelativeFrequency);
                gvVariationRow.Rows[rowIndex].Cells["cumFreq"].Value = String.Format("{0:0.###}", variant.CummulatedFrequency);
                gvVariationRow.Rows[rowIndex].Cells["DistributionFunction"].Value = String.Format("{0:0.###}", variant.EmpericalFunction);
            }
        }

        private void FillIntervalVariationTable(IntervalVariationRow ivRow)
        {
            gvIntervalVariationRow.Rows.Clear();

            foreach (var variant in ivRow.IntervalVariants)
            {
                var rowIndex = gvIntervalVariationRow.Rows.Add();

                gvIntervalVariationRow.Rows[rowIndex].HeaderCell.Value = String.Format("{0}", rowIndex + 1);
                gvIntervalVariationRow.Rows[rowIndex].Cells["Interval"].Value = $"{variant.Interval.Item1.ToString("#.###")} - {variant.Interval.Item2.ToString("#.###")}";
                gvIntervalVariationRow.Rows[rowIndex].Cells["Freq"].Value = variant.Frequency;
                gvIntervalVariationRow.Rows[rowIndex].Cells["RelFreq"].Value = String.Format("{0:0.###}", variant.RelativeFrequency);
                gvIntervalVariationRow.Rows[rowIndex].Cells["cummulatedFrequency"].Value = String.Format("{0:0.###}", variant.CummulatedFrequenct);
                gvIntervalVariationRow.Rows[rowIndex].Cells["DispFunc"].Value = String.Format("{0:0.###}", variant.EmpericalFunction);
            }
        }

        private void FillCharacteristicsGrid(List<double> data)
        {
            var avrgScore = StatCharacteristicModel.Average.GetAverage(data);
            var avrgDeviation = StatCharacteristicModel.Average.GetMarkDeviation(data);
            CharacteristicsGridModel.Average.Cells[CharacteristicsGridModel.SCORE_CELL].Value = avrgScore.ToString("G7");
            CharacteristicsGridModel.Average.Cells[CharacteristicsGridModel.AVERAGE_DEVIATION_CELL].Value = avrgDeviation.ToString("G7");
            CharacteristicsGridModel.Average.Cells[CharacteristicsGridModel.BELOW_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialBelowBorder(avrgScore, avrgDeviation).ToString("G7");
            CharacteristicsGridModel.Average.Cells[CharacteristicsGridModel.TOP_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialTopBorder(avrgScore, avrgDeviation).ToString("G7");

            CharacteristicsGridModel.Median.Cells[CharacteristicsGridModel.SCORE_CELL].Value = StatCharacteristicModel.GetMedian(data).ToString("G7");
            CharacteristicsGridModel.Median.Cells[CharacteristicsGridModel.AVERAGE_DEVIATION_CELL].Value = "-";
            CharacteristicsGridModel.Median.Cells[CharacteristicsGridModel.BELOW_BORDER_CELL].Value = "-";
            CharacteristicsGridModel.Median.Cells[CharacteristicsGridModel.TOP_BORDER_CELL].Value = "-";

            var sdNotSkewScore = StatCharacteristicModel.StandartDeviationNotSkew.GetValue(data);
            var sdNotSkewDeviation = StatCharacteristicModel.StandartDeviationNotSkew.GetDeviation(data);
            CharacteristicsGridModel.StandartDeviationNotSkew.Cells[CharacteristicsGridModel.SCORE_CELL].Value = sdNotSkewScore.ToString("G7");
            CharacteristicsGridModel.StandartDeviationNotSkew.Cells[CharacteristicsGridModel.AVERAGE_DEVIATION_CELL].Value = sdNotSkewDeviation.ToString("G7");
            CharacteristicsGridModel.StandartDeviationNotSkew.Cells[CharacteristicsGridModel.BELOW_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialBelowBorder(sdNotSkewScore, sdNotSkewDeviation).ToString("G7");
            CharacteristicsGridModel.StandartDeviationNotSkew.Cells[CharacteristicsGridModel.TOP_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialTopBorder(sdNotSkewScore, sdNotSkewDeviation).ToString("G7");

            var asymetryScore = StatCharacteristicModel.AsymmetryCoefficientNotSkew.GetValue(data);
            var asmetryDeviation = StatCharacteristicModel.AsymmetryCoefficientNotSkew.GetDeviation(data);
            CharacteristicsGridModel.AsymetryCoef.Cells[CharacteristicsGridModel.SCORE_CELL].Value = asymetryScore.ToString("G7");
            CharacteristicsGridModel.AsymetryCoef.Cells[CharacteristicsGridModel.AVERAGE_DEVIATION_CELL].Value = asmetryDeviation.ToString("G7");
            CharacteristicsGridModel.AsymetryCoef.Cells[CharacteristicsGridModel.BELOW_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialBelowBorder(asymetryScore, asmetryDeviation).ToString("G7");
            CharacteristicsGridModel.AsymetryCoef.Cells[CharacteristicsGridModel.TOP_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialTopBorder(asymetryScore, asmetryDeviation).ToString("G7");

            var excessScore = StatCharacteristicModel.ExcessNotSkew.GetValue(data);
            var excessDeviation = StatCharacteristicModel.ExcessNotSkew.GetDeviation(data);
            CharacteristicsGridModel.ExcessCoef.Cells[CharacteristicsGridModel.SCORE_CELL].Value = excessScore.ToString("G7");
            CharacteristicsGridModel.ExcessCoef.Cells[CharacteristicsGridModel.AVERAGE_DEVIATION_CELL].Value = excessDeviation.ToString("G7");
            CharacteristicsGridModel.ExcessCoef.Cells[CharacteristicsGridModel.BELOW_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialBelowBorder(excessScore, excessDeviation).ToString("G7");
            CharacteristicsGridModel.ExcessCoef.Cells[CharacteristicsGridModel.TOP_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialTopBorder(excessScore, excessDeviation).ToString("G7");

            var kontrexcessScore = StatCharacteristicModel.KontrekstsessCoef.GetValue(data);
            var kontrexcessDeviation = StatCharacteristicModel.KontrekstsessCoef.GetDeviation(data);
            CharacteristicsGridModel.KontrexcessCoef.Cells[CharacteristicsGridModel.SCORE_CELL].Value = kontrexcessScore.ToString("G7");
            CharacteristicsGridModel.KontrexcessCoef.Cells[CharacteristicsGridModel.AVERAGE_DEVIATION_CELL].Value = kontrexcessDeviation.ToString("G7");
            CharacteristicsGridModel.KontrexcessCoef.Cells[CharacteristicsGridModel.BELOW_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialBelowBorder(kontrexcessScore, kontrexcessDeviation).ToString("G7");
            CharacteristicsGridModel.KontrexcessCoef.Cells[CharacteristicsGridModel.TOP_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialTopBorder(kontrexcessScore, kontrexcessDeviation).ToString("G7");

            var pirsonScore = StatCharacteristicModel.PirsonCoef.GetValue(data);
            var pirsonDeviation = StatCharacteristicModel.PirsonCoef.GetDeviation(data);
            CharacteristicsGridModel.PirsonCoef.Cells[CharacteristicsGridModel.SCORE_CELL].Value = pirsonScore.ToString("G7");
            CharacteristicsGridModel.PirsonCoef.Cells[CharacteristicsGridModel.AVERAGE_DEVIATION_CELL].Value = pirsonDeviation.ToString("G7");
            CharacteristicsGridModel.PirsonCoef.Cells[CharacteristicsGridModel.BELOW_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialBelowBorder(pirsonScore, pirsonDeviation).ToString("G7");
            CharacteristicsGridModel.PirsonCoef.Cells[CharacteristicsGridModel.TOP_BORDER_CELL].Value = StatCharacteristicModel.ConfidentialTopBorder(pirsonScore, pirsonDeviation).ToString("G7");

            dgvCharacteristics.Refresh();
        }

        private void btnRefreshIntervalVariationRow_Click(object sender, EventArgs e)
        {
            var ivRow = new IntervalVariationRow(variationRow, (int)nudIntervalsCount.Value);
            FillIntervalVariationTable(ivRow);

            DrawHistogram(ivRow.IntervalVariants, dataItems);
        }

        private void DrawEmpericalChart(List<Variant> variants)
        {
            crtEmpericalFunction.Series["Emperical"].Points.Clear();
            crtEmpericalFunction.Series["Emperical"].BorderWidth = 3;

            crtEmpericalFunction.Series["Density"].Points.Clear();
            crtEmpericalFunction.Series["Density"].BorderWidth = 2;

            var data = variants.Select(v => v.Value).ToList();
            var m = StatCharacteristicModel.Average.GetAverage(data);
            var sigma = StatCharacteristicModel.StandartDeviationNotSkew.GetValue(data);

            dataGridView1.Rows.Clear();
            foreach (var variant in variants)
            {
                crtEmpericalFunction.Series["Emperical"].Points.AddXY(variant.Value, variant.EmpericalFunction);
                var ProbabilityFunction = NormalDistribution.DensityFunction(variant.Value, m, sigma);
                crtEmpericalFunction.Series["Density"].Points.AddXY(variant.Value, ProbabilityFunction);
                var newRowId = dataGridView1.Rows.Add();
                dataGridView1.Rows[newRowId].Cells["value1"].Value = variant.Value;
                dataGridView1.Rows[newRowId].Cells["probabilityFunction"].Value = ProbabilityFunction;
            }
        }

        private void DrawHistogram(List<IntervalVariant> ivRow, List<double> data)
        {
            crtIntervalRow.Series["Frequency"].Points.Clear();
            crtIntervalRow.Series["Frequency"]["PointWidth"] = "1";

            crtIntervalRow.Series["ProbabilityDensity"].Points.Clear();
            crtIntervalRow.Series["ProbabilityDensity"].BorderWidth = 2;

            var m = StatCharacteristicModel.Average.GetAverage(data);
            var sigma = StatCharacteristicModel.StandartDeviationNotSkew.GetValue(data);

            foreach (var iVariant in ivRow)
            {
                crtIntervalRow.Series["Frequency"].Points.AddXY(iVariant.Interval.Item1.ToString("#.###"), iVariant.RelativeFrequency);

                var x = (iVariant.Interval.Item1 + iVariant.Interval.Item2) / 2;
                var probabilityDensity = NormalDistribution.ProbabilityDensity(x, m, sigma);
                crtIntervalRow.Series["ProbabilityDensity"].Points.AddXY(x.ToString("#.###"), probabilityDensity);
            }
        }

        private void InitializeCharacteristicsGrid()
        {
            dgvCharacteristics.Rows.AddRange(CharacteristicsGridModel.Average, CharacteristicsGridModel.Median, CharacteristicsGridModel.StandartDeviationNotSkew,
                /*CharacteristicsGridModel.StandartDeviationSkew,*/ CharacteristicsGridModel.AsymetryCoef, CharacteristicsGridModel.ExcessCoef, CharacteristicsGridModel.KontrexcessCoef, CharacteristicsGridModel.PirsonCoef);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeCharacteristicsGrid();
        }

        private void btnFindAnomal_Click(object sender, EventArgs e)
        {
            lbAnomals.Items.Clear();
            var anomalIntervals = GetAnomalIntervals();

            var items = GetAnomalItems(anomalIntervals);

            foreach (var item in items)
            {
                lbAnomals.Items.Add(item);
            }
        }

        private List<IntervalVariant> GetAnomalIntervals()
        {
            double y1, y2;
            List<IntervalVariant> iAnomalVariants = new List<IntervalVariant>();

            try
            {
                y1 = Double.Parse(tbY1.Text);
                y2 = Double.Parse(tbY2.Text);
            }
            catch
            {
                MessageBox.Show("Y1, Y2 must be double");
                return iAnomalVariants;
            }

            for (int i = 0; i < iVariationRow.IntervalVariants.Count / 2; i++)
            {
                if (iVariationRow.IntervalVariants[i].RelativeFrequency <= y1) iAnomalVariants.Add(iVariationRow.IntervalVariants[i]);
            }

            for (int i = iVariationRow.IntervalVariants.Count - 1; i >= iVariationRow.IntervalVariants.Count / 2; i--)
            {
                if (iVariationRow.IntervalVariants[i].RelativeFrequency <= y2) iAnomalVariants.Add(iVariationRow.IntervalVariants[i]);
            }

            return iAnomalVariants;
        }

        private List<double> GetAnomalItems(List<IntervalVariant> anomalIntVarts)
        {
            List<double> items = new List<double>();
            foreach (var iVariant in anomalIntVarts)
            {
                items.AddRange(dataItems.Where(di => di >= iVariant.Interval.Item1 && di < iVariant.Interval.Item2));
            }

            items = items.Distinct().ToList();
            return items;
        }

        private void btnDeleteAnomals_Click(object sender, EventArgs e)
        {
            lbAnomals.Items.Clear();
            var anomalIntervals = GetAnomalIntervals();

            var items = GetAnomalItems(anomalIntervals);

            foreach (var item in items)
            {
                dataItems.RemoveAll(i => i == item);
            }

            FillAllData(dataItems);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            var alpha = Double.Parse((string)comboBox1.SelectedItem);
            var kvantils = FileReader.ReadDensityKvantils();
            var v = iVariationRow.IntervalVariants.Count - 1;
            var criticalValue = kvantils.Where(kv => kv.Alpha == alpha).First()[v];
            var m = StatCharacteristicModel.Average.GetAverage(dataItems);
            var sigma = StatCharacteristicModel.StandartDeviationNotSkew.GetValue(dataItems);

            dgvPirson.Rows.Clear();
            var newRowIndex = dgvPirson.Rows.Add();
            dgvPirson.Rows[newRowIndex].Cells["statistic"].Value = PirsonCriteria.GetPirsonCriteria(iVariationRow, m, sigma);
            dgvPirson.Rows[newRowIndex].Cells["CriticalValue"].Value = criticalValue;
        }
    }
}