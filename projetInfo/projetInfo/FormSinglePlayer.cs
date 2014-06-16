using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class FormSinglePlayer : Form
    {
        private Keys direction; // variable pour les commandes
        private  Keys tirer;     // variable pour le tir
        private List<Enemi> Enemis = new List<Enemi>(); // Liste d'enemis
        private Joueur Joueur1;                           // joueur
        private delegate void Print(Image fond);  // delegate pour pouvoir acceder au panel au moyen du thread 1
        private Boolean stop = false; // controle du thread  

        public FormSinglePlayer()
        {
            InitializeComponent();
            Joueur1 = new Joueur(panelFond, new Point(100, 100),true); // création du joueur
            labelScore.Text = "0";  // initialisation du score
            pBCharge.Maximum = 1000; //initialisation de la jauge de tir
            pBCharge.Minimum = 0;
            Thread th1 = new Thread(Decor); // Declaration du thread de gestion du décor
            th1.Name = "decor"; // on donne un nom au thread
            th1.Start(); // démarrage du thread
            pBDessin.Controls.AddRange(new Control[] { this.Joueur1.forme }); // on ajoute au pB le controle du joueur. Cela permet de ne pas avoir de "carré noir" entournant le dessin du joueur 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) // S'enclanche quand une touche du clavier est enfoncée
        {
            direction = e.KeyData; // la direction est sauvée
            if (e.KeyData == Keys.Space || e.KeyData == Keys.Enter) // on vérifie si le joueur tire ou pas (space pour un tir normal, enter pour super tir)
            {
                tirer = e.KeyData;
            }
        }
        
        private void Form1_KeyUp(object sender, KeyEventArgs e)// S'enclanche quand le joueur leve son doigt d'une touche
        {
            direction = Keys.E; // met une valeur non reconnue pour éviter que le joueur ne continue de se déplacer même en ayant laché le bouton. Ceci permet aussi d'avoir des déplacements fluides
            if (e.KeyData == Keys.Space)
            {
                tirer = Keys.E; // on fait la meme chose pour les tirs.
            }
        }

        private void timerTir_Tick(object sender, EventArgs e) //Timer rapide qui gere les tirs
        {
            Joueur1.Tir(tirer); // methode de gestion du tir du joueur
            if(Joueur1.Tirs.Count !=0)
            pBDessin.Controls.AddRange(new Control[] { Joueur1.Tirs.ElementAt(Joueur1.Tirs.Count() - 1).forme }); // pemet d'ajouter le tir au panel (pour pas qu'il ne le cache)
        }

        private void timerBouge_Tick(object sender, EventArgs e)
        {
            Joueur1.AvanceTir(); // fais avancer les tirs du joueur vers la droite
        }

        private void timerEnemis_Tick(object sender, EventArgs e) // La rapidité de la vitesse de création des enemis peut être changée pour changer la difficulté
        {
            NewEnemi(); // fais apparaitre un enemi
        }

        private void timerVitesseEnemi_Tick(object sender, EventArgs e) // fais avancer les enemis
        {
            labelScore.Text = Joueur1.score + ""; // on initialise le label du score pour cette itération
            pBCharge.Value = Joueur1.enchainement; //remplis la jauge de super tir en fonction de l'enchainement du joueur
            if (Joueur1.destroy) // vérifie si le joueur a déclanché son super tir
            {
                Destroy(); // méthode pour détruire tout les enemis présents
            }
            for (int i = 0; i < Enemis.Count; i++) // On passe en revue chaque enemi
            {
                Enemis[i].Avance(10);
                if (Enemis[i].Location.X + Enemis[i].Width <= 0)
                {
                    Enemis.ElementAt(i).Dispose();
                    Enemis.RemoveAt(i);
                    Joueur1.enVie = false;
                }
                if (Joueur1.forme.Bounds.IntersectsWith(Enemis[i].forme.Bounds)&& !Enemis[i].mort) // vérifie qu'il n'y aie pas de contacts entre le joueur et l'enemi
                {
                    Joueur1.enVie = false ; // Si il y a contact, le joueur meurt, il explose.
                }
                for (int j = 0; j < Joueur1.Tirs.Count; j++)// on passe en revue tout les tirs
                {
                    if (Joueur1.Tirs[j].Location.X + Joueur1.Tirs[j].Width >= Enemis[i].Location.X &&
                        Joueur1.Tirs[j].Location.X + Joueur1.Tirs[j].Width <= Enemis[i].Location.X + Enemis[i].Width && // vérifie si il n'y a pas de contact entre les enemis et les tirs.
                        Joueur1.Tirs[j].Location.Y <= Enemis[i].Location.Y + Enemis[i].Height &&                        // On ne peut pas utiliser le intersct with car sinon, il y a un risque que le tir passe au travers de l'enemi
                        Joueur1.Tirs[j].Location.Y >= Enemis[i].Location.Y                          // si un enemi est touché :
                        )
                    {
                        if (Enemis[i].Lives <= 0) // vérifie le nombre de vie de l'enemi
                        {
                            Joueur1.score += Enemis[i].score; // on ajoute le score au joueur
                            if (pBCharge.Value < pBCharge.Maximum)
                            {
                                Joueur1.enchainement += 5; //On incrémente la jauge d'enchainement
                            }
                            Enemis.ElementAt(i).mort = true; // l'enemi est mort. Il explosera
                        }
                        else
                        {
                            Enemis.ElementAt(i).Touche(); // on retire un point de vie de l'enemi touché
                        }
                        Joueur1.Tirs.ElementAt(j).Dispose(); // le tir est supprimé pour ne pas continuer sa route au travers de l'enemi
                        Joueur1.Tirs.RemoveAt(j);            // On le retire du tableau
                        break;                               // Pour éviter qu'on ne sorte de la liste car le tir n'existe plus.
                    }
                }
            }
        }


        private void NewEnemi()
        {
            Enemi enemi = new Enemi(panelFond,false); // Crée un enemi. On lui envoie le panel et on lui dit qu'on est en singlePlayer
            Enemis.Add(enemi);//On l'ajoute a la liste
            if (Enemis.Count != 0)
            pBDessin.Controls.AddRange(new Control[] { Enemis.ElementAt(Enemis.Count()-1).forme }); // De nouveau, on l'ajoute au controle du panel pour ne pas avoir de carré noir
            Enemis.ElementAt(Enemis.Count - 1).forme.BringToFront(); // pour ne pas qu'il y ai de superposition non voulue, on les mets au premier plan
        }

        private void deplacement(object sender, EventArgs e) // timer de déplacement du joueur
        {
            Joueur1.Bouge(direction); // on envoie la valeur de déplacement du joueur
        }

        private void Destroy() // est enclanché quand le joueur utilise le super tir
        {
            for (int i = 0; i < Enemis.Count; i++) // on balaie les enemis
            {
                Joueur1.score += Enemis[i].score; // on ajoute le score au joueur
                Enemis.ElementAt(i).mort = true; // les enemis sont morts et vont exploser
                Joueur1.destroy = false; // on retire l'enchainement au joueur
            }
        }

        private void timerExplosion_Tick(object sender, EventArgs e) // Permet de gerer l'explosion des vaisseaux
        {
            for (int i = 0; i < Enemis.Count; i++) // on balaie les enemis
            {
                if (Enemis.ElementAt(i).mort) // si un d'entre eux est mort, on le fait exploser
                {
                    Enemis.ElementAt(i).explo += 1; // l'explosion se fait en 3 images, on itere pour faire passer les images de l'explosion dans l'ordre
                    Enemis.ElementAt(i).Death(); // cela se fait dans l'objet enemi
                    if (Enemis.ElementAt(i).explo == 3)
                    {
                        Enemis.ElementAt(i).Dispose(); //on supprime l'enemi
                        Enemis.RemoveAt(i);//quand l'enemi est mort, on le supprime de la liste
                    }
                }
            }
            if (!Joueur1.enVie&&Joueur1.explo<3) 
            {                            // cette partie permet de faire exploser le joueur
                    Joueur1.explo += 1; // de nouveau, cela se fait en 3 étapes.
                    Joueur1.Mort();
            }

            if (Joueur1.explo == 3) 
            {                       // quand le joueur est mort
                 Joueur1.Dispose(); // on le supprime
                 FormGameOver frm = new FormGameOver(); // on crée la fenetre game over
                 frm.SetScore(Joueur1.score);// on mets le score du joueur (il y a une méthode spécifique pour qu'on puisse utiliser la meme Form pour le multi)
                 frm.Show();// on fait apparaitre la fenetre
                 stop = true; // on arrete le thread du décor
                 frm.BringToFront(); // on met la fenetre au premier plan, au dessus du menu qui réaparait lors de la fermeture de cette fenetre
                 this.Close(); // on ferme la fenetre et donc le menu réaparait
                 this.Dispose(); // par sécurité (ne sert a rien)
             }
        }

        private void Decor() // methode lancée par le thread
        {
            Print  z = new Print(ChangeFond); // On instantie le délégate ???????????????????????????????????????????????????????   
            while (!stop) // permet de stoper le thread
            {
                Image decor = Image.FromFile(@".\decor1.png"); // on alterne les deux images de fond. On aurait pu en mettre plus. Malheureusement c'est ça qui fait perdre les performances.
                try { Invoke(z, decor); }                      // On invoque la demande au panel pour changer le fond ???????????????????????????????????
                catch { }  
                Thread.Sleep(500);
                decor = Image.FromFile(@".\decor2.png");
                try { Invoke(z, decor); }
                catch { }
                Thread.Sleep(500);
            }
        }

        private void ChangeFond(Image decor) // methode qui change le fond
        {
            pBDessin.BackgroundImage = decor;
            pBDessin.SendToBack();
            pBDessin.Refresh();
        }

        private void FormSinglePlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            // utile pour ouvrir le menu
        }
    }
}

