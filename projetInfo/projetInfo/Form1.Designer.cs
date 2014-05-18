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
            this.components = new System.ComponentModel.Container();
            this.panelFond = new System.Windows.Forms.Panel();
            this.labelScore = new System.Windows.Forms.Label();
            this.timerTir = new System.Windows.Forms.Timer(this.components);
            this.timerBouge = new System.Windows.Forms.Timer(this.components);
            this.timerEnemis = new System.Windows.Forms.Timer(this.components);
            this.timerVitesseEnemi = new System.Windows.Forms.Timer(this.components);
            this.panelFond.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFond
            // 
            this.panelFond.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelFond.Controls.Add(this.labelScore);
            this.panelFond.Location = new System.Drawing.Point(-2, -2);
            this.panelFond.Name = "panelFond";
            this.panelFond.Size = new System.Drawing.Size(826, 484);
            this.panelFond.TabIndex = 0;
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelScore.ForeColor = System.Drawing.Color.FloralWhite;
            this.labelScore.Location = new System.Drawing.Point(14, 458);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(63, 13);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "CACACACA";
            this.labelScore.UseMnemonic = false;
            // 
            // timerTir
            // 
            this.timerTir.Enabled = true;
            this.timerTir.Interval = 200;
            this.timerTir.Tick += new System.EventHandler(this.timerTir_Tick);
            // 
            // timerBouge
            // 
            this.timerBouge.Enabled = true;
            this.timerBouge.Interval = 10;
            this.timerBouge.Tick += new System.EventHandler(this.timerBouge_Tick);
            // 
            // timerEnemis
            // 
            this.timerEnemis.Enabled = true;
            this.timerEnemis.Interval = 5000;
            this.timerEnemis.Tick += new System.EventHandler(this.timerEnemis_Tick);
            // 
            // timerVitesseEnemi
            // 
            this.timerVitesseEnemi.Enabled = true;
            this.timerVitesseEnemi.Interval = 50;
            this.timerVitesseEnemi.Tick += new System.EventHandler(this.timerVitesseEnemi_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 478);
            this.Controls.Add(this.panelFond);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panelFond.ResumeLayout(false);
            this.panelFond.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFond;
        private System.Windows.Forms.Timer timerTir;
        private System.Windows.Forms.Timer timerBouge;
        private System.Windows.Forms.Timer timerEnemis;
        private System.Windows.Forms.Timer timerVitesseEnemi;
        private System.Windows.Forms.Label labelScore;
    }
}

