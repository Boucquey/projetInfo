using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FormGameOver : Form
    {
        public FormGameOver()
        {
            InitializeComponent();
            Image gameOver = Image.FromFile(@".\gameOver.png");
        }

        public void SetScore(int score)
        {
            this.labelScore.Text = "Score : "+score +"";
        }

        public void SetScoreMulti(int scoreJ1, int scoreJ2) // l'affichage s'adapte en multijoueur
        {
            this.labelScore.Text = "Score Player 1 : " + scoreJ1 + "\nScore Player 2 : " + scoreJ2 +"";
        }

        private void bnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormGameOver_FormClosing(object sender, FormClosingEventArgs e)
        {
            //event nécessaire pour la fermeture en multijoueur
        }
    }
}
