namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.panelFond = new System.Windows.Forms.Panel();
            this.pB2 = new System.Windows.Forms.PictureBox();
            this.pB1 = new System.Windows.Forms.PictureBox();
            this.panelFond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFond
            // 
            this.panelFond.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panelFond.Controls.Add(this.pB2);
            this.panelFond.Controls.Add(this.pB1);
            this.panelFond.Location = new System.Drawing.Point(-2, -2);
            this.panelFond.Name = "panelFond";
            this.panelFond.Size = new System.Drawing.Size(452, 484);
            this.panelFond.TabIndex = 0;
            // 
            // pB2
            // 
            this.pB2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pB2.Location = new System.Drawing.Point(125, 355);
            this.pB2.Name = "pB2";
            this.pB2.Size = new System.Drawing.Size(34, 34);
            this.pB2.TabIndex = 1;
            this.pB2.TabStop = false;
            // 
            // pB1
            // 
            this.pB1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.pB1.Location = new System.Drawing.Point(300, 355);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(34, 34);
            this.pB1.TabIndex = 0;
            this.pB1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 478);
            this.Controls.Add(this.panelFond);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panelFond.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFond;
        private System.Windows.Forms.PictureBox pB2;
        private System.Windows.Forms.PictureBox pB1;
    }
}

