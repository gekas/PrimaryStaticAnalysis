using PrimaryStaticAnalysis.BL;
using PrimaryStaticAnalysis.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Utils;
using static PrimaryStaticAnalysis.BL.SelectionsHomogeneity;

namespace PrimaryStaticAnalysis
{
    public partial class MainForm : Form
    {
        private static double alpha = 0.05;

        List<double> firstSequence = new List<double>();
        List<double> secondSequence = new List<double>();
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadTwo_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    var a = FileReader.ReadTwoFromFile(openFileDialog.FileName);
                    firstSequence = a.Item1;
                    secondSequence = a.Item2;
                }
                catch (FileLoadException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                FillSelectionLb(firstSequence, lbSelection1);
                FillSelectionLb(secondSequence, lbSelection2);

                FillStaticCriteriasGrid();

                FillCharacteristicsGrid(firstSequence, dgvCharacteristicsSelection1);
                FillCharacteristicsGrid(secondSequence, dgvCharacteristicsSelection2);
                //  dataItems = FileReader.ReadFromFile(@"C:\\Users\\gekas\\Desktop\\StaticAnalysisAutomatisation_testData.txt");

                //FillAllData(dataItems);
            }
        }

        private void FillSelectionLb(List<double> selection, ListBox lb)
        {
            lb.Items.Clear();

            for (int i = 0; i < selection.Count; i++) lb.Items.Add(selection[i]);
        }

        private void FillStaticCriteriasGrid()
        {
            dgvStatisticCriteria.Rows.Clear();

            var sh = new List<IHomogeneity>
            {
                new DispertionHomogeneition(firstSequence, secondSequence),
                new DependendAverageHomogeneition(firstSequence, secondSequence),
                new IndependendAverageHomogeneition(firstSequence, secondSequence),
                new DependedWilcoxonSignedRanksHomogeneition(firstSequence, secondSequence),
                new IndependedWilcoxonSignedRanksHomogeneition(firstSequence, secondSequence)
            };

            foreach(var criteria in sh)
            {
                var newRowIndex = dgvStatisticCriteria.Rows.Add();
                dgvStatisticCriteria.Rows[newRowIndex].Cells["name"].Value = criteria.Name;
                dgvStatisticCriteria.Rows[newRowIndex].Cells["score"].Value = criteria.Statistic.ToString("0.#####");
                dgvStatisticCriteria.Rows[newRowIndex].Cells["quantil"].Value = criteria.Quantil.ToString("0.#####"); ;
                dgvStatisticCriteria.Rows[newRowIndex].Cells["summaryHomoheneity"].Value = Math.Abs(criteria.Statistic) <= criteria.Quantil;
            }
        }

        private static List<DensityKvantilA> ReadDensityKvantils()
        {
            var result = new List<DensityKvantilA>();

            using (var stream = new StreamReader(@"KvantilDensity.txt"))
            {
                double alpha = 0;
                Dictionary<int, double> kvantilsM = new Dictionary<int, double>();
                int m = 0;

                while (!stream.EndOfStream)
                {
                    string line = stream.ReadLine();
                    if (line == string.Empty)
                    {
                        break;
                    }
                    else if (line.Contains("a"))
                    {
                        if (kvantilsM.Count > 0)
                        {
                            result.Add(new DensityKvantilA(alpha, kvantilsM));
                        }

                        m = 0;
                        alpha = Double.Parse(line.Remove(0, 1));
                        kvantilsM.Clear();

                        continue;
                    }

                    m++;
                    kvantilsM.Add(m, Double.Parse(line));
                }

                result.Add(new DensityKvantilA(alpha, kvantilsM));
            }

            return result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var alpha = Double.Parse((string)comboBox1.SelectedItem);
            var kvantils = ReadDensityKvantils();
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

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}