using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinearRegressionLibrary;

namespace LinearRegression
{
    public partial class PredicterForm : Form
    {
        private Fraction slope;
        private Fraction yint;
        decimal xVal;
        decimal yVal;

        public Fraction Slope
        {
            get { return slope; }
            set { slope = value; }
        }

        public Fraction YIntercept
        {
            get { return yint; }
            set { yint = value; }
        }

        public bool Is45 { get; set; }


        public PredicterForm()
        {
            InitializeComponent();
        }

        private void XValueTextBx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (trackBar1.Focused)
                {
                }
                else if (!YValueTxtBx.Focused)
                {
                        xVal = decimal.Parse(XValueTextBx.Text);
                        decimal slopeAp = (decimal)slope.Numerator / (decimal)slope.Denominator;
                        decimal intAp = (decimal)yint.Numerator / (decimal)yint.Denominator;
                        yVal = (slopeAp * xVal) + intAp;
                        YValueTxtBx.Text = String.Format("{0:F" + trackBar1.Value.ToString() + "}", yVal);
                }
            }
            catch (Exception)
            {
                if (XValueTextBx.Text == null || XValueTextBx.Text == "")
                { YValueTxtBx.Clear(); }
            }

        }

        private void YValueTxtBx_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (trackBar1.Focused)
                {
                }
                else if (!XValueTextBx.Focused)
                {
                    yVal = decimal.Parse(YValueTxtBx.Text);
                    decimal slopeApprox = (decimal)slope.Numerator / (decimal)slope.Denominator;
                    decimal yintapprox = (decimal)yint.Numerator / (decimal)yint.Denominator;
                    xVal = (yVal - yintapprox) / slopeApprox;
                    XValueTextBx.Text = String.Format("{0:F" + trackBar1.Value.ToString() + "}", xVal);
                }
            }
            catch (Exception)
            {
                if (YValueTxtBx.Text == null || YValueTxtBx.Text == "")
                { XValueTextBx.Clear(); }
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            try
            {
                    label3.Text = "Decimal Places (" + trackBar1.Value.ToString() + ")";
                    XValueTextBx.Text = String.Format("{0:F" + trackBar1.Value.ToString() + "}", xVal);
                    YValueTxtBx.Text = String.Format("{0:F" + trackBar1.Value.ToString() + "}", yVal);
            }
            catch (Exception)
            {
            }
        }

        private void XValueTextBx_Click(object sender, EventArgs e)
        {
            XValueTextBx.Focus();
        }

        private void YValueTxtBx_Click(object sender, EventArgs e)
        {
            YValueTxtBx.Focus();
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            trackBar1.Focus();
        }

        private void PredicterForm_Load(object sender, EventArgs e)
        {

        }



    }
}
