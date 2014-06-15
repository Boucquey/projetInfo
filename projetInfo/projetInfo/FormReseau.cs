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
    public partial class FormReseau : Form
    {
        
        public FormReseau()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e) // On est hote si on sélectionne ce bouton.
        {
            FormServeur frm = new FormServeur();    // On crée la fentre du serveur, la fentre est créée mais n'apparait que lorsque la connection avec le client est effectuée
            frm.Show();                             // La fenetre apparait
            this.Hide();                            // Celle ci est cachée mais ne disparait pas. Si elle disparaissait le menu apparaitrait.
            frm.FormClosing += new FormClosingEventHandler(FormServeur_FormClosing); // Pour entendre un évenement de fermeture de fenetre fille (jeu serveur)
        }

        private void btnClient_Click(object sender, EventArgs e) // meme chose pour le client, sauf qu'on lit ce qu'il y a dans la text box
        {

            FormClient frm = new FormClient(tBIp.Text); // On envoie l'ip choisie par le client.
            frm.Show();
            this.Hide();
            frm.FormClosing += new FormClosingEventHandler(FormClient_FormClosing);
        }

        private void FormReseau_FormClosing(object sender, FormClosingEventArgs e) 
        {
            // définition inutile, ce n'est que l'evenement qui est important.
        }

        private void FormServeur_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close(); // fermeture de la fenetre lorsque la fenetre fille est fermée.

        }

        private void FormClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Close();
        }
    }
}
