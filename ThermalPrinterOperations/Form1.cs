using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThermalPrinterOperations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PrintDocument pd = new PrintDocument();


        public void PrintReceipt()
        {
            try
            {
                pd.PrintPage += Pd_PrintPage;
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            // if thermal printer's width 58 mm we must set to maximum 220 pixel in program 

            if (txtFirmName.Text != null && txtFirmName.Text != "" && txtName.Text != null && txtName.Text != "" && txtSurname.Text != null && txtSurname.Text != "" && txtCareer.Text != null && txtCareer.Text != "" && txtProductName.Text != null && txtProductName.Text != "" && txtAmount.Text != null && txtAmount.Text != "" && txtPrice.Text != null && txtPrice.Text != "" && txtTotal.Text != null && txtTotal.Text != "")
            {
                int paperHeight = 120;
                PaperSize ps58 = new PaperSize("58mm Thermal", 220, paperHeight + 120);
                pd.DefaultPageSettings.PaperSize = ps58;

                Font fontHeader = new Font("Calibri", 10, FontStyle.Bold);
                Font fontInfo = new Font("Calibri", 8, FontStyle.Bold);
                Font fontcontentHeader = new Font("Calibri", 8, FontStyle.Underline);
                StringFormat center = new StringFormat(StringFormatFlags.FitBlackBox);
                center.Alignment = StringAlignment.Center;
                RectangleF rcFirmNameLocation = new RectangleF(0, 20, 220, 20); // (int x, int y, float width, float height)
                // e.Graphics.DrawString("abc", fontHeader, Brushes.Black, new Point(5, 5));
                e.Graphics.DrawString(txtFirmName.Text, fontHeader, Brushes.Black, rcFirmNameLocation, center);
                e.Graphics.DrawString("Name       : " + txtName.Text, fontInfo, Brushes.Black, new Point(5, 45));
                e.Graphics.DrawString("Surname : " + txtSurname.Text, fontInfo, Brushes.Black, new Point(5, 60));
                e.Graphics.DrawString("Career      : " + txtCareer.Text, fontInfo, Brushes.Black, new Point(5, 75));
                e.Graphics.DrawString("------------------------------------------------------------", fontInfo, Brushes.Black, new Point(5, 90));

                e.Graphics.DrawString("Product 1", fontcontentHeader, Brushes.Black, new Point(5, 105));
                e.Graphics.DrawString("Amount", fontcontentHeader, Brushes.Black, new Point(100, 105));
                e.Graphics.DrawString("Price", fontcontentHeader, Brushes.Black, new Point(140, 105));
                e.Graphics.DrawString("Total", fontcontentHeader, Brushes.Black, new Point(180, 105));
                              

                e.Graphics.DrawString(txtProductName.Text, fontInfo, Brushes.Black, new Point(5, paperHeight));
                e.Graphics.DrawString(txtAmount.Text, fontInfo, Brushes.Black, new Point(115, paperHeight));
                e.Graphics.DrawString(Convert.ToDouble(txtPrice.Text).ToString("C2"), fontInfo, Brushes.Black, new Point(140, paperHeight));
                e.Graphics.DrawString(Convert.ToDouble(txtTotal.Text).ToString("C2"), fontInfo, Brushes.Black, new Point(180, paperHeight));  // ("C2") -> Money Format -> ₺ 
                paperHeight += 15;

                e.Graphics.DrawString("------------------------------------------------------------", fontInfo, Brushes.Black, new Point(5, paperHeight));
                e.Graphics.DrawString("TOTAL : " + Convert.ToDouble(txtTotal.Text).ToString("C2"), fontHeader, Brushes.Black, new Point(5, paperHeight + 20));
                e.Graphics.DrawString("------------------------------------------------------------", fontInfo, Brushes.Black, new Point(5, paperHeight + 40));
                e.Graphics.DrawString("(Has No Financial Value)", fontInfo, Brushes.Black, new Point(5, paperHeight + 60));
                // Some of the Thermal Printers also have a cutting process. Codes can be added.                
            }
        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            PrintReceipt();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
