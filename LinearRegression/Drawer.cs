using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LinearRegressionLibrary;

namespace LinearRegression
{
    public partial class Drawer : UserControl
    {

        public Fraction Slope { get; set; }
        public string SlopeString { get; set; }
        public string YInterceptString { get; set; }
        public string EquationString { get; set; }
        public List<int[]> Points { get; set; }
        public Fraction YIntercept { get; set; }
        public bool Is45 { get; set; }
        public Drawer()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;
        }

        private void GraphPBox_Click(object sender, EventArgs e)
        {
            try
            {
                using (Graphing.GraphingWindow Graphing = new Graphing.GraphingWindow(SlopeString, YInterceptString, Points, EquationString))
                {
                    Graphing.ShowDialog(this);
                    Graphing.TopMost = true;
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There is no graph");
            }
        }

        private void PredPBox_Click(object sender, EventArgs e)
        {
            PredicterForm p = new PredicterForm();
            p.Slope = this.Slope;
            p.YIntercept = this.YIntercept;
            p.Is45 = this.Is45;
            p.ShowDialog();
        }

        private void Drawer_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
        }


    }
}
