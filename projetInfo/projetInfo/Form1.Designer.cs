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
            this.pBJoueur = new System.Windows.Forms.PictureBox();
            this.timerTir = new System.Windows.Forms.Timer(this.components);
            this.timerBouge = new System.Windows.Forms.Timer(this.components);
            this.timerEnemis = new System.Windows.Forms.Timer(this.components);
            this.timerVitesseEnemi = new System.Windows.Forms.Timer(this.components);
            this.panelFond.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pBJoueur)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFond
            // 
            this.panelFond.BackColor = System.Drawing.SystemColors.ControlText;
            this.panelFond.Controls.Add(this.pBJoueur);
            this.panelFond.Location = new System.Drawing.Point(-2, -2);
            this.panelFond.Name = "panelFond";
            this.panelFond.Size = new System.Drawing.Size(826, 484);
            this.panelFond.TabIndex = 0;
            // 
            // pBJoueur
            // 
            this.pBJoueur.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pBJoueur.Location = new System.Drawing.Point(111, 199);
            this.pBJoueur.Name = "pBJoueur";
            this.pBJoueur.Size = new System.Drawing.Size(34, 34);
            this.pBJoueur.TabIndex = 0;
            this.pBJoueur.TabStop = false;
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
            this.timerEnemis.Interval = 10000;
            this.timerEnemis.Tick += new System.EventHandler(this.timerEnemis_Tick);
            // 
            // timerVitesseEnemi
            // 
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
            ((System.ComponentModel.ISupportInitialize)(this.pBJoueur)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelFond;
        private System.Windows.Forms.PictureBox pBJoueur;
        private System.Windows.Forms.Timer timerTir;
        private System.Windows.Forms.Timer timerBouge;
        private System.Windows.Forms.Timer timerEnemis;
        private System.Windows.Forms.Timer timerVitesseEnemi;
    }
}

