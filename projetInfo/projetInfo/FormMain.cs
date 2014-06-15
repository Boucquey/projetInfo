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
    public partial class FormMain : Form
    {

        System.Media.SoundPlayer son = new System.Media.SoundPlayer("attack.wav"); //Chargement de la musique
        
        

        public FormMain()
        {
            InitializeComponent();
            son.PlayLooping(); // Lance la musique
        }

        private void button1_Click(object sender, EventArgs e) // si on clique sur le Singleplayer
        {
            FormSinglePlayer frm = new FormSinglePlayer();  // crée la From pour le singlePlayer
            frm.Show(); // fait apparaitre la fenetre
            this.Hide(); // cache celle ci (la musique continue)
            
            frm.FormClosing += new FormClosingEventHandler(FormSinglePlayer_FormClosing); // Permet d'entendre un évenement de fermeture de la fenetre du singleplayer
            
        }

        private void button1_Click_1(object sender, EventArgs e) // Meme chose pour le multiplayer
        {
            FormReseau frm = new FormReseau();
            frm.Show();
            this.Hide();
            
            frm.FormClosing += new FormClosingEventHandler(FormReseau_FormClosing);
        }

        private void btnQuit_Click(object sender, EventArgs e) // quitte le jeu
        {
            this.Close();
        }


        private void FormSinglePlayer_FormClosing(object sender, FormClosingEventArgs e) // Lorsque la fenetre de jeu singleplayer est fermée
        {
            this.Show();    // le menu n'est plus caché
            this.SendToBack(); // pour que le score soit affiché au dessus de la fenetre du menu
            
        }

        private void FormReseau_FormClosing(object sender, FormClosingEventArgs e) // meme chose mais pour le multijoueur
        {
            this.Show();
            this.SendToBack();
            
        }

    }
}
