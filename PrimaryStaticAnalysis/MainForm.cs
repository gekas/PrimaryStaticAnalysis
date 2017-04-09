using PrimaryStaticAnalysis.BL;
using PrimaryStaticAnalysis.DAL;
using PrimaryStaticAnalysis.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
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

                FillStaticCriteriasGrid();
                FillCharacteristicsGrid(firstSequence, dgvCharacteristicsSelection1);
                FillCharacteristicsGrid(secondSequence, dgvCharacteristicsSelection2);
                //  dataItems = FileReader.ReadFromFile(@"C:\\Users\\gekas\\Desktop\\StaticAnalysisAutomatisation_testData.txt");

                //FillAllData(dataItems);
            }
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
    }
}