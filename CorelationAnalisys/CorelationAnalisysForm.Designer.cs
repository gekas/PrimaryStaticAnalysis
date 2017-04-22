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
            this.btnLoadTwo = new System.Windows.Forms.Button();
            this.lbSelection = new System.Windows.Forms.ListBox();
            this.dgvCharacteristicsSelection = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacteristicsSelection)).BeginInit();
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
            // lbSelection
            // 
            this.lbSelection.FormattingEnabled = true;
            this.lbSelection.Location = new System.Drawing.Point(12, 41);
            this.lbSelection.Name = "lbSelection";
            this.lbSelection.Size = new System.Drawing.Size(94, 199);
            this.lbSelection.TabIndex = 35;
            // 
            // dgvCharacteristicsSelection
            // 
            this.dgvCharacteristicsSelection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCharacteristicsSelection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCharacteristicsSelection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvCharacteristicsSelection.Location = new System.Drawing.Point(131, 41);
            this.dgvCharacteristicsSelection.Name = "dgvCharacteristicsSelection";
            this.dgvCharacteristicsSelection.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCharacteristicsSelection.Size = new System.Drawing.Size(597, 221);
            this.dgvCharacteristicsSelection.TabIndex = 36;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Оценка характеристики";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Среднеквадратическое отклонение оценки";
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
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // frmCA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 660);
            this.Controls.Add(this.dgvCharacteristicsSelection);
            this.Controls.Add(this.lbSelection);
            this.Controls.Add(this.btnLoadTwo);
            this.Name = "frmCA";
            this.Text = "Кореляционный анализ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCharacteristicsSelection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadTwo;
        private System.Windows.Forms.ListBox lbSelection;
        private System.Windows.Forms.DataGridView dgvCharacteristicsSelection;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

