namespace LinearRegression
{
    partial class LinearApproximationWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinearApproximationWindow));
            this.XYGridView = new System.Windows.Forms.DataGridView();
            this.XColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackBarSlider = new System.Windows.Forms.TrackBar();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.ApproximateValueRdoBtn = new System.Windows.Forms.RadioButton();
            this.ExactValRdoBtn = new System.Windows.Forms.RadioButton();
            this.DecimalPlacesLbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.YInterceptTxtBx = new System.Windows.Forms.TextBox();
            this.SlopeTxtBx = new System.Windows.Forms.TextBox();
            this.YInterceptLbl = new System.Windows.Forms.Label();
            this.SlopeLbl = new System.Windows.Forms.Label();
            this.ComputeBtn = new System.Windows.Forms.Button();
            this.EquationTxtBx = new System.Windows.Forms.TextBox();
            this.AboutLbl = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.drawer1 = new LinearRegression.Drawer();
            ((System.ComponentModel.ISupportInitialize)(this.XYGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSlider)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // XYGridView
            // 
            this.XYGridView.BackgroundColor = System.Drawing.Color.White;
            this.XYGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.XYGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XColumn,
            this.YColumn});
            this.XYGridView.Location = new System.Drawing.Point(12, 76);
            this.XYGridView.MultiSelect = false;
            this.XYGridView.Name = "XYGridView";
            this.XYGridView.Size = new System.Drawing.Size(295, 374);
            this.XYGridView.TabIndex = 0;
            // 
            // XColumn
            // 
            this.XColumn.HeaderText = "X";
            this.XColumn.Name = "XColumn";
            this.XColumn.Width = 125;
            // 
            // YColumn
            // 
            this.YColumn.HeaderText = "Y";
            this.YColumn.Name = "YColumn";
            this.YColumn.Width = 125;
            // 
            // TrackBarSlider
            // 
            this.TrackBarSlider.Location = new System.Drawing.Point(352, 219);
            this.TrackBarSlider.Name = "TrackBarSlider";
            this.TrackBarSlider.Size = new System.Drawing.Size(245, 45);
            this.TrackBarSlider.TabIndex = 2;
            this.TrackBarSlider.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.TrackBarSlider.Value = 5;
            this.TrackBarSlider.Scroll += new System.EventHandler(this.TrackBarSlider_Scroll);
            // 
            // ClearBtn
            // 
            this.ClearBtn.BackColor = System.Drawing.Color.Red;
            this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearBtn.ForeColor = System.Drawing.Color.White;
            this.ClearBtn.Location = new System.Drawing.Point(313, 76);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(163, 33);
            this.ClearBtn.TabIndex = 3;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = false;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // ApproximateValueRdoBtn
            // 
            this.ApproximateValueRdoBtn.AutoSize = true;
            this.ApproximateValueRdoBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApproximateValueRdoBtn.Location = new System.Drawing.Point(336, 175);
            this.ApproximateValueRdoBtn.Name = "ApproximateValueRdoBtn";
            this.ApproximateValueRdoBtn.Size = new System.Drawing.Size(161, 24);
            this.ApproximateValueRdoBtn.TabIndex = 5;
            this.ApproximateValueRdoBtn.Text = "Approximate Values";
            this.ApproximateValueRdoBtn.UseVisualStyleBackColor = true;
            this.ApproximateValueRdoBtn.CheckedChanged += new System.EventHandler(this.ApproximateValueRdoBtn_CheckedChanged);
            // 
            // ExactValRdoBtn
            // 
            this.ExactValRdoBtn.AutoSize = true;
            this.ExactValRdoBtn.Checked = true;
            this.ExactValRdoBtn.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExactValRdoBtn.Location = new System.Drawing.Point(336, 132);
            this.ExactValRdoBtn.Name = "ExactValRdoBtn";
            this.ExactValRdoBtn.Size = new System.Drawing.Size(109, 24);
            this.ExactValRdoBtn.TabIndex = 6;
            this.ExactValRdoBtn.TabStop = true;
            this.ExactValRdoBtn.Text = "Exact Values";
            this.ExactValRdoBtn.UseVisualStyleBackColor = true;
            this.ExactValRdoBtn.CheckedChanged += new System.EventHandler(this.ExactValRdoBtn_CheckedChanged);
            // 
            // DecimalPlacesLbl
            // 
            this.DecimalPlacesLbl.AutoSize = true;
            this.DecimalPlacesLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecimalPlacesLbl.Location = new System.Drawing.Point(419, 256);
            this.DecimalPlacesLbl.Name = "DecimalPlacesLbl";
            this.DecimalPlacesLbl.Size = new System.Drawing.Size(113, 17);
            this.DecimalPlacesLbl.TabIndex = 7;
            this.DecimalPlacesLbl.Text = "Decimal Places (5)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.YInterceptTxtBx);
            this.groupBox1.Controls.Add(this.SlopeTxtBx);
            this.groupBox1.Controls.Add(this.YInterceptLbl);
            this.groupBox1.Controls.Add(this.SlopeLbl);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(353, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 159);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Results";
            // 
            // YInterceptTxtBx
            // 
            this.YInterceptTxtBx.Location = new System.Drawing.Point(4, 115);
            this.YInterceptTxtBx.Name = "YInterceptTxtBx";
            this.YInterceptTxtBx.Size = new System.Drawing.Size(241, 29);
            this.YInterceptTxtBx.TabIndex = 12;
            // 
            // SlopeTxtBx
            // 
            this.SlopeTxtBx.Location = new System.Drawing.Point(4, 53);
            this.SlopeTxtBx.Name = "SlopeTxtBx";
            this.SlopeTxtBx.Size = new System.Drawing.Size(241, 29);
            this.SlopeTxtBx.TabIndex = 11;
            // 
            // YInterceptLbl
            // 
            this.YInterceptLbl.AutoSize = true;
            this.YInterceptLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.YInterceptLbl.Location = new System.Drawing.Point(6, 92);
            this.YInterceptLbl.Name = "YInterceptLbl";
            this.YInterceptLbl.Size = new System.Drawing.Size(86, 17);
            this.YInterceptLbl.TabIndex = 10;
            this.YInterceptLbl.Text = "Y - Intercept: ";
            // 
            // SlopeLbl
            // 
            this.SlopeLbl.AutoSize = true;
            this.SlopeLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SlopeLbl.Location = new System.Drawing.Point(6, 32);
            this.SlopeLbl.Name = "SlopeLbl";
            this.SlopeLbl.Size = new System.Drawing.Size(44, 17);
            this.SlopeLbl.TabIndex = 9;
            this.SlopeLbl.Text = "Slope:";
            // 
            // ComputeBtn
            // 
            this.ComputeBtn.BackColor = System.Drawing.Color.Blue;
            this.ComputeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ComputeBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComputeBtn.ForeColor = System.Drawing.Color.White;
            this.ComputeBtn.Location = new System.Drawing.Point(482, 76);
            this.ComputeBtn.Name = "ComputeBtn";
            this.ComputeBtn.Size = new System.Drawing.Size(161, 33);
            this.ComputeBtn.TabIndex = 1;
            this.ComputeBtn.Text = "Compute";
            this.ComputeBtn.UseVisualStyleBackColor = false;
            this.ComputeBtn.Click += new System.EventHandler(this.ComputeBtn_Click);
            // 
            // EquationTxtBx
            // 
            this.EquationTxtBx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EquationTxtBx.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquationTxtBx.ForeColor = System.Drawing.Color.DimGray;
            this.EquationTxtBx.Location = new System.Drawing.Point(12, 464);
            this.EquationTxtBx.Name = "EquationTxtBx";
            this.EquationTxtBx.Size = new System.Drawing.Size(631, 22);
            this.EquationTxtBx.TabIndex = 12;
            this.EquationTxtBx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AboutLbl
            // 
            this.AboutLbl.AutoSize = true;
            this.AboutLbl.BackColor = System.Drawing.Color.Transparent;
            this.AboutLbl.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AboutLbl.ForeColor = System.Drawing.Color.DimGray;
            this.AboutLbl.Location = new System.Drawing.Point(591, 9);
            this.AboutLbl.Name = "AboutLbl";
            this.AboutLbl.Size = new System.Drawing.Size(52, 21);
            this.AboutLbl.TabIndex = 18;
            this.AboutLbl.Text = "About";
            this.AboutLbl.Click += new System.EventHandler(this.AboutLbl_Click);
            this.AboutLbl.MouseLeave += new System.EventHandler(this.AboutLbl_MouseLeave);
            this.AboutLbl.MouseHover += new System.EventHandler(this.AboutLbl_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::LinearRegression.Properties.Resources.uiv12;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(-36, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(797, 106);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            this.pictureBox2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseMove);
            // 
            // drawer1
            // 
            this.drawer1.BackColor = System.Drawing.Color.Transparent;
            this.drawer1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("drawer1.BackgroundImage")));
            this.drawer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawer1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drawer1.Is45 = false;
            this.drawer1.Location = new System.Drawing.Point(0, 494);
            this.drawer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.drawer1.Name = "drawer1";
            this.drawer1.Size = new System.Drawing.Size(655, 178);
            this.drawer1.TabIndex = 17;
            this.drawer1.Click += new System.EventHandler(this.drawer1_Click);
            // 
            // LinearApproximationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(655, 535);
            this.Controls.Add(this.AboutLbl);
            this.Controls.Add(this.drawer1);
            this.Controls.Add(this.EquationTxtBx);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DecimalPlacesLbl);
            this.Controls.Add(this.ExactValRdoBtn);
            this.Controls.Add(this.ApproximateValueRdoBtn);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.TrackBarSlider);
            this.Controls.Add(this.ComputeBtn);
            this.Controls.Add(this.XYGridView);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LinearApproximationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LINEPROX v2.1 ";
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.Load += new System.EventHandler(this.LinearApproximationWindow_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LinearApproximationWindow_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LinearApproximationWindow_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.XYGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarSlider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView XYGridView;
        private System.Windows.Forms.TrackBar TrackBarSlider;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.RadioButton ApproximateValueRdoBtn;
        private System.Windows.Forms.RadioButton ExactValRdoBtn;
        private System.Windows.Forms.Label DecimalPlacesLbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label YInterceptLbl;
        private System.Windows.Forms.Label SlopeLbl;
        private System.Windows.Forms.TextBox YInterceptTxtBx;
        private System.Windows.Forms.TextBox SlopeTxtBx;
        private System.Windows.Forms.Button ComputeBtn;
        private System.Windows.Forms.TextBox EquationTxtBx;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn XColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn YColumn;
        private Drawer drawer1;
        private System.Windows.Forms.Label AboutLbl;
    }
}