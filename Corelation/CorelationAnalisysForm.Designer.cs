namespace CorelationAnalisys
{
    partial class frmCA
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btnLoadTwo = new System.Windows.Forms.Button();
            this.lbXs = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbYs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.crtCorelation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvCorelationCoefs = new System.Windows.Forms.DataGridView();
            this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcStatistic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcQuantil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcSignificance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcInterval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvRegressionParamScores = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvFtest = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvcDetermCoef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcStatisticDeterm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcQuantilFisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvcIsDetermCoefSignificant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvYStaticAnalisys = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvXStaticAnalisys = new System.Windows.Forms.DataGridView();
            this.ScoreType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.belowBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crtResidualPlot = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.crtCorelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorelationCoefs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegressionParamScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFtest)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYStaticAnalisys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXStaticAnalisys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtResidualPlot)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadTwo
            // 
            this.btnLoadTwo.Location = new System.Drawing.Point(12, 12);
            this.btnLoadTwo.Name = "btnLoadTwo";
            this.btnLoadTwo.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTwo.TabIndex = 1;
            this.btnLoadTwo.Text = "Load";
            this.btnLoadTwo.UseVisualStyleBackColor = true;
            this.btnLoadTwo.Click += new System.EventHandler(this.btnLoadTwo_Click);
            // 
            // lbXs
            // 
            this.lbXs.FormattingEnabled = true;
            this.lbXs.Location = new System.Drawing.Point(12, 60);
            this.lbXs.Name = "lbXs";
            this.lbXs.Size = new System.Drawing.Size(94, 199);
            this.lbXs.TabIndex = 35;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // lbYs
            // 
            this.lbYs.FormattingEnabled = true;
            this.lbYs.Location = new System.Drawing.Point(15, 292);
            this.lbYs.Name = "lbYs";
            this.lbYs.Size = new System.Drawing.Size(94, 199);
            this.lbYs.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Y:";
            // 
            // crtCorelation
            // 
            chartArea7.Name = "ChartArea1";
            this.crtCorelation.ChartAreas.Add(chartArea7);
            this.crtCorelation.Dock = System.Windows.Forms.DockStyle.Right;
            legend7.Name = "Legend1";
            this.crtCorelation.Legends.Add(legend7);
            this.crtCorelation.Location = new System.Drawing.Point(769, 0);
            this.crtCorelation.Name = "crtCorelation";
            this.crtCorelation.Size = new System.Drawing.Size(1133, 1085);
            this.crtCorelation.TabIndex = 41;
            this.crtCorelation.Text = "chart1";
            // 
            // dgvCorelationCoefs
            // 
            this.dgvCorelationCoefs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorelationCoefs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcName,
            this.dgvcScore,
            this.dgvcStatistic,
            this.dgvcQuantil,
            this.dgvcSignificance,
            this.dgvcInterval});
            this.dgvCorelationCoefs.Location = new System.Drawing.Point(15, 525);
            this.dgvCorelationCoefs.Name = "dgvCorelationCoefs";
            this.dgvCorelationCoefs.Size = new System.Drawing.Size(719, 150);
            this.dgvCorelationCoefs.TabIndex = 42;
            // 
            // dgvcName
            // 
            this.dgvcName.HeaderText = "";
            this.dgvcName.Name = "dgvcName";
            this.dgvcName.Width = 175;
            // 
            // dgvcScore
            // 
            this.dgvcScore.HeaderText = "Оценка";
            this.dgvcScore.Name = "dgvcScore";
            // 
            // dgvcStatistic
            // 
            this.dgvcStatistic.HeaderText = "Статистика";
            this.dgvcStatistic.Name = "dgvcStatistic";
            // 
            // dgvcQuantil
            // 
            this.dgvcQuantil.HeaderText = "Квантиль";
            this.dgvcQuantil.Name = "dgvcQuantil";
            // 
            // dgvcSignificance
            // 
            this.dgvcSignificance.HeaderText = "Значимость";
            this.dgvcSignificance.Name = "dgvcSignificance";
            // 
            // dgvcInterval
            // 
            this.dgvcInterval.HeaderText = "Дов.интервал";
            this.dgvcInterval.Name = "dgvcInterval";
            // 
            // dgvRegressionParamScores
            // 
            this.dgvRegressionParamScores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegressionParamScores.Location = new System.Drawing.Point(15, 701);
            this.dgvRegressionParamScores.Name = "dgvRegressionParamScores";
            this.dgvRegressionParamScores.Size = new System.Drawing.Size(719, 150);
            this.dgvRegressionParamScores.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 682);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Оценки параметров:";
            // 
            // dgvFtest
            // 
            this.dgvFtest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFtest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcDetermCoef,
            this.dgvcStatisticDeterm,
            this.dgvcQuantilFisher,
            this.dgvcIsDetermCoefSignificant});
            this.dgvFtest.Location = new System.Drawing.Point(13, 887);
            this.dgvFtest.Name = "dgvFtest";
            this.dgvFtest.Size = new System.Drawing.Size(465, 56);
            this.dgvFtest.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 871);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "F-тест:";
            // 
            // dgvcDetermCoef
            // 
            this.dgvcDetermCoef.HeaderText = "R^2";
            this.dgvcDetermCoef.Name = "dgvcDetermCoef";
            // 
            // dgvcStatisticDeterm
            // 
            this.dgvcStatisticDeterm.HeaderText = "Статистика";
            this.dgvcStatisticDeterm.Name = "dgvcStatisticDeterm";
            // 
            // dgvcQuantilFisher
            // 
            this.dgvcQuantilFisher.HeaderText = "Квантиль";
            this.dgvcQuantilFisher.Name = "dgvcQuantilFisher";
            // 
            // dgvcIsDetermCoefSignificant
            // 
            this.dgvcIsDetermCoefSignificant.HeaderText = "Значимость";
            this.dgvcIsDetermCoefSignificant.Name = "dgvcIsDetermCoefSignificant";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(121, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(613, 479);
            this.tabControl1.TabIndex = 49;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvYStaticAnalisys);
            this.tabPage1.Controls.Add(this.dgvXStaticAnalisys);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(605, 453);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Анализ выборок";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.crtResidualPlot);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(605, 453);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Дигностическая диаграмма";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvYStaticAnalisys
            // 
            this.dgvYStaticAnalisys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYStaticAnalisys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvYStaticAnalisys.Location = new System.Drawing.Point(43, 243);
            this.dgvYStaticAnalisys.Name = "dgvYStaticAnalisys";
            this.dgvYStaticAnalisys.Size = new System.Drawing.Size(494, 199);
            this.dgvYStaticAnalisys.TabIndex = 42;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.FillWeight = 150F;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Оценка";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Нижняя граница";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Верхняя граница";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dgvXStaticAnalisys
            // 
            this.dgvXStaticAnalisys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXStaticAnalisys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScoreType,
            this.score,
            this.belowBorder,
            this.topBorder});
            this.dgvXStaticAnalisys.Location = new System.Drawing.Point(43, 16);
            this.dgvXStaticAnalisys.Name = "dgvXStaticAnalisys";
            this.dgvXStaticAnalisys.Size = new System.Drawing.Size(494, 199);
            this.dgvXStaticAnalisys.TabIndex = 41;
            // 
            // ScoreType
            // 
            this.ScoreType.FillWeight = 150F;
            this.ScoreType.HeaderText = "";
            this.ScoreType.Name = "ScoreType";
            this.ScoreType.Width = 150;
            // 
            // score
            // 
            this.score.HeaderText = "Оценка";
            this.score.Name = "score";
            // 
            // belowBorder
            // 
            this.belowBorder.HeaderText = "Нижняя граница";
            this.belowBorder.Name = "belowBorder";
            // 
            // topBorder
            // 
            this.topBorder.HeaderText = "Верхняя граница";
            this.topBorder.Name = "topBorder";
            // 
            // crtResidualPlot
            // 
            chartArea8.Name = "ChartArea1";
            this.crtResidualPlot.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.crtResidualPlot.Legends.Add(legend8);
            this.crtResidualPlot.Location = new System.Drawing.Point(0, 3);
            this.crtResidualPlot.Name = "crtResidualPlot";
            this.crtResidualPlot.Size = new System.Drawing.Size(605, 450);
            this.crtResidualPlot.TabIndex = 0;
            this.crtResidualPlot.Text = "chart1";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Линейная",
            "Нелинейная"});
            this.comboBox1.Location = new System.Drawing.Point(15, 498);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 50;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1085);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvFtest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvRegressionParamScores);
            this.Controls.Add(this.dgvCorelationCoefs);
            this.Controls.Add(this.crtCorelation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbYs);
            this.Controls.Add(this.lbXs);
            this.Controls.Add(this.btnLoadTwo);
            this.Name = "frmCA";
            this.Text = "Кореляционный анализ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.crtCorelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorelationCoefs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegressionParamScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFtest)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvYStaticAnalisys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvXStaticAnalisys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtResidualPlot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadTwo;
        private System.Windows.Forms.ListBox lbXs;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox lbYs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtCorelation;
        private System.Windows.Forms.DataGridView dgvCorelationCoefs;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcStatistic;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcQuantil;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcSignificance;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcInterval;
        private System.Windows.Forms.DataGridView dgvRegressionParamScores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvFtest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDetermCoef;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcStatisticDeterm;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcQuantilFisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvcIsDetermCoefSignificant;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgvYStaticAnalisys;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridView dgvXStaticAnalisys;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreType;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn belowBorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn topBorder;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtResidualPlot;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

