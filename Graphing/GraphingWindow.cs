using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Graphing
{
    /// <summary>
    /// Graphing Window Class
    /// 
    /// Missing in Code: 
    /// 1. Zoom In graph
    /// 2. Scrollbars
    /// </summary>
    public partial class GraphingWindow : Form
    {
        //Declaration
        //
        private float Slope, YInt;
        private readonly List<int[]> UserPoints;
        private int fine = 3;
        private int ScaleFactor = 1;
        private int PanVertical = 0, PanHorizontal = 0;
        private string Equation;
        //
        //Control for point labels
        System.Windows.Forms.Label[] XPCalib;
        System.Windows.Forms.Label[] XNCalib;
        System.Windows.Forms.Label[] YPCalib;
        System.Windows.Forms.Label[] YNCalib;
        System.Windows.Forms.Label[] PlotPoints;

        public GraphingWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// UserInput is an array of ordered pair that the user inputs
        /// </summary>
        /// <param name="slope"></param>
        /// <param name="Yintercept"></param>
        /// <param name="UserInput"></param>
        public GraphingWindow(string slope,string Yintercept,List<int[]> UserInput,string equation)
        {
            InitializeComponent();
            UserPoints = UserInput;
            Equation = equation;
            SetVals(slope, Yintercept);
        }
        private void GraphingWindow_Load(object sender, EventArgs e)
        {

            Refresh();
            FineUpDown.Minimum = 1;
            FineUpDown.Maximum = 10;
            FineUpDown.Value = fine;
            InitializeMyCustomComponent();
            this.Text = "Graph : " + Equation;
            this.DoubleBuffered = true;
        }
        /// <summary>
        /// This set the value to float.
        /// </summary>
        /// <param name="slope"></param>
        /// <param name="Yintercept"></param>
        private void SetVals(string slope, string Yintercept)
        {
            if (slope.IndexOf('/') == -1)
            {
                if (slope == "")
                    Slope = 0;
                else if (slope == "undefined")
                {
                    Slope = -9999.9999f;
                }
                else
                    Slope = float.Parse(slope);
            }
            else
            {
                string[] tmp = slope.Split('/');
                Slope = float.Parse(tmp[0]) / float.Parse(tmp[1]);
            }
            if (Yintercept.IndexOf('/') == -1)
            {
                if (Yintercept == "")
                    YInt = 0;
                else
                    YInt = float.Parse(Yintercept);
            }
            else
            {
                string[] tmp = Yintercept.Split('/');
                YInt = float.Parse(tmp[0]) / float.Parse(tmp[1]);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // initialize pens
            //
            base.OnPaint(e);
            System.Drawing.Pen AxisPen = new System.Drawing.Pen(System
                .Drawing.Color.White, 1f);
            System.Drawing.Pen CurvePen = new System.Drawing.Pen(System
                .Drawing.Color.Green, 2f);
            System.Drawing.Pen PointPen = new System.Drawing.Pen(System
                .Drawing.Color.DarkGreen, 5f);
            //
            //initialize graphic
            //
            Graphics graph = e.Graphics;
            Graphics calib = e.Graphics;
            Graphics plot = e.Graphics;
            //
            //initialize calibration
            //
            int Width = (this.Width / 2 + PanVertical);
            int Height = (this.Height / 2 + PanHorizontal);
            //
            #region Draw Calibration Region
            for (int i = 0; i < fine; i++)// for x positive
            {
                int XPositive = this.Width/2 + ((this.Width / (2 * fine))) * i + PanVertical;
                calib.DrawLine(AxisPen, XPositive , (Height) - 5, XPositive, (Height) + 5);
                XPCalib[i].Text = ((XPositive - PanVertical - this.Width / 2) / ScaleFactor).ToString();
                XPCalib[i].Left = XPositive - 8;
                XPCalib[i].Top = Height + 8;
            }
            for (int i = 0; i < fine; i++)//for x negative
            {
                if (i == 0) continue;

                int XNegative = ((this.Width / (2 * fine))) * i + PanVertical;
                calib.DrawLine(AxisPen, XNegative, (Height) - 5, XNegative, (Height) + 5);
                XNCalib[i].Text = ((XNegative - PanVertical - this.Width / 2) / ScaleFactor ).ToString();
                XNCalib[i].Left = XNegative - 8;
                XNCalib[i].Top = Height + 8;

                if (XNegative > Width) break;
            }

            for (int i = 0; i < fine; i++)//for Y Positive
            {
                if (i == 0) continue;

                int YPositive = (this.Height / 2) - (this.Height / (2 * fine)) * i + PanHorizontal;
                calib.DrawLine(AxisPen, (Width) - 5, YPositive, (Width) + 5, YPositive);
                YPCalib[i].Text = ((-1*(YPositive - PanHorizontal - this.Height / 2)) / ScaleFactor).ToString();
                YPCalib[i].Left = Width + 5;
                YPCalib[i].Top = YPositive - 8;

                if (YPositive > Height) break;
            }

            for (int i = 0; i < fine; i++)//for Y Negative
            {
                if (i == 0) continue;

                int YNegative = (this.Height / 2) + (this.Height / (2 * fine)) * i + PanHorizontal;
                calib.DrawLine(AxisPen, (Width) - 5, YNegative, (Width) + 5, YNegative);
                YNCalib[i].Text = ((-1*(YNegative - PanHorizontal - this.Height / 2) / ScaleFactor)).ToString();
                YNCalib[i].Left = Width + 5;
                YNCalib[i].Top = YNegative - 8;

            }
            
            for (int i = fine; i < 10; i++)// Hide unused text box
            {
                XPCalib[i].Text = "";
                XNCalib[i].Text = "";
                YPCalib[i].Text = "";
                YNCalib[i].Text = "";
            }

            #endregion
            //
            //initialize(DRAW) the Axes
            //
            graph.DrawLine(AxisPen, Width, Height, 0 , Height);
            graph.DrawLine(AxisPen, Width, Height, Width, 0);
            graph.DrawLine(AxisPen, Width, Height, 2000, Height);
            graph.DrawLine(AxisPen, Width, Height, Width, 2000);
            //
            //Draw Curve
            //
            if (Slope != -9999.9999f)
            {
                int half = this.Width / 2 + PanVertical;
                                                                                   // RISE over RUN //
                graph.DrawLine(CurvePen, Width + ScaleFactor, Height - YInt + ScaleFactor, /**/ Width - 1 * half + ScaleFactor, Height - YInt + Slope * half + ScaleFactor);
                graph.DrawLine(CurvePen, Width + ScaleFactor, Height - YInt + ScaleFactor, /**/ (Width + (1 * 1000) * half) + ScaleFactor, (Height - YInt - (Slope * 1000) * half) + ScaleFactor);
            }
            else
            {
                graph.DrawLine(CurvePen, Width + YInt, 0, Width + YInt, this.Height);
            }
            //
            //Plot points + Label point
            //
            if (Slope != -9999.9999f)
            {
                PlotPoints[0].Text = "( 0, " + (YInt).ToString() + " )";
                plot.DrawRectangle(PointPen, Width, Height - YInt, 2, 2);
                PlotPoints[0].Location = new Point(Width + 5, Convert.ToInt32(Height - YInt - 5));
            }
            else
            {
                PlotPoints[0].Text = "( " + (YInt).ToString() + ", 0 )";
                plot.DrawRectangle(PointPen, Width + YInt, Height,2,2);
                PlotPoints[0].Location = new Point(Convert.ToInt32( Width + YInt - 5) , Height + 5);
            }
                {
                    int i = 1;
                    foreach (int[] input in UserPoints)
                    {
                        plot.DrawRectangle(PointPen, (Width + input[0]), (Height - input[1]), 2, 2);
                        PlotPoints[i].Text = "( " + input[0].ToString() + ", " + input[1].ToString() + " )";
                        int temp = PlotPoints[i].Text.Length;
                        //if ( )
                        //{
                        //   
                        //}
                        //else
                        {
                            PlotPoints[i].Location = new Point(Width + input[0] + 5, Height - input[1] - 5);
                        }
                        i++;
                    }
                }
            //
            ////
        }

        private void GraphingWindow_ResizeEnd(object sender, EventArgs e)
        {
            this.Refresh();
            FineLabel.Location = new Point(this.Width - 110, this.Height - 65);
            FineUpDown.Location = new Point(FineLabel.Location.X + 35, FineLabel.Location.Y - 5);
        }

        /// <summary>
        /// This is similar to Initialize component
        /// Use this for controls made outside the designer
        /// </summary>
        private void InitializeMyCustomComponent()
        {
            //
            //
            XPCalib = new Label[10];
            for (int i = 0; i < XPCalib.Length; i++)
            {
                XPCalib[i] = new Label();
                XPCalib[i].Visible = true;
                XPCalib[i].AutoSize = true;
                XPCalib[i].Location = new System.Drawing.Point(0, 0);
                XPCalib[i].Name = "XPCalibLabel" + i + 1;
                XPCalib[i].Size = new System.Drawing.Size(35, 13);
                XPCalib[i].TabIndex = 0;
                XPCalib[i].Text = "";
                XPCalib[i].BackColor = System.Drawing.Color.Transparent;
                XPCalib[i].ForeColor = System.Drawing.Color.White;
                this.Controls.Add(XPCalib[i]);
            }
            //
            //
            XNCalib = new Label[10];
            for (int i = 0; i < XPCalib.Length; i++)
            {
                XNCalib[i] = new Label();
                XNCalib[i].Visible = true;
                XNCalib[i].AutoSize = true;
                XNCalib[i].Location = new System.Drawing.Point(0, 0);
                XNCalib[i].Name = "XPCalibLabel" + i + 1;
                XNCalib[i].Size = new System.Drawing.Size(35, 13);
                XNCalib[i].TabIndex = 0;
                XNCalib[i].Text = "";
                XNCalib[i].BackColor = System.Drawing.Color.Transparent;
                XNCalib[i].ForeColor = System.Drawing.Color.White;
                this.Controls.Add(XNCalib[i]);
            }
            //
            //
            YPCalib = new Label[10];
            for (int i = 0; i < YPCalib.Length; i++)
            {
                YPCalib[i] = new Label();
                YPCalib[i].Visible = true;
                YPCalib[i].AutoSize = true;
                YPCalib[i].Location = new System.Drawing.Point(0, 0);
                YPCalib[i].Name = "XPCalibLabel" + i + 1;
                YPCalib[i].Size = new System.Drawing.Size(35, 13);
                YPCalib[i].TabIndex = 0;
                YPCalib[i].Text = "";
                YPCalib[i].BackColor = System.Drawing.Color.Transparent;
                YPCalib[i].ForeColor = System.Drawing.Color.White;
                this.Controls.Add(YPCalib[i]);
            }
            //
            //
            YNCalib = new Label[10];
            for (int i = 0; i < YNCalib.Length; i++)
            {
                YNCalib[i] = new Label();
                YNCalib[i].Visible = true;
                YNCalib[i].AutoSize = true;
                YNCalib[i].Location = new System.Drawing.Point(0, 0);
                YNCalib[i].Name = "XPCalibLabel" + i + 1;
                YNCalib[i].Size = new System.Drawing.Size(35, 13);
                YNCalib[i].TabIndex = 0;
                YNCalib[i].Text = "";
                YNCalib[i].BackColor = System.Drawing.Color.Transparent;
                YNCalib[i].ForeColor = System.Drawing.Color.White;
                this.Controls.Add(YNCalib[i]);
            }
            //
            //
            PlotPoints = new Label[UserPoints.Count + 1];
            for (int i = 0; i < UserPoints.Count + 1; i++)
            {
                PlotPoints[i] = new Label();
                PlotPoints[i].Visible = true;
                PlotPoints[i].AutoSize = true;
                PlotPoints[i].Location = new System.Drawing.Point(0, 0);
                PlotPoints[i].Name = "PlotPoints" + i + 1;
                PlotPoints[i].Size = new System.Drawing.Size(35, 13);
                PlotPoints[i].TabIndex = 0;
                PlotPoints[i].Text = "";
                PlotPoints[i].BackColor = System.Drawing.Color.Transparent;
                PlotPoints[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                PlotPoints[i].ForeColor = System.Drawing.Color.Red;
                this.Controls.Add(PlotPoints[i]);
            }

            this.Refresh();
        }


        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            fine = Convert.ToInt32(FineUpDown.Value);
            this.Refresh();
        }

        private void GraphingWindow_ResizeEnd_1(object sender, EventArgs e)
        {
            FineLabel.Location = new Point(this.Width - 110, this.Height - 70);
            FineUpDown.Location = new Point(FineLabel.Location.X + 30, FineLabel.Location.Y - 3);
            label1.Location = new Point(10, FineLabel.Location.Y - 10);
            this.Refresh();
        }

        private void GraphingWindow_SizeChanged(object sender, EventArgs e)
        {
            FineLabel.Location = new Point(this.Width - 110, this.Height - 70);
            FineUpDown.Location = new Point(FineLabel.Location.X + 30, FineLabel.Location.Y - 3);
            label1.Location = new Point(10, FineLabel.Location.Y - 10);
            this.Refresh();
            
        }

        string ButtonPressed = "";
        int PanScalarValue = -10;

        private void PanTimer_Tick(object sender, EventArgs e)
        {
            switch (ButtonPressed)
            {
                case "tl":
                    PanVertical -= PanScalarValue;
                    PanHorizontal -= PanScalarValue;
                    break;
                case "t":
                    PanHorizontal -= PanScalarValue;
                    break;
                case "tr":
                    PanVertical += PanScalarValue;
                    PanHorizontal -= PanScalarValue;
                    break;
                case "r":
                    PanVertical += PanScalarValue;
                    break;
                case "l":
                    PanVertical -= PanScalarValue;
                    break;
                case "bl":
                    PanVertical -= PanScalarValue;
                    PanHorizontal += PanScalarValue;
                    break;
                case "b":
                    PanHorizontal += PanScalarValue;
                    break;
                case "br":
                    PanHorizontal += PanScalarValue;
                    PanVertical += PanScalarValue;
                    break;
                default:
                    MessageBox.Show("Pan Error: SWITCH_CASE");
                    PanTimer.Stop();
                    break;
            }
            Refresh();
        }

        private void PanTopLeft_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPressed = "tl";
            PanTimer.Start();
        }

        private void PanTopLeft_MouseUp(object sender, MouseEventArgs e)
        {
            PanTimer.Stop();
        }

        private void PanUp_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPressed = "t";
            PanTimer.Start();
        }

        private void PanUp_MouseUp(object sender, MouseEventArgs e)
        {
            PanTimer.Stop();
        }

        private void PanTopRight_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPressed = "tr";
            PanTimer.Start();
        }

        private void PanTopRight_MouseUp(object sender, MouseEventArgs e)
        {
            PanTimer.Stop();
        }

        private void PanLeft_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPressed = "l";
            PanTimer.Start();
        }

        private void PanLeft_MouseUp(object sender, MouseEventArgs e)
        {
            PanTimer.Stop();
        }

        private void PanCenter_Click(object sender, EventArgs e)
        {
            PanVertical = PanHorizontal = 0;
            Refresh();
        }

        private void PanRight_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPressed = "r";
            PanTimer.Start();
        }

        private void PanBotLeft_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPressed = "bl";
            PanTimer.Start();
        }

        private void PanRight_MouseUp(object sender, MouseEventArgs e)
        {
            PanTimer.Stop();
        }

        private void PanBotLeft_MouseUp(object sender, MouseEventArgs e)
        {
            PanTimer.Stop();
        }

        private void PanDown_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPressed = "b";
            PanTimer.Start();
        }

        private void PanDown_MouseUp(object sender, MouseEventArgs e)
        {
            PanTimer.Stop();
        }

        private void PanBotRight_MouseDown(object sender, MouseEventArgs e)
        {
            ButtonPressed = "br";
            PanTimer.Start();
        }

        private void PanBotRight_MouseUp(object sender, MouseEventArgs e)
        {
            PanTimer.Stop();
        }
  
    }
}
