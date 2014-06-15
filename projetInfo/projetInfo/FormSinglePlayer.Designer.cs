namespace WindowsFormsApplication1
{
    partial class FormSinglePlayer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSinglePlayer));
            this.labelScore = new System.Windows.Forms.Label();
            this.timerTir = new System.Windows.Forms.Timer(this.components);
            this.timerBouge = new System.Windows.Forms.Timer(this.components);
            this.timerEnemis = new System.Windows.Forms.Timer(this.components);
            this.timerVitesseEnemi = new System.Windows.Forms.Timer(this.components);
            this.pBInterface = new System.Windows.Forms.PictureBox();
            this.pBCharge = new System.Windows.Forms.ProgressBar();
            this.timerDeplacement = new System.Windows.Forms.Timer(this.components);
            this.timerExplosion = new System.Windows.Forms.Timer(this.components);
            this.panelFond = new System.Windows.Forms.Panel();
            this.pBDessin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBInterface)).BeginInit();
            this.panelFond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBDessin)).BeginInit();
            this.SuspendLayout();
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelScore.ForeColor = System.Drawing.Color.Black;
            this.labelScore.Location = new System.Drawing.Point(31, 439);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(13, 13);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "0";
            this.labelScore.UseMnemonic = false;
            // 
            // timerTir
            // 
            this.timerTir.Enabled = true;
            this.timerTir.Interval = 150;
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
            this.timerEnemis.Interval = 1000;
            this.timerEnemis.Tick += new System.EventHandler(this.timerEnemis_Tick);
            // 
            // timerVitesseEnemi
            // 
            this.timerVitesseEnemi.Enabled = true;
            this.timerVitesseEnemi.Interval = 50;
            this.timerVitesseEnemi.Tick += new System.EventHandler(this.timerVitesseEnemi_Tick);
            // 
            // pBInterface
            // 
            this.pBInterface.Image = ((System.Drawing.Image)(resources.GetObject("pBInterface.Image")));
            this.pBInterface.Location = new System.Drawing.Point(-9, 425);
            this.pBInterface.Name = "pBInterface";
            this.pBInterface.Size = new System.Drawing.Size(850, 40);
            this.pBInterface.TabIndex = 1;
            this.pBInterface.TabStop = false;
            // 
            // pBCharge
            // 
            this.pBCharge.Location = new System.Drawing.Point(549, 433);
            this.pBCharge.Name = "pBCharge";
            this.pBCharge.Size = new System.Drawing.Size(254, 26);
            this.pBCharge.TabIndex = 2;
            // 
            // timerDeplacement
            // 
            this.timerDeplacement.Enabled = true;
            this.timerDeplacement.Interval = 20;
            this.timerDeplacement.Tick += new System.EventHandler(this.deplacement);
            // 
            // timerExplosion
            // 
            this.timerExplosion.Enabled = true;
            this.timerExplosion.Tick += new System.EventHandler(this.timerExplosion_Tick);
            // 
            // panelFond
            // 
            this.panelFond.BackColor = System.Drawing.Color.Black;
            this.panelFond.Controls.Add(this.pBDessin);
            this.panelFond.Location = new System.Drawing.Point(-9, -7);
            this.panelFond.Name = "panelFond";
            this.panelFond.Size = new System.Drawing.Size(850, 419);
            this.panelFond.TabIndex = 0;
            // 
            // pBDessin
            // 
            this.pBDessin.BackColor = System.Drawing.Color.Transparent;
            this.pBDessin.Location = new System.Drawing.Point(3, 0);
            this.pBDessin.Name = "pBDessin";
            this.pBDessin.Size = new System.Drawing.Size(850, 419);
            this.pBDessin.TabIndex = 38;
            this.pBDessin.TabStop = false;
            // 
            // FormSinglePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 462);
            this.Controls.Add(this.panelFond);
            this.Controls.Add(this.pBCharge);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pBInterface);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 500);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "FormSinglePlayer";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSinglePlayer_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pBInterface)).EndInit();
            this.panelFond.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pBDessin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerTir;
        private System.Windows.Forms.Timer timerBouge;
        private System.Windows.Forms.Timer timerEnemis;
        private System.Windows.Forms.Timer timerVitesseEnemi;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.PictureBox pBInterface;
        private System.Windows.Forms.ProgressBar pBCharge;
        private System.Windows.Forms.Timer timerDeplacement;
        private System.Windows.Forms.Timer timerExplosion;
        private System.Windows.Forms.Panel panelFond;
        private System.Windows.Forms.PictureBox pBDessin;
    }
}

