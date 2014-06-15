namespace WindowsFormsApplication1
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pBIntro = new System.Windows.Forms.PictureBox();
            this.btnSingleplayer = new System.Windows.Forms.Button();
            this.btnMultiplayer = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.labelMusic = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBIntro)).BeginInit();
            this.SuspendLayout();
            // 
            // pBIntro
            // 
            this.pBIntro.Image = ((System.Drawing.Image)(resources.GetObject("pBIntro.Image")));
            this.pBIntro.InitialImage = ((System.Drawing.Image)(resources.GetObject("pBIntro.InitialImage")));
            this.pBIntro.Location = new System.Drawing.Point(-7, -1);
            this.pBIntro.Name = "pBIntro";
            this.pBIntro.Size = new System.Drawing.Size(850, 470);
            this.pBIntro.TabIndex = 0;
            this.pBIntro.TabStop = false;
            // 
            // btnSingleplayer
            // 
            this.btnSingleplayer.Font = new System.Drawing.Font("QuickExpress", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleplayer.Location = new System.Drawing.Point(542, 116);
            this.btnSingleplayer.Name = "btnSingleplayer";
            this.btnSingleplayer.Size = new System.Drawing.Size(212, 32);
            this.btnSingleplayer.TabIndex = 1;
            this.btnSingleplayer.Text = "Singleplayer";
            this.btnSingleplayer.UseVisualStyleBackColor = true;
            this.btnSingleplayer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnMultiplayer
            // 
            this.btnMultiplayer.Font = new System.Drawing.Font("QuickExpress", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMultiplayer.Location = new System.Drawing.Point(542, 154);
            this.btnMultiplayer.Name = "btnMultiplayer";
            this.btnMultiplayer.Size = new System.Drawing.Size(212, 32);
            this.btnMultiplayer.TabIndex = 2;
            this.btnMultiplayer.Text = "Multiplayer";
            this.btnMultiplayer.UseVisualStyleBackColor = true;
            this.btnMultiplayer.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnQuit
            // 
            this.btnQuit.Font = new System.Drawing.Font("QuickExpress", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.Location = new System.Drawing.Point(542, 193);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(212, 36);
            this.btnQuit.TabIndex = 3;
            this.btnQuit.Text = "Exit";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // labelMusic
            // 
            this.labelMusic.AutoSize = true;
            this.labelMusic.BackColor = System.Drawing.Color.Black;
            this.labelMusic.Font = new System.Drawing.Font("QuickExpress", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMusic.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelMusic.Location = new System.Drawing.Point(12, 443);
            this.labelMusic.Name = "labelMusic";
            this.labelMusic.Size = new System.Drawing.Size(388, 10);
            this.labelMusic.TabIndex = 4;
            this.labelMusic.Text = "Music from Attack Of Titan, remix 8 bits";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 462);
            this.Controls.Add(this.labelMusic);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnMultiplayer);
            this.Controls.Add(this.btnSingleplayer);
            this.Controls.Add(this.pBIntro);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(850, 500);
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "FormMain";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pBIntro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pBIntro;
        private System.Windows.Forms.Button btnSingleplayer;
        private System.Windows.Forms.Button btnMultiplayer;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label labelMusic;
    }
}