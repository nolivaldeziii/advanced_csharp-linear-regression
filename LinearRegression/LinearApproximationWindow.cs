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
    public partial class LinearApproximationWindow : Form
    {
        public Fraction ExactSlope { get; set;}
        public Fraction ExactYIntercept { get; set; }
        bool opened = false;
        bool wasError = true;
        bool wasSimple = false;
        private Point lastClick;
        bool DisableBGControls = false;
        //Graph
        string fault;
        List<int[]> UserInput;
        Graphing.GraphingWindow Graphing;
        //

        Operations operations = new Operations();
        public LinearApproximationWindow()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            var pos = this.PointToScreen(AboutLbl.Location);
            pos = pictureBox2.PointToClient(pos);
            AboutLbl.Parent = pictureBox2;
            AboutLbl.Location = pos;
            AboutLbl.BackColor = Color.Transparent;
        }
        private void LinearApproximationWindow_Load(object sender, EventArgs e)
        {
            TrackBarSlider.Enabled = DecimalPlacesLbl.Enabled = ApproximateValueRdoBtn.Checked;
        }
        private void ComputeBtn_Click(object sender, EventArgs e)
        {
            if (!DisableBGControls)
            {
                if (ApproximateValueRdoBtn.Checked)
                    Compute(TrackBarSlider.Value);
                else
                    Compute();
            }
        }

        public List<int[]> CleanUp(List<int[]> toCleans)
        {
            List<int[]> toClean = toCleans;
            int index = 0;
            while (index < toClean.Count - 1)
            {
                if (toClean[index][0] == toClean[index + 1][0] && toClean[index][1] == toClean[index + 1][1])
                {
                    toClean.RemoveAt(index);
                }
                else
                    index++;
            }
            return toClean;

        }
        public void Compute(int decimalPlaces)
        {
            List<int[]> vals = new List<int[]>();
            try
            {

                int ctr = 0;
                foreach (DataGridViewRow row in XYGridView.Rows)
                {

                    int[] temp = new int[2];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        temp[ctr] = Convert.ToInt32(cell.Value);
                        ctr++;
                    }
                    vals.Add(temp);
                    ctr = 0;
                }

                vals.RemoveAt(vals.ToArray().Length - 1);
                vals = CleanUp(vals);
                UserInput = vals;

                if (operations.IsJustEqual(vals))
                    throw new IsJustEqualException();
                if (operations.IsVertical(vals))
                    throw new IsVerticalException();
                if (operations.isHorizontal(vals))
                    throw new IsHorizontalException();
                if (operations.Is45Degrees(vals))
                    throw new Is45Degrees();


                //string slope = "";
                //string yIntercept = "";



                int[,] OneXArr = operations.XPoints(vals);
                int[,] YArr = operations.YPoints(vals);


                int[,] XProduct = operations.MultiplyMatrix(operations.TransposeMatrix(OneXArr), OneXArr);
                int[,] YProduct = operations.MultiplyMatrix(operations.TransposeMatrix(OneXArr), YArr);

                int[,] pseudoInverse = operations.GetPseudoInverse(XProduct);
                int[,] pseudoProduct = operations.MultiplyMatrix(pseudoInverse, YProduct);


                double[,] finalResultApprox = new double[2, 1];

                finalResultApprox[0, 0] = operations.ApproximateFraction(new Fraction(pseudoProduct[1, 0], operations.GetDeterminant(XProduct)), decimalPlaces);
                finalResultApprox[1, 0] = operations.ApproximateFraction(new Fraction(pseudoProduct[0, 0], operations.GetDeterminant(XProduct)), decimalPlaces);

                SlopeTxtBx.Text = finalResultApprox[0, 0].ToString();
                YInterceptTxtBx.Text = finalResultApprox[1, 0].ToString();


                EquationTxtBx.Text = String.Concat("y = ", finalResultApprox[0, 0].ToString(), "x + ", finalResultApprox[1, 0].ToString());
                wasError = false;
                wasSimple = false;
            }
            catch (IsJustEqualException)
            {
                EquationTxtBx.Text = "No line!";
                wasError = true;
            }
            catch (IsVerticalException)
            {
                int[] toPass = null;
                foreach (int[] v in vals)
                {
                    if (v[0] != 0 && v[1] != 0)
                        toPass = v;

                }
                SlopeTxtBx.Text = "0";
                SlopeTxtBx.Text = "undefined";
                YInterceptTxtBx.Text = "none";
                EquationTxtBx.Text = "x = " + toPass[0].ToString();
                wasSimple = true;

                fault = vals[0][0].ToString();
            }
            catch (IsHorizontalException)
            {
                int[] toPass = null;
                foreach (int[] v in vals)
                {
                    if (v[0] != 0 && v[1] != 0)
                        toPass = v;

                }
                SlopeTxtBx.Text = "0";
                SlopeTxtBx.Text = "0";
                YInterceptTxtBx.Text = toPass[1].ToString();
                EquationTxtBx.Text = "y = " + toPass[1].ToString();
                wasSimple = true;
            }
            catch (Is45Degrees)
            {
                int[] toPass = null;
                foreach (int[] v in vals)
                {
                    if (v[0] != 0 && v[1] != 0)
                        toPass = v;

                }
                object[] res = operations.Collinear(toPass[0], toPass[1]);
                SlopeTxtBx.Text = res[0].ToString();
                YInterceptTxtBx.Text = res[1].ToString();
                try
                {
                    EquationTxtBx.Text = Math.Sign((int)res[0]).ToString() + "x = y";
                }
                catch { }// trust me i'm an engineer
                wasSimple = true;
            }
            catch (DeterminantIsZero)
            {
                EquationTxtBx.Text = "Cant' Solve";
                wasError = true;
            }
            catch (OutOfMemoryException)
            {
                EquationTxtBx.Text = "Cant' Solve";
                wasError = true;
            }
            catch (Exception ex)
            {
                EquationTxtBx.Text = ex.Message;
                wasError = true;
            }


        }
        public void Compute()
        {
            List<int[]> vals = new List<int[]>();
            try
            {

                int ctr = 0;
                foreach (DataGridViewRow row in XYGridView.Rows)
                {

                    int[] temp = new int[2];
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        temp[ctr] = Convert.ToInt32(cell.Value);
                        ctr++;
                    }
                    vals.Add(temp);
                    ctr = 0;
                }

                vals.RemoveAt(vals.ToArray().Length - 1);
                vals = CleanUp(vals);
                UserInput = vals;
                if (operations.IsJustEqual(vals))
                    throw new IsJustEqualException();
                if (operations.IsVertical(vals))
                    throw new IsVerticalException();
                if (operations.isHorizontal(vals))
                    throw new IsHorizontalException();
                if (operations.Is45Degrees(vals))
                    throw new Is45Degrees();


                string slope = "";
                string yIntercept = "";


                int[,] OneXArr = operations.XPoints(vals);
                int[,] YArr = operations.YPoints(vals);


                int[,] XProduct = operations.MultiplyMatrix(operations.TransposeMatrix(OneXArr), OneXArr);
                int[,] YProduct = operations.MultiplyMatrix(operations.TransposeMatrix(OneXArr), YArr);

                int[,] pseudoInverse = operations.GetPseudoInverse(XProduct);
                int[,] pseudoProduct = operations.MultiplyMatrix(pseudoInverse, YProduct);

                slope = operations.ExactFraction(pseudoProduct[1, 0], operations.GetDeterminant(XProduct));
                yIntercept = operations.ExactFraction(pseudoProduct[0, 0], operations.GetDeterminant(XProduct));

                ExactSlope = new Fraction(int.Parse(slope.Split('/')[0]), int.Parse(slope.Split('/')[1]));
                ExactYIntercept = new Fraction(int.Parse(yIntercept.Split('/')[0]), int.Parse(yIntercept.Split('/')[1]));

                if (slope.EndsWith("/1"))
                {
                    string[] temp = slope.Split('/');
                    slope = temp[0];
                }
                if (yIntercept.EndsWith("/1"))
                {
                    string[] temp = yIntercept.Split('/');
                    yIntercept = temp[0];
                }

                SlopeTxtBx.Text = slope;
                YInterceptTxtBx.Text = yIntercept;

                

                EquationTxtBx.Text = String.Concat("y = (", slope, ")x + (", yIntercept, ")");
                wasError = false;
                wasSimple = false;

            }
            catch (IsJustEqualException)
            {
                EquationTxtBx.Text = "No line!";
                wasError = true;
            }
            catch (IsVerticalException)
            {
                int[] toPass = null;
                foreach (int[] v in vals)
                {
                    if (v[0] != 0 && v[1] != 0)
                        toPass = v;
                }
                SlopeTxtBx.Text = "0";
                SlopeTxtBx.Text = "undefined";
                YInterceptTxtBx.Text = "none";
                try
                {
                    EquationTxtBx.Text = "x = " + toPass[0].ToString();
                }
                catch { }// trust me i'm an engineer
                wasSimple = true;
            }
            catch (IsHorizontalException)
            {
                int[] toPass = null;
                foreach (int[] v in vals)
                {
                    if (v[0] != 0 && v[1] != 0)
                        toPass = v;

                }
                SlopeTxtBx.Text = "0";
                YInterceptTxtBx.Text = toPass[1].ToString();
                EquationTxtBx.Text = "y = " + toPass[1].ToString();
                wasSimple = true;
            }
            catch (Is45Degrees)
            {
                int[] toPass = null;
                foreach (int[] v in vals)
                {
                    if (v[0] != 0 && v[1] != 0)
                        toPass = v;

                }
                object[] res = operations.Collinear(toPass[0], toPass[1]);
                SlopeTxtBx.Text = res[0].ToString();
                YInterceptTxtBx.Text = res[1].ToString();
                EquationTxtBx.Text = Math.Sign((int)res[0]).ToString() + "x = y";
                wasSimple = true;

            }
            catch (DeterminantIsZero)
            {
                EquationTxtBx.Text = "Cant' Solve";
                wasError = true;
            }
            catch (OutOfMemoryException)
            {

                EquationTxtBx.Text = "Cant' Solve";
                wasError = true;
            }
            catch (Exception ex)
            {
                EquationTxtBx.Text = ex.Message;
                wasError = true;
            }


        }
        
        private void ExactValRdoBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (XYGridView.Rows.Count != 1)
            {
                if (ExactValRdoBtn.Checked)
                {
                    Compute();
                }
            }
        }
        private void ApproximateValueRdoBtn_CheckedChanged(object sender, EventArgs e)
        {
            TrackBarSlider.Enabled = DecimalPlacesLbl.Enabled = ApproximateValueRdoBtn.Checked;
            if (XYGridView.Rows.Count != 1)
            {
                if (TrackBarSlider.Enabled)
                {
                    Compute(TrackBarSlider.Value);
                }
            }


        }
        private void TrackBarSlider_Scroll(object sender, EventArgs e)
        {
                DecimalPlacesLbl.Text = "Decimal Places (" + TrackBarSlider.Value + ")";
                if (XYGridView.Rows.Count != 1)
                {
                    Compute(TrackBarSlider.Value);
                }
            
        }
        private void ClearBtn_Click(object sender, EventArgs e)
        {
            if (!DisableBGControls)
            {
                XYGridView.Rows.Clear();
                SlopeTxtBx.Clear();
                YInterceptTxtBx.Clear();
                TrackBarSlider.Value = 5;
                TrackBarSlider.Enabled = DecimalPlacesLbl.Enabled = false;
                DecimalPlacesLbl.Text = "Decimal Places (5)";
                ExactValRdoBtn.Checked = true;
                EquationTxtBx.Clear();
                wasError = true;
                wasSimple = false;
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            PredicterForm p = new PredicterForm();

            if (ExactSlope.Numerator == 0 || SlopeTxtBx.Text.Equals("undefined"))
            { }
            else
            {
                p.Slope = ExactSlope;
                p.YIntercept = ExactYIntercept;
                p.Show(); }
        }
        private void drawer1_Click(object sender, EventArgs e)
        {
            if (!wasError && !wasSimple)
            {
                if (!opened)
                {
                    drawer1.Slope = ExactSlope;
                    drawer1.SlopeString = SlopeTxtBx.Text;
                    drawer1.EquationString = EquationTxtBx.Text;
                    drawer1.YInterceptString = YInterceptTxtBx.Text;
                    drawer1.Points = UserInput;
                    drawer1.YIntercept = ExactYIntercept;
                    drawer1.Location = new Point(0, 361);
                    opened = true;
                    DisableBGControls = true;
                }
                else
                {
                    DisableBGControls = false;
                    drawer1.Location = new Point(0, 494);
                    opened = false;
                }
            }
            else
            {
                if (XYGridView.Rows.Count == 1)
                {
                    EquationTxtBx.Text = "No Data!";
                }
                else if (wasSimple)
                {
                }
                else
                {
                    EquationTxtBx.Text = "Unable to open other functions. Please fix existing errors first.";
                }
            }
        }


        private void LinearApproximationWindow_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = e.Location;
        }

        private void LinearApproximationWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = e.Location;
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
            }  
        }

        private void AboutLbl_MouseHover(object sender, EventArgs e)
        {
            AboutLbl.ForeColor = Color.Gray;
        }

        private void AboutLbl_MouseLeave(object sender, EventArgs e)
        {
            AboutLbl.ForeColor = Color.DimGray;
        }

        private void AboutLbl_Click(object sender, EventArgs e)
        {
            if (!DisableBGControls)
            {
                AboutForm abt = new AboutForm();
                abt.ShowDialog();
            }

        }
        private void InitializeGraphWindow()
        {
            if (SlopeTxtBx.Text == "undefined")
            {
                YInterceptTxtBx.Text = fault;
            }
            Graphing = new Graphing.GraphingWindow(SlopeTxtBx.Text, YInterceptTxtBx.Text, UserInput, EquationTxtBx.Text);   
        }

    }
}