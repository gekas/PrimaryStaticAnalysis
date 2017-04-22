using PrimaryStaticAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils;

namespace CorelationAnalisys
{
    public partial class frmCA : Form
    {
        List<double> data = new List<double>();
        public frmCA()
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
                    var a = FileReader.ReadFromFile(openFileDialog.FileName);
                    data = a;
                }
                catch (FileLoadException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                FillSelectionLb(data, lbSelection);
                MainForm.FillCharacteristicsGrid(data, dgvCharacteristicsSelection);              
            }
        }

        private void FillSelectionLb(List<double> data, ListBox lb)
        {
            lbSelection.Items.Clear();
            for (int i = 0; i < data.Count; i++) lb.Items.Add(data[i]);
        }
    }
}