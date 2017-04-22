using CorelationAnalisys.BL;
using CorelationAnalisys.Regression;
using PrimaryStaticAnalysis.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Utils;

namespace CorelationAnalisys
{
    public partial class frmCA : Form
    {
        List<double> xData = new List<double>();
        List<double> yData = new List<double>();

        private static double alpha = 0.05;

        private Series sCorelationFied = new Series("Кореляционное поле") { ChartType = SeriesChartType.Point };
        private Series sCorelationFiedClasses = new Series("Классы (кореляционное отн.)") { ChartType = SeriesChartType.Point };
        private Series sLinearRegression = new Series("Линейная регрессия") { ChartType = SeriesChartType.Point };

        public frmCA()
        {
            InitializeComponent();
            crtCorelation.Series.Add(sCorelationFied);
            crtCorelation.Series.Add(sCorelationFiedClasses);
            crtCorelation.Series.Add(sLinearRegression);
        }

        private void btnLoadTwo_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    var a = FileReader.ReadTwoFromFile(openFileDialog.FileName);
                    xData = a.Item1;
                    yData = a.Item2;
                }
                catch (FileLoadException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                FillSelectionLb(xData, lbXs);
                FillStatAnalysisGrid(xData, dgvXStaticAnalisys);

                FillSelectionLb(yData, lbYs);
                FillStatAnalysisGrid(yData, dgvYStaticAnalisys);

                FillCorelationCoeficientsGrid();
            }

            FillCorelationField();
            FillLinearRegressionSeria();
            FillRegressionScores();
        }

        private void FillLinearRegressionSeria()
        {
            sLinearRegression.Points.Clear();

            var lr = new LinearRegression(xData, yData, alpha);

            foreach (var x in xData)
            {
                var regressionValue = lr.Calculate(x);
                sLinearRegression.Points.Add(new DataPoint(x, regressionValue));
            }
        }

        private void FillRegressionScores()
        {
            var lr = new LinearRegression(xData, yData, alpha);
            dgvRegressionParamScores.DataSource = lr.Scores;
        }

        private void FillCorelationCoeficientsGrid()
        {
            dgvCorelationCoefs.Rows.Clear();

            PirsonCorelationCoef aa = new PirsonCorelationCoef(xData, yData, alpha);
            var s = aa.GetCoef();
            CorelationRelation rel = new CorelationRelation(xData, yData, alpha);
            var q = rel.GetCoef();

            SpearmanCorelationCoef sprm = new SpearmanCorelationCoef(xData, yData, alpha);
            q = sprm.GetCoef();

            KendallCorelationCoef kdl = new KendallCorelationCoef(xData, yData, alpha);
            q = kdl.GetCoef();

            var corelationCoefs = new List<CorelationCoef> { aa, rel, sprm, kdl };

            foreach(var coef in corelationCoefs)
            {
                var rowId = dgvCorelationCoefs.Rows.Add();
                dgvCorelationCoefs.Rows[rowId].Cells["dgvcName"].Value = coef.Name;
                dgvCorelationCoefs.Rows[rowId].Cells["dgvcScore"].Value = coef.GetCoef().ToString("0.#####");
                dgvCorelationCoefs.Rows[rowId].Cells["dgvcQuantil"].Value = coef.GetQuantil().ToString("0.#####");
                dgvCorelationCoefs.Rows[rowId].Cells["dgvcStatistic"].Value = coef.GetStatistic().ToString("0.#####");
                dgvCorelationCoefs.Rows[rowId].Cells["dgvcSignificance"].Value = coef.IsSignificant();
                dgvCorelationCoefs.Rows[rowId].Cells["dgvcInterval"].Value = coef.GetBelowBorder()?.ToString("0.#####") + " - " + coef.GetTopBorder()?.ToString("0.#####");
            }
        }

        private void FillChartWithClasses(List<CorelationRelationClass> classes)
        {
            sCorelationFiedClasses.Points.Clear();
            for (int i = 0; i < classes.Count; i++)
            {
                for (int j = 0; j < classes[i].Y.Count; j++)
                {
                    sCorelationFiedClasses.Points.Add(new DataPoint(classes[i].X, classes[i].Y[j]));
                }
            }
        }

        private void FillCorelationField()
        {
            sCorelationFied.Points.Clear();
            for (int i =0; i<xData.Count; i++)
            {
                sCorelationFied.Points.Add(new DataPoint(xData[i], yData[i]));
            }
        }

        private void FillSelectionLb(List<double> data, ListBox lb)
        {
            lb.Items.Clear();
            for (int i = 0; i < data.Count; i++) lb.Items.Add(data[i]);
        }

        private void FillStatAnalysisGrid(List<double> data, DataGridView dgv)
        {
            var avrgScore = StatCharacteristicModel.Average.GetAverage(data);
            var avrgDeviation = StatCharacteristicModel.Average.GetMarkDeviation(data);

            dgv.Rows.Clear();
            var rowId = dgv.Rows.Add();
            dgv.Rows[rowId].Cells[0].Value = "Середнє";
            dgv.Rows[rowId].Cells[1].Value = avrgScore.ToString("G7");
            dgv.Rows[rowId].Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(avrgScore, avrgDeviation).ToString("G7");
            dgv.Rows[rowId].Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(avrgScore, avrgDeviation).ToString("G7");

            rowId = dgv.Rows.Add();
            var sdNotSkewScore = StatCharacteristicModel.StandartDeviationNotSkew.GetValue(data);
            var sdNotSkewDeviation = StatCharacteristicModel.StandartDeviationNotSkew.GetDeviation(data);
            dgv.Rows[rowId].Cells[0].Value = "Середньоквадратичне";
            dgv.Rows[rowId].Cells[1].Value = sdNotSkewScore.ToString("G7");
            dgv.Rows[rowId].Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(sdNotSkewScore, sdNotSkewDeviation).ToString("G7");
            dgv.Rows[rowId].Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(sdNotSkewScore, sdNotSkewDeviation).ToString("G7");

            rowId = dgv.Rows.Add();
            var asymetryScore = StatCharacteristicModel.AsymmetryCoefficientNotSkew.GetValue(data);
            var asmetryDeviation = StatCharacteristicModel.AsymmetryCoefficientNotSkew.GetDeviation(data);
            dgv.Rows[rowId].Cells[0].Value = "Асиметрия";
            dgv.Rows[rowId].Cells[1].Value = asymetryScore.ToString("G7");
            dgv.Rows[rowId].Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(asymetryScore, asmetryDeviation).ToString("G7");
            dgv.Rows[rowId].Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(asymetryScore, asmetryDeviation).ToString("G7");

            rowId = dgv.Rows.Add();
            var excessScore = StatCharacteristicModel.ExcessNotSkew.GetValue(data);
            var excessDeviation = StatCharacteristicModel.ExcessNotSkew.GetDeviation(data);
            dgv.Rows[rowId].Cells[0].Value = "Ексцесс";
            dgv.Rows[rowId].Cells[1].Value = excessScore.ToString("G7");
            dgv.Rows[rowId].Cells[2].Value = StatCharacteristicModel.ConfidentialBelowBorder(excessScore, excessDeviation).ToString("G7");
            dgv.Rows[rowId].Cells[3].Value = StatCharacteristicModel.ConfidentialTopBorder(excessScore, excessDeviation).ToString("G7");
        }

    }
}