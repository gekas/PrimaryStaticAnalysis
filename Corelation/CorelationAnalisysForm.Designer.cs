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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btnLoadTwo = new System.Windows.Forms.Button();
            this.lbXs = new System.Windows.Forms.ListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.lbYs = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvXStaticAnalisys = new System.Windows.Forms.DataGridView();
            this.ScoreType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.belowBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.topBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvYStaticAnalisys = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvXStaticAnalisys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYStaticAnalisys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtCorelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorelationCoefs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegressionParamScores)).BeginInit();
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
            // dgvXStaticAnalisys
            // 
            this.dgvXStaticAnalisys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvXStaticAnalisys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ScoreType,
            this.score,
            this.belowBorder,
            this.topBorder});
            this.dgvXStaticAnalisys.Location = new System.Drawing.Point(121, 60);
            this.dgvXStaticAnalisys.Name = "dgvXStaticAnalisys";
            this.dgvXStaticAnalisys.Size = new System.Drawing.Size(494, 199);
            this.dgvXStaticAnalisys.TabIndex = 39;
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
            // dgvYStaticAnalisys
            // 
            this.dgvYStaticAnalisys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvYStaticAnalisys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvYStaticAnalisys.Location = new System.Drawing.Point(121, 292);
            this.dgvYStaticAnalisys.Name = "dgvYStaticAnalisys";
            this.dgvYStaticAnalisys.Size = new System.Drawing.Size(494, 199);
            this.dgvYStaticAnalisys.TabIndex = 40;
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
            // crtCorelation
            // 
            chartArea1.Name = "ChartArea1";
            this.crtCorelation.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.crtCorelation.Legends.Add(legend1);
            this.crtCorelation.Location = new System.Drawing.Point(633, 12);
            this.crtCorelation.Name = "crtCorelation";
            this.crtCorelation.Size = new System.Drawing.Size(539, 300);
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
            this.dgvCorelationCoefs.Location = new System.Drawing.Point(15, 498);
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
            // frmCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 874);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvRegressionParamScores);
            this.Controls.Add(this.dgvCorelationCoefs);
            this.Controls.Add(this.crtCorelation);
            this.Controls.Add(this.dgvYStaticAnalisys);
            this.Controls.Add(this.dgvXStaticAnalisys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbYs);
            this.Controls.Add(this.lbXs);
            this.Controls.Add(this.btnLoadTwo);
            this.Name = "frmCA";
            this.Text = "Кореляционный анализ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvXStaticAnalisys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvYStaticAnalisys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtCorelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorelationCoefs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegressionParamScores)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvXStaticAnalisys;
        private System.Windows.Forms.DataGridViewTextBoxColumn ScoreType;
        private System.Windows.Forms.DataGridViewTextBoxColumn score;
        private System.Windows.Forms.DataGridViewTextBoxColumn belowBorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn topBorder;
        private System.Windows.Forms.DataGridView dgvYStaticAnalisys;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
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
    }
}

