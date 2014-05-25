namespace WindowsFormsApplication1
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.panelFond = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelScoreJ1 = new System.Windows.Forms.Label();
            this.labelScoreJ2 = new System.Windows.Forms.Label();
            this.pBChargeJ1 = new System.Windows.Forms.ProgressBar();
            this.pBChargeJ2 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFond
            // 
            this.panelFond.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelFond.Location = new System.Drawing.Point(-8, -3);
            this.panelFond.Name = "panelFond";
            this.panelFond.Size = new System.Drawing.Size(850, 419);
            this.panelFond.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-4, 422);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(843, 87);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // labelScoreJ1
            // 
            this.labelScoreJ1.AutoSize = true;
            this.labelScoreJ1.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelScoreJ1.Location = new System.Drawing.Point(36, 433);
            this.labelScoreJ1.Name = "labelScoreJ1";
            this.labelScoreJ1.Size = new System.Drawing.Size(35, 13);
            this.labelScoreJ1.TabIndex = 2;
            this.labelScoreJ1.Text = "label1";
            // 
            // labelScoreJ2
            // 
            this.labelScoreJ2.AutoSize = true;
            this.labelScoreJ2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelScoreJ2.Location = new System.Drawing.Point(36, 474);
            this.labelScoreJ2.Name = "labelScoreJ2";
            this.labelScoreJ2.Size = new System.Drawing.Size(35, 13);
            this.labelScoreJ2.TabIndex = 3;
            this.labelScoreJ2.Text = "label1";
            // 
            // pBChargeJ1
            // 
            this.pBChargeJ1.Location = new System.Drawing.Point(553, 430);
            this.pBChargeJ1.Name = "pBChargeJ1";
            this.pBChargeJ1.Size = new System.Drawing.Size(255, 26);
            this.pBChargeJ1.TabIndex = 4;
            // 
            // pBChargeJ2
            // 
            this.pBChargeJ2.Location = new System.Drawing.Point(553, 470);
            this.pBChargeJ2.Name = "pBChargeJ2";
            this.pBChargeJ2.Size = new System.Drawing.Size(255, 26);
            this.pBChargeJ2.TabIndex = 5;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 502);
            this.Controls.Add(this.pBChargeJ2);
            this.Controls.Add(this.pBChargeJ1);
            this.Controls.Add(this.labelScoreJ2);
            this.Controls.Add(this.labelScoreJ1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelFond);
            this.MaximumSize = new System.Drawing.Size(850, 540);
            this.MinimumSize = new System.Drawing.Size(850, 540);
            this.Name = "Form5";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelFond;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelScoreJ1;
        private System.Windows.Forms.Label labelScoreJ2;
        private System.Windows.Forms.ProgressBar pBChargeJ1;
        private System.Windows.Forms.ProgressBar pBChargeJ2;
    }
}