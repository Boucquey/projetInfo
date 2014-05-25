namespace WindowsFormsApplication1
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.pBmort = new System.Windows.Forms.PictureBox();
            this.bnOk = new System.Windows.Forms.Button();
            this.labelScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBmort)).BeginInit();
            this.SuspendLayout();
            // 
            // pBmort
            // 
            this.pBmort.Image = ((System.Drawing.Image)(resources.GetObject("pBmort.Image")));
            this.pBmort.InitialImage = ((System.Drawing.Image)(resources.GetObject("pBmort.InitialImage")));
            this.pBmort.Location = new System.Drawing.Point(-7, -18);
            this.pBmort.Name = "pBmort";
            this.pBmort.Size = new System.Drawing.Size(496, 382);
            this.pBmort.TabIndex = 0;
            this.pBmort.TabStop = false;
            // 
            // bnOk
            // 
            this.bnOk.Font = new System.Drawing.Font("QuickExpress", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnOk.Location = new System.Drawing.Point(178, 266);
            this.bnOk.Name = "bnOk";
            this.bnOk.Size = new System.Drawing.Size(112, 40);
            this.bnOk.TabIndex = 1;
            this.bnOk.Text = "OK";
            this.bnOk.UseVisualStyleBackColor = true;
            this.bnOk.Click += new System.EventHandler(this.bnOk_Click);
            // 
            // labelScore
            // 
            this.labelScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelScore.ForeColor = System.Drawing.Color.Snow;
            this.labelScore.Location = new System.Drawing.Point(209, 212);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(53, 13);
            this.labelScore.TabIndex = 2;
            this.labelScore.Text = "Score  : 0";
            this.labelScore.Click += new System.EventHandler(this.label1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 362);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.bnOk);
            this.Controls.Add(this.pBmort);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.pBmort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBmort;
        private System.Windows.Forms.Button bnOk;
        private System.Windows.Forms.Label labelScore;
    }
}