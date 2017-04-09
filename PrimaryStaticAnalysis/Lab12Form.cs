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
                //  dataItems = FileReader.ReadFromFile(@"C:\\Users\\gekas\\Desktop\\StaticAnalysisAutomatisation_testData.txt");

                FillAllData(dataItems);
            }

            var m = StatCharacteristicModel.Average.GetAverage(dataItems);
            var sigma = StatCharacteristicModel.StandartDeviationNotSkew.GetValue(dataItems);

            tbM.Text = m.ToString("#.#######");
            tbSigma.Text = sigma.ToString("#.#######");

            comboBox1.SelectedIndex = 3;
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
            DrawHistogram(iVariationRow, dataItems);

            FillCharacteristicsGrid(dataItems, dgvCharacteristics);
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

        private void FillCharacteristicsGrid(List<double> data, DataGridView dgv)
        {
            CharacteristicsGridModel gridModel = new CharacteristicsGridModel(dgv);

            var avrgScore = StatCharacteristicModel.Average.GetAverage(data);
            var avrgDeviation = StatCharacteristicModel.Average.GetMarkDeviation(data);

            gridModel.Average.Cells[0].Value = avrgScore.ToString("G7");
            gridModel.Average.Cells[1].Value = avrgDeviation.ToString("G7");
            gridModel.Average.Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(avrgScore, avrgDeviation).ToString("G7");
            gridModel.Average.Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(avrgScore, avrgDeviation).ToString("G7");

            gridModel.Median.Cells[0].Value = StatCharacteristicModel.GetMedian(data).ToString("G7");
            gridModel.Median.Cells[1].Value = "-";
            gridModel.Median.Cells[2].Value = "-";
            gridModel.Median.Cells[3].Value = "-";

            var sdNotSkewScore = StatCharacteristicModel.StandartDeviationNotSkew.GetValue(data);
            var sdNotSkewDeviation = StatCharacteristicModel.StandartDeviationNotSkew.GetDeviation(data);
            gridModel.StandartDeviationNotSkew.Cells[0].Value = sdNotSkewScore.ToString("G7");
            gridModel.StandartDeviationNotSkew.Cells[1].Value = sdNotSkewDeviation.ToString("G7");
            gridModel.StandartDeviationNotSkew.Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(sdNotSkewScore, sdNotSkewDeviation).ToString("G7");
            gridModel.StandartDeviationNotSkew.Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(sdNotSkewScore, sdNotSkewDeviation).ToString("G7");

            var asymetryScore = StatCharacteristicModel.AsymmetryCoefficientNotSkew.GetValue(data);
            var asmetryDeviation = StatCharacteristicModel.AsymmetryCoefficientNotSkew.GetDeviation(data);
            gridModel.AsymetryCoef.Cells[0].Value = asymetryScore.ToString("G7");
            gridModel.AsymetryCoef.Cells[1].Value = asmetryDeviation.ToString("G7");
            gridModel.AsymetryCoef.Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(asymetryScore, asmetryDeviation).ToString("G7");
            gridModel.AsymetryCoef.Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(asymetryScore, asmetryDeviation).ToString("G7");

            var excessScore = StatCharacteristicModel.ExcessNotSkew.GetValue(data);
            var excessDeviation = StatCharacteristicModel.ExcessNotSkew.GetDeviation(data);
            gridModel.ExcessCoef.Cells[0].Value = excessScore.ToString("G7");
            gridModel.ExcessCoef.Cells[1].Value = excessDeviation.ToString("G7");
            gridModel.ExcessCoef.Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(excessScore, excessDeviation).ToString("G7");
            gridModel.ExcessCoef.Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(excessScore, excessDeviation).ToString("G7");

            var kontrexcessScore = StatCharacteristicModel.KontrekstsessCoef.GetValue(data);
            var kontrexcessDeviation = StatCharacteristicModel.KontrekstsessCoef.GetDeviation(data);
            gridModel.KontrexcessCoef.Cells[0].Value = kontrexcessScore.ToString("G7");
            gridModel.KontrexcessCoef.Cells[1].Value = kontrexcessDeviation.ToString("G7");
            gridModel.KontrexcessCoef.Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(kontrexcessScore, kontrexcessDeviation).ToString("G7");
            gridModel.KontrexcessCoef.Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(kontrexcessScore, kontrexcessDeviation).ToString("G7");

            var pirsonScore = StatCharacteristicModel.PirsonCoef.GetValue(data);
            var pirsonDeviation = StatCharacteristicModel.PirsonCoef.GetDeviation(data);
            gridModel.PirsonCoef.Cells[0].Value = pirsonScore.ToString("G7");
            gridModel.PirsonCoef.Cells[1].Value = pirsonDeviation.ToString("G7");
            gridModel.PirsonCoef.Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(pirsonScore, pirsonDeviation).ToString("G7");
            gridModel.PirsonCoef.Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(pirsonScore, pirsonDeviation).ToString("G7");

            dgvCharacteristics.Refresh();
        }

        private void btnRefreshIntervalVariationRow_Click(object sender, EventArgs e)
        {
            var ivRow = new IntervalVariationRow(variationRow, (int)nudIntervalsCount.Value);
            FillIntervalVariationTable(ivRow);

            DrawHistogram(ivRow, dataItems);
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


            foreach (var variant in variants)
            {
                crtEmpericalFunction.Series["Emperical"].Points.AddXY(variant.Value, variant.EmpericalFunction);
                crtEmpericalFunction.Series["Density"].Points.AddXY(variant.Value, NormalDistribution.DensityFunction(variant.Value, m, sigma));
            }
        }

        private void DrawHistogram(IntervalVariationRow ivRow, List<double> data)
        {
            crtIntervalRow.Series["Frequency"].Points.Clear();
            crtIntervalRow.Series["Frequency"]["PointWidth"] = "1";

            crtIntervalRow.Series["ProbabilityDensity"].Points.Clear();
            crtIntervalRow.Series["ProbabilityDensity"].BorderWidth = 2;

            var m = StatCharacteristicModel.Average.GetAverage(data);
            var sigma = StatCharacteristicModel.StandartDeviationNotSkew.GetValue(data);

            foreach (var iVariant in ivRow.IntervalVariants)
            {
                crtIntervalRow.Series["Frequency"].Points.AddXY(iVariant.Interval.Item1.ToString("#.###"), iVariant.RelativeFrequency);

                var x = (iVariant.Interval.Item1 + iVariant.Interval.Item2) / 2;
                var probabilityDensity = ivRow.h * NormalDistribution.ProbabilityDensity(x, m, sigma);
                crtIntervalRow.Series["ProbabilityDensity"].Points.AddXY(x.ToString("#.###"), probabilityDensity);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

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
            var pirsonStatistic = PirsonCriteria.GetPirsonCriteria(iVariationRow, m, sigma);
            dgvPirson.Rows[newRowIndex].Cells["statistic"].Value = pirsonStatistic.ToString("#.##");
            dgvPirson.Rows[newRowIndex].Cells["CriticalValue"].Value = criticalValue;
            dgvPirson.Rows[newRowIndex].Cells["summary"].Value = pirsonStatistic < criticalValue ? "Достоверно" : "Не достоверно";
        }
    }
}
