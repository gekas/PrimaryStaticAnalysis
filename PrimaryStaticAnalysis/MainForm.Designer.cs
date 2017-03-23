﻿namespace PrimaryStaticAnalysis
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnLoad = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gvVariationRow = new System.Windows.Forms.DataGridView();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelativeFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cumFreq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistributionFunction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStegesClassesCount = new System.Windows.Forms.Label();
            this.gvIntervalVariationRow = new System.Windows.Forms.DataGridView();
            this.Interval = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelFreq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cummulatedFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DispFunc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nudIntervalsCount = new System.Windows.Forms.NumericUpDown();
            this.btnRefreshIntervalVariationRow = new System.Windows.Forms.Button();
            this.crtIntervalRow = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.crtEmpericalFunction = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvCharacteristics = new System.Windows.Forms.DataGridView();
            this.Mark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvrgDeviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BelowBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TopBorder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAnomals = new System.Windows.Forms.ListBox();
            this.btnDeleteAnomals = new System.Windows.Forms.Button();
            this.btnFindAnomal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbY2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbY1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gvVariationRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIntervalVariationRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalsCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtIntervalRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtEmpericalFunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacteristics)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(13, 13);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // gvVariationRow
            // 
            this.gvVariationRow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvVariationRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvVariationRow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Value,
            this.Frequency,
            this.RelativeFrequency,
            this.cumFreq,
            this.DistributionFunction});
            this.gvVariationRow.Location = new System.Drawing.Point(12, 69);
            this.gvVariationRow.MultiSelect = false;
            this.gvVariationRow.Name = "gvVariationRow";
            this.gvVariationRow.ReadOnly = true;
            this.gvVariationRow.RowHeadersWidth = 50;
            this.gvVariationRow.Size = new System.Drawing.Size(471, 150);
            this.gvVariationRow.TabIndex = 1;
            // 
            // Value
            // 
            this.Value.HeaderText = "Значення";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Frequency
            // 
            this.Frequency.HeaderText = "Частота";
            this.Frequency.Name = "Frequency";
            this.Frequency.ReadOnly = true;
            // 
            // RelativeFrequency
            // 
            this.RelativeFrequency.HeaderText = "Відносна частота";
            this.RelativeFrequency.Name = "RelativeFrequency";
            this.RelativeFrequency.ReadOnly = true;
            // 
            // cumFreq
            // 
            this.cumFreq.HeaderText = "Накопленная частота";
            this.cumFreq.Name = "cumFreq";
            this.cumFreq.ReadOnly = true;
            // 
            // DistributionFunction
            // 
            this.DistributionFunction.HeaderText = "Функція розподілу";
            this.DistributionFunction.Name = "DistributionFunction";
            this.DistributionFunction.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Варіаційний ряд";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Інтервальний варіаційний ряд";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Кількість класів за функцією Стерджесса:";
            // 
            // lblStegesClassesCount
            // 
            this.lblStegesClassesCount.AutoSize = true;
            this.lblStegesClassesCount.Location = new System.Drawing.Point(243, 257);
            this.lblStegesClassesCount.Name = "lblStegesClassesCount";
            this.lblStegesClassesCount.Size = new System.Drawing.Size(0, 13);
            this.lblStegesClassesCount.TabIndex = 5;
            // 
            // gvIntervalVariationRow
            // 
            this.gvIntervalVariationRow.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvIntervalVariationRow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvIntervalVariationRow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Interval,
            this.Freq,
            this.RelFreq,
            this.cummulatedFrequency,
            this.DispFunc});
            this.gvIntervalVariationRow.Location = new System.Drawing.Point(12, 286);
            this.gvIntervalVariationRow.MultiSelect = false;
            this.gvIntervalVariationRow.Name = "gvIntervalVariationRow";
            this.gvIntervalVariationRow.ReadOnly = true;
            this.gvIntervalVariationRow.RowHeadersWidth = 50;
            this.gvIntervalVariationRow.Size = new System.Drawing.Size(471, 150);
            this.gvIntervalVariationRow.TabIndex = 6;
            // 
            // Interval
            // 
            this.Interval.HeaderText = "Інтервал";
            this.Interval.Name = "Interval";
            this.Interval.ReadOnly = true;
            // 
            // Freq
            // 
            this.Freq.HeaderText = "Частота";
            this.Freq.Name = "Freq";
            this.Freq.ReadOnly = true;
            // 
            // RelFreq
            // 
            this.RelFreq.HeaderText = "Відносна частота";
            this.RelFreq.Name = "RelFreq";
            this.RelFreq.ReadOnly = true;
            // 
            // cummulatedFrequency
            // 
            this.cummulatedFrequency.HeaderText = "Накопленная частота";
            this.cummulatedFrequency.Name = "cummulatedFrequency";
            this.cummulatedFrequency.ReadOnly = true;
            // 
            // DispFunc
            // 
            this.DispFunc.HeaderText = "Функція розподілу";
            this.DispFunc.Name = "DispFunc";
            this.DispFunc.ReadOnly = true;
            // 
            // nudIntervalsCount
            // 
            this.nudIntervalsCount.Location = new System.Drawing.Point(12, 444);
            this.nudIntervalsCount.Name = "nudIntervalsCount";
            this.nudIntervalsCount.Size = new System.Drawing.Size(76, 20);
            this.nudIntervalsCount.TabIndex = 7;
            // 
            // btnRefreshIntervalVariationRow
            // 
            this.btnRefreshIntervalVariationRow.Location = new System.Drawing.Point(95, 442);
            this.btnRefreshIntervalVariationRow.Name = "btnRefreshIntervalVariationRow";
            this.btnRefreshIntervalVariationRow.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshIntervalVariationRow.TabIndex = 8;
            this.btnRefreshIntervalVariationRow.TabStop = false;
            this.btnRefreshIntervalVariationRow.Text = "OK";
            this.btnRefreshIntervalVariationRow.UseVisualStyleBackColor = true;
            this.btnRefreshIntervalVariationRow.Click += new System.EventHandler(this.btnRefreshIntervalVariationRow_Click);
            // 
            // crtIntervalRow
            // 
            chartArea1.Name = "ChartArea1";
            this.crtIntervalRow.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.crtIntervalRow.Legends.Add(legend1);
            this.crtIntervalRow.Location = new System.Drawing.Point(508, 233);
            this.crtIntervalRow.Name = "crtIntervalRow";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "Частота";
            series1.MarkerSize = 1;
            series1.Name = "Frequency";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Legend = "Legend1";
            series2.LegendText = "Плотность в-и";
            series2.Name = "ProbabilityDensity";
            this.crtIntervalRow.Series.Add(series1);
            this.crtIntervalRow.Series.Add(series2);
            this.crtIntervalRow.Size = new System.Drawing.Size(407, 203);
            this.crtIntervalRow.TabIndex = 9;
            this.crtIntervalRow.Text = "chart1";
            // 
            // crtEmpericalFunction
            // 
            chartArea2.Name = "ChartArea1";
            this.crtEmpericalFunction.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.crtEmpericalFunction.Legends.Add(legend2);
            this.crtEmpericalFunction.Location = new System.Drawing.Point(508, 41);
            this.crtEmpericalFunction.Name = "crtEmpericalFunction";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series3.Legend = "Legend1";
            series3.Name = "Emperical";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StepLine;
            series4.Legend = "Legend1";
            series4.LegendText = "Ф-я распр-я";
            series4.Name = "Density";
            this.crtEmpericalFunction.Series.Add(series3);
            this.crtEmpericalFunction.Series.Add(series4);
            this.crtEmpericalFunction.Size = new System.Drawing.Size(407, 178);
            this.crtEmpericalFunction.TabIndex = 10;
            this.crtEmpericalFunction.Text = "chart1";
            // 
            // dgvCharacteristics
            // 
            this.dgvCharacteristics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCharacteristics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharacteristics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Mark,
            this.AvrgDeviation,
            this.BelowBorder,
            this.TopBorder});
            this.dgvCharacteristics.Location = new System.Drawing.Point(318, 479);
            this.dgvCharacteristics.Name = "dgvCharacteristics";
            this.dgvCharacteristics.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCharacteristics.Size = new System.Drawing.Size(597, 221);
            this.dgvCharacteristics.TabIndex = 11;
            // 
            // Mark
            // 
            this.Mark.HeaderText = "Оценка характеристики";
            this.Mark.Name = "Mark";
            // 
            // AvrgDeviation
            // 
            this.AvrgDeviation.HeaderText = "Среднеквадратическое отклонение оценки";
            this.AvrgDeviation.Name = "AvrgDeviation";
            // 
            // BelowBorder
            // 
            this.BelowBorder.HeaderText = "Нижняя граница";
            this.BelowBorder.Name = "BelowBorder";
            // 
            // TopBorder
            // 
            this.TopBorder.HeaderText = "Верхняя граница";
            this.TopBorder.Name = "TopBorder";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAnomals);
            this.groupBox1.Controls.Add(this.btnDeleteAnomals);
            this.groupBox1.Controls.Add(this.btnFindAnomal);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbY2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbY1);
            this.groupBox1.Location = new System.Drawing.Point(12, 479);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 154);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Аномальные значения";
            // 
            // lbAnomals
            // 
            this.lbAnomals.FormattingEnabled = true;
            this.lbAnomals.Location = new System.Drawing.Point(7, 19);
            this.lbAnomals.Name = "lbAnomals";
            this.lbAnomals.Size = new System.Drawing.Size(101, 121);
            this.lbAnomals.TabIndex = 6;
            // 
            // btnDeleteAnomals
            // 
            this.btnDeleteAnomals.Location = new System.Drawing.Point(204, 94);
            this.btnDeleteAnomals.Name = "btnDeleteAnomals";
            this.btnDeleteAnomals.Size = new System.Drawing.Size(75, 46);
            this.btnDeleteAnomals.TabIndex = 5;
            this.btnDeleteAnomals.Text = "Удалить";
            this.btnDeleteAnomals.UseVisualStyleBackColor = true;
            this.btnDeleteAnomals.Click += new System.EventHandler(this.btnDeleteAnomals_Click);
            // 
            // btnFindAnomal
            // 
            this.btnFindAnomal.Location = new System.Drawing.Point(123, 94);
            this.btnFindAnomal.Name = "btnFindAnomal";
            this.btnFindAnomal.Size = new System.Drawing.Size(75, 46);
            this.btnFindAnomal.TabIndex = 4;
            this.btnFindAnomal.Text = "Найти";
            this.btnFindAnomal.UseVisualStyleBackColor = true;
            this.btnFindAnomal.Click += new System.EventHandler(this.btnFindAnomal_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(139, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "γ2";
            // 
            // tbY2
            // 
            this.tbY2.Location = new System.Drawing.Point(173, 48);
            this.tbY2.Name = "tbY2";
            this.tbY2.Size = new System.Drawing.Size(75, 20);
            this.tbY2.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(139, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "γ1";
            // 
            // tbY1
            // 
            this.tbY1.Location = new System.Drawing.Point(173, 16);
            this.tbY1.Name = "tbY1";
            this.tbY1.Size = new System.Drawing.Size(75, 20);
            this.tbY1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 716);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCharacteristics);
            this.Controls.Add(this.crtEmpericalFunction);
            this.Controls.Add(this.crtIntervalRow);
            this.Controls.Add(this.btnRefreshIntervalVariationRow);
            this.Controls.Add(this.nudIntervalsCount);
            this.Controls.Add(this.gvIntervalVariationRow);
            this.Controls.Add(this.lblStegesClassesCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gvVariationRow);
            this.Controls.Add(this.btnLoad);
            this.Name = "MainForm";
            this.Text = "Primary static analysis";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvVariationRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvIntervalVariationRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervalsCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtIntervalRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crtEmpericalFunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacteristics)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.DataGridView gvVariationRow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStegesClassesCount;
        private System.Windows.Forms.DataGridView gvIntervalVariationRow;
        private System.Windows.Forms.NumericUpDown nudIntervalsCount;
        private System.Windows.Forms.Button btnRefreshIntervalVariationRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelativeFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn cumFreq;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistributionFunction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interval;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freq;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelFreq;
        private System.Windows.Forms.DataGridViewTextBoxColumn cummulatedFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn DispFunc;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtIntervalRow;
        private System.Windows.Forms.DataVisualization.Charting.Chart crtEmpericalFunction;
        private System.Windows.Forms.DataGridView dgvCharacteristics;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mark;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvrgDeviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn BelowBorder;
        private System.Windows.Forms.DataGridViewTextBoxColumn TopBorder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbY1;
        private System.Windows.Forms.Button btnDeleteAnomals;
        private System.Windows.Forms.Button btnFindAnomal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbY2;
        private System.Windows.Forms.ListBox lbAnomals;
    }
}

