using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SH_WindowsForms_Task7
{
    public partial class PrintTask3 : Form
    {
        string s;
        string[] strings = { };
        int ArrayCounter = 0;

        public PrintTask3()
        {
            InitializeComponent();
            if (strings.Length == 0)
            {
                button3.Enabled = false;
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            float MyLines = 0;
            float YPosition = 0;
            int Counter = 0;
            string CurrentLine;
            MyLines = e.MarginBounds.Height / this.Font.GetHeight(e.Graphics);

            while (Counter < MyLines && ArrayCounter <= strings.Length - 1)
            {
                CurrentLine = strings[ArrayCounter];

                YPosition = TopMargin + Counter * this.Font.GetHeight(e.Graphics);
                e.Graphics.DrawString(CurrentLine, this.Font,

                Brushes.Black, LeftMargin, YPosition, new StringFormat());
                Counter++;
                ArrayCounter++;

            }
            if (!(ArrayCounter >= strings.GetLength(0) - 1))
                e.HasMorePages = true;
            else
                e.HasMorePages = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintForm aForm = new PrintForm();
            System.Windows.Forms.DialogResult aResult;
            aForm.printPreviewControl1.Document = printDocument1; aResult = aForm.ShowDialog();

            if (aResult == System.Windows.Forms.DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult aResult; aResult = openFileDialog1.ShowDialog();
            if (aResult == System.Windows.Forms.DialogResult.OK)
            {
                System.IO.StreamReader aReader =
                new System.IO.StreamReader(openFileDialog1.FileName); s = aReader.ReadToEnd();
                aReader.Close();
                strings = s.Split('\n');

                button3.Enabled = true;
                label1.Text = "File successfully\nloaded!";
                label1.ForeColor = Color.Green;
            }
        }
    }
}
