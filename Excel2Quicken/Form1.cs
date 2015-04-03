using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Excel2Quicken
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void excelBrowseButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Excel Files (*.xlsx;*.xls)|*.xlsx;*.xls";
            openFileDialog.CheckPathExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.excelTextBox.Text = openFileDialog.FileName;
            }

            this.SetConvertEnabled();
        }

        private void quickenBrowseButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Quicken Import Files (*.qif)|*.qif";
            saveFileDialog.CheckPathExists = false;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.quickenTextBox.Text = saveFileDialog.FileName;
            }

            this.SetConvertEnabled();
        }

        private void SetConvertEnabled()
        {
            this.convertButton.Enabled = !string.IsNullOrWhiteSpace(this.excelTextBox.Text)
                                         && !string.IsNullOrWhiteSpace(this.quickenTextBox.Text);
        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            ExcelMap excelMap;
            IEnumerable<Transaction> transactions;

            try
            {
                var excelMapXmlReader = new ExcelMapXmlReader();
                excelMap = excelMapXmlReader.LoadExcelMap("ExcelMap.xml");
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Error loading application configrations." + Environment.NewLine + "Details: " + exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            try
            {
                var excelReader = new ExcelReader();
                transactions =
                    excelReader.ReadTransactions(this.excelTextBox.Text, excelMap);
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Error processing the selected Excel workbook." + Environment.NewLine + "Details: " + exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            try
            {
                var quickenWriter = new QuickenWriter();
                quickenWriter.WriteTransaction(transactions, this.quickenTextBox.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show(
                    "Error writing transaction to the Quicken file." + Environment.NewLine + "Details: " + exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show("The Quicken file was saved.", "Success", MessageBoxButtons.OK);
        }

    }
}
