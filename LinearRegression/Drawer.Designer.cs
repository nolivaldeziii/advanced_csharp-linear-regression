namespace LinearRegression
{
    partial class Drawer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GraphLbl = new System.Windows.Forms.Label();
            this.PredictLbl = new System.Windows.Forms.Label();
            this.GraphPBox = new System.Windows.Forms.PictureBox();
            this.PredPBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GraphPBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PredPBox)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphLbl
            // 
            this.GraphLbl.AutoSize = true;
            this.GraphLbl.BackColor = System.Drawing.Color.Transparent;
            this.GraphLbl.ForeColor = System.Drawing.Color.White;
            this.GraphLbl.Location = new System.Drawing.Point(193, 130);
            this.GraphLbl.Name = "GraphLbl";
            this.GraphLbl.Size = new System.Drawing.Size(80, 20);
            this.GraphLbl.TabIndex = 0;
            this.GraphLbl.Text = "Graph Line";
            // 
            // PredictLbl
            // 
            this.PredictLbl.AutoSize = true;
            this.PredictLbl.BackColor = System.Drawing.Color.Transparent;
            this.PredictLbl.ForeColor = System.Drawing.Color.White;
            this.PredictLbl.Location = new System.Drawing.Point(349, 130);
            this.PredictLbl.Name = "PredictLbl";
            this.PredictLbl.Size = new System.Drawing.Size(117, 20);
            this.PredictLbl.TabIndex = 1;
            this.PredictLbl.Text = "Value Projection";
            // 
            // GraphPBox
            // 
            this.GraphPBox.BackColor = System.Drawing.Color.Transparent;
            this.GraphPBox.BackgroundImage = global::LinearRegression.Properties.Resources.thumb_COLOURBOX25140212;
            this.GraphPBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GraphPBox.Location = new System.Drawing.Point(188, 51);
            this.GraphPBox.Name = "GraphPBox";
            this.GraphPBox.Size = new System.Drawing.Size(87, 81);
            this.GraphPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GraphPBox.TabIndex = 3;
            this.GraphPBox.TabStop = false;
            this.GraphPBox.Click += new System.EventHandler(this.GraphPBox_Click);
            // 
            // PredPBox
            // 
            this.PredPBox.BackColor = System.Drawing.Color.Transparent;
            this.PredPBox.BackgroundImage = global::LinearRegression.Properties.Resources.About;
            this.PredPBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PredPBox.Image = global::LinearRegression.Properties.Resources.bullet_question;
            this.PredPBox.Location = new System.Drawing.Point(368, 57);
            this.PredPBox.Name = "PredPBox";
            this.PredPBox.Size = new System.Drawing.Size(80, 70);
            this.PredPBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PredPBox.TabIndex = 5;
            this.PredPBox.TabStop = false;
            this.PredPBox.Click += new System.EventHandler(this.PredPBox_Click);
            // 
            // Drawer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::LinearRegression.Properties.Resources.drawer1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.PredPBox);
            this.Controls.Add(this.GraphPBox);
            this.Controls.Add(this.PredictLbl);
            this.Controls.Add(this.GraphLbl);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Drawer";
            this.Size = new System.Drawing.Size(655, 169);
            this.Load += new System.EventHandler(this.Drawer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GraphPBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PredPBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GraphLbl;
        private System.Windows.Forms.Label PredictLbl;
        private System.Windows.Forms.PictureBox GraphPBox;
        private System.Windows.Forms.PictureBox PredPBox;
    }
}
