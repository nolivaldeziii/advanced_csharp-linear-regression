namespace Graphing
{
    partial class GraphingWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphingWindow));
            this.FineUpDown = new System.Windows.Forms.NumericUpDown();
            this.FineLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PanUp = new System.Windows.Forms.Button();
            this.PanCenter = new System.Windows.Forms.Button();
            this.PanRight = new System.Windows.Forms.Button();
            this.PanLeft = new System.Windows.Forms.Button();
            this.PanDown = new System.Windows.Forms.Button();
            this.PanButtonPanel = new System.Windows.Forms.Panel();
            this.PanTopLeft = new System.Windows.Forms.Button();
            this.PanBotLeft = new System.Windows.Forms.Button();
            this.PanBotRight = new System.Windows.Forms.Button();
            this.PanTopRight = new System.Windows.Forms.Button();
            this.PanTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.FineUpDown)).BeginInit();
            this.PanButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FineUpDown
            // 
            this.FineUpDown.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FineUpDown.Location = new System.Drawing.Point(685, 480);
            this.FineUpDown.Name = "FineUpDown";
            this.FineUpDown.Size = new System.Drawing.Size(35, 22);
            this.FineUpDown.TabIndex = 0;
            this.FineUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.FineUpDown.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // FineLabel
            // 
            this.FineLabel.AutoSize = true;
            this.FineLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FineLabel.ForeColor = System.Drawing.Color.White;
            this.FineLabel.Location = new System.Drawing.Point(647, 482);
            this.FineLabel.Name = "FineLabel";
            this.FineLabel.Size = new System.Drawing.Size(32, 13);
            this.FineLabel.TabIndex = 1;
            this.FineLabel.Text = "Fine:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 472);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Note that calibration accuracy\r\ndepends on your screen resolution";
            // 
            // PanUp
            // 
            this.PanUp.BackgroundImage = global::Graphing.Properties.Resources.arrow_up;
            this.PanUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanUp.Location = new System.Drawing.Point(27, 3);
            this.PanUp.Name = "PanUp";
            this.PanUp.Size = new System.Drawing.Size(18, 16);
            this.PanUp.TabIndex = 6;
            this.PanUp.UseVisualStyleBackColor = true;
            this.PanUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanUp_MouseDown);
            this.PanUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanUp_MouseUp);
            // 
            // PanCenter
            // 
            this.PanCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanCenter.Location = new System.Drawing.Point(27, 25);
            this.PanCenter.Name = "PanCenter";
            this.PanCenter.Size = new System.Drawing.Size(18, 16);
            this.PanCenter.TabIndex = 7;
            this.PanCenter.UseVisualStyleBackColor = true;
            this.PanCenter.Click += new System.EventHandler(this.PanCenter_Click);
            // 
            // PanRight
            // 
            this.PanRight.BackgroundImage = global::Graphing.Properties.Resources.arrow_right;
            this.PanRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanRight.Location = new System.Drawing.Point(51, 25);
            this.PanRight.Name = "PanRight";
            this.PanRight.Size = new System.Drawing.Size(18, 16);
            this.PanRight.TabIndex = 8;
            this.PanRight.UseVisualStyleBackColor = true;
            this.PanRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanRight_MouseDown);
            this.PanRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanRight_MouseUp);
            // 
            // PanLeft
            // 
            this.PanLeft.BackgroundImage = global::Graphing.Properties.Resources.arrow_left;
            this.PanLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanLeft.Location = new System.Drawing.Point(3, 25);
            this.PanLeft.Name = "PanLeft";
            this.PanLeft.Size = new System.Drawing.Size(18, 16);
            this.PanLeft.TabIndex = 9;
            this.PanLeft.UseVisualStyleBackColor = true;
            this.PanLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanLeft_MouseDown);
            this.PanLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanLeft_MouseUp);
            // 
            // PanDown
            // 
            this.PanDown.BackgroundImage = global::Graphing.Properties.Resources.arrow_down;
            this.PanDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanDown.Location = new System.Drawing.Point(27, 47);
            this.PanDown.Name = "PanDown";
            this.PanDown.Size = new System.Drawing.Size(18, 16);
            this.PanDown.TabIndex = 10;
            this.PanDown.UseVisualStyleBackColor = true;
            this.PanDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanDown_MouseDown);
            this.PanDown.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanDown_MouseUp);
            // 
            // PanButtonPanel
            // 
            this.PanButtonPanel.BackColor = System.Drawing.Color.Transparent;
            this.PanButtonPanel.Controls.Add(this.PanTopLeft);
            this.PanButtonPanel.Controls.Add(this.PanBotLeft);
            this.PanButtonPanel.Controls.Add(this.PanBotRight);
            this.PanButtonPanel.Controls.Add(this.PanTopRight);
            this.PanButtonPanel.Controls.Add(this.PanUp);
            this.PanButtonPanel.Controls.Add(this.PanDown);
            this.PanButtonPanel.Controls.Add(this.PanCenter);
            this.PanButtonPanel.Controls.Add(this.PanLeft);
            this.PanButtonPanel.Controls.Add(this.PanRight);
            this.PanButtonPanel.Location = new System.Drawing.Point(12, 12);
            this.PanButtonPanel.Name = "PanButtonPanel";
            this.PanButtonPanel.Size = new System.Drawing.Size(75, 69);
            this.PanButtonPanel.TabIndex = 11;
            // 
            // PanTopLeft
            // 
            this.PanTopLeft.BackgroundImage = global::Graphing.Properties.Resources.arrow_upLeft;
            this.PanTopLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanTopLeft.Location = new System.Drawing.Point(3, 3);
            this.PanTopLeft.Name = "PanTopLeft";
            this.PanTopLeft.Size = new System.Drawing.Size(18, 16);
            this.PanTopLeft.TabIndex = 12;
            this.PanTopLeft.UseVisualStyleBackColor = true;
            this.PanTopLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanTopLeft_MouseDown);
            this.PanTopLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanTopLeft_MouseUp);
            // 
            // PanBotLeft
            // 
            this.PanBotLeft.BackgroundImage = global::Graphing.Properties.Resources.arrow_downLeft;
            this.PanBotLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanBotLeft.Location = new System.Drawing.Point(3, 46);
            this.PanBotLeft.Name = "PanBotLeft";
            this.PanBotLeft.Size = new System.Drawing.Size(18, 16);
            this.PanBotLeft.TabIndex = 13;
            this.PanBotLeft.UseVisualStyleBackColor = true;
            this.PanBotLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanBotLeft_MouseDown);
            this.PanBotLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanBotLeft_MouseUp);
            // 
            // PanBotRight
            // 
            this.PanBotRight.BackgroundImage = global::Graphing.Properties.Resources.arrow_downRight;
            this.PanBotRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanBotRight.Location = new System.Drawing.Point(50, 47);
            this.PanBotRight.Name = "PanBotRight";
            this.PanBotRight.Size = new System.Drawing.Size(18, 16);
            this.PanBotRight.TabIndex = 12;
            this.PanBotRight.UseVisualStyleBackColor = true;
            this.PanBotRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanBotRight_MouseDown);
            this.PanBotRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanBotRight_MouseUp);
            // 
            // PanTopRight
            // 
            this.PanTopRight.BackgroundImage = global::Graphing.Properties.Resources.arrow_upRight;
            this.PanTopRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanTopRight.Location = new System.Drawing.Point(50, 3);
            this.PanTopRight.Name = "PanTopRight";
            this.PanTopRight.Size = new System.Drawing.Size(18, 16);
            this.PanTopRight.TabIndex = 12;
            this.PanTopRight.UseVisualStyleBackColor = true;
            this.PanTopRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanTopRight_MouseDown);
            this.PanTopRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanTopRight_MouseUp);
            // 
            // PanTimer
            // 
            this.PanTimer.Tick += new System.EventHandler(this.PanTimer_Tick);
            // 
            // GraphingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(734, 512);
            this.Controls.Add(this.PanButtonPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FineLabel);
            this.Controls.Add(this.FineUpDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "GraphingWindow";
            this.Text = "Graph";
            this.Load += new System.EventHandler(this.GraphingWindow_Load);
            this.ResizeEnd += new System.EventHandler(this.GraphingWindow_ResizeEnd_1);
            this.SizeChanged += new System.EventHandler(this.GraphingWindow_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.FineUpDown)).EndInit();
            this.PanButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown FineUpDown;
        private System.Windows.Forms.Label FineLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PanUp;
        private System.Windows.Forms.Button PanCenter;
        private System.Windows.Forms.Button PanRight;
        private System.Windows.Forms.Button PanLeft;
        private System.Windows.Forms.Button PanDown;
        private System.Windows.Forms.Panel PanButtonPanel;
        private System.Windows.Forms.Button PanTopLeft;
        private System.Windows.Forms.Button PanBotLeft;
        private System.Windows.Forms.Button PanBotRight;
        private System.Windows.Forms.Button PanTopRight;
        private System.Windows.Forms.Timer PanTimer;


    }
}

