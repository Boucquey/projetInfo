using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class FormServeur : Form // la pluspart des méthodes présentes sont similaires à celles trouvées dans la FormSinglePlayer
    {
        private Keys direction;
        private Keys tirer;
        private string rcvString = "";
        private List<Enemi> Enemis = new List<Enemi>();
        private Joueur Joueur1;
        private Joueur Joueur2;
        private Boolean ok = true;
        private string[] coordonees = new String[6]; // Cette variable est utilisée pour faire le parsing des informations dans le flux de données recues. Chaque élement tu tableau sera un parametre
        private char[] separator = new Char[] {':',':',':',':',':'}; // Les différentes données sont recues sous la forme d'une longue chaine de caracteres. Les différentes parametres sont séparés par des ":"
        private delegate void Deplacer();
        private Thread th1; // thread qui gerer le flux de données
        private String str = "";
        private NetworkStream stm; // variable pour le flux de données
        private String positionEnemi = ""; // on a une string pour la position de l'enemi. Les coordonnées sont envoyées à l'autre joueur
        private TcpClient cl; // Variable pour le client
        private TcpListener myList; // Listener qui va écouter ce qui se passe sur le réseau
        
        public FormServeur() // constructeur
        {
            InitializeComponent();
            Joueur1 = new Joueur(panelFond, new Point(100, 100),true);
            Joueur2 = new Joueur(panelFond, new Point(100, 150),false); // Cette fois les joueurs sont clairements 
            labelScoreJ1.Text = "0";
            labelScoreJ2.Text = "0"; // L'interface n'est plus la même non plus, on dédouble tout.
            pBChargeJ1.Maximum = 1000;
            pBChargeJ1.Minimum = 0;
            pBChargeJ2.Maximum = 1000;
            pBChargeJ2.Minimum = 0;
            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1"); //on utilise l'adresse ip locale
                myList = new TcpListener(ipAd, 8001);   //initialisation du listener
                myList.Start();                         // on écoute sur le port
                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is :" + myList.LocalEndpoint); // Ces trois lignes ci ne servent qu'a controler via la console ce qui se passe.
                Console.WriteLine("Waiting for a connection.....");
                cl = myList.AcceptTcpClient();          // dés qu'il y a une connection on peut passer a la suite
                Console.WriteLine("Connection accepted from " + cl.Client.RemoteEndPoint);
                stm = cl.GetStream(); // le flux de données est créé
             }
             catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }
            th1 = new Thread(Launch); // on lance le thread qui va lire le flux
            th1.Name = "Serveur";
            th1.Start();
        }

        private void Form6_KeyDown(object sender, KeyEventArgs e) // le reste est semblable au mode singlePlayer
        {
            direction = e.KeyData;

            if (e.KeyData == Keys.Space || e.KeyData == Keys.Enter)
            {
                tirer = e.KeyData;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NewEnemi();
            positionEnemi = Enemis.ElementAt(Enemis.Count-1).Coordonees.X + ":" + Enemis.ElementAt(Enemis.Count-1).Coordonees.Y; // on sauvegarde la position de l'enemi sous forme de string.
        }

        private void Destroy1()
        {
            for (int i = 0; i < Enemis.Count; i++)
            {
                Joueur1.score += Enemis[i].score;
                Enemis.ElementAt(i).mort = true;
                Joueur1.destroy = false;
            }
        }

        private void Destroy2() // Cette méthode est dissociée pour pouvoir compter les points séparéments
        {
            for (int i = 0; i < Enemis.Count; i++)
            {
                Joueur2.score += Enemis[i].score;
                Enemis.ElementAt(i).mort = true;
                Joueur2.destroy = false;
            }
        }

        private void NewEnemi()
        {
            Enemi enemi = new Enemi(panelFond,false);
            Enemis.Add(enemi);
        }

        private void timerVitesseEnemis_Tick(object sender, EventArgs e)
        {
            pBChargeJ1.Value = Joueur1.enchainement;
            pBChargeJ2.Value = Joueur2.enchainement; // tout est dupliqué au niveau de l'interface pour pouvoir traiter les deux joueurs séparéments
            if (Joueur1.destroy)
            {
                Destroy1();
            }
            if (Joueur2.destroy)
            {
                Destroy2();
            }
            for (int i = 0; i < Enemis.Count; i++)
            {
                if (Enemis[i].Color.Equals(Color.White))
                {
                    Enemis[i].Color = Color.Green;
                }
                Enemis[i].Avance(10);
                if (Enemis[i].Location.X + Enemis[i].Width <= 0)
                {
                    Enemis.ElementAt(i).Dispose();
                    Enemis.RemoveAt(i);
                }
                if (Joueur1.forme.Bounds.IntersectsWith(Enemis[i].forme.Bounds) && !Enemis[i].mort)
                {
                   Joueur1.enVie = false;
                }
                for (int j = 0; j < Joueur1.Tirs.Count; j++)
                {
                    if (Joueur1.Tirs[j].Location.X + Joueur1.Tirs[j].Width >= Enemis[i].Location.X &&
                        Joueur1.Tirs[j].Location.X + Joueur1.Tirs[j].Width <= Enemis[i].Location.X + Enemis[i].Width &&
                        Joueur1.Tirs[j].Location.Y <= Enemis[i].Location.Y + Enemis[i].Height &&
                        Joueur1.Tirs[j].Location.Y >= Enemis[i].Location.Y
                        )
                    {
                        if (Enemis[i].Lives <= 0)
                        {
                            Joueur1.score += Enemis[i].score;
                            if (pBChargeJ1.Value < pBChargeJ1.Maximum)
                            {
                                Joueur1.enchainement += 5;
                            }
                            Enemis.ElementAt(i).mort = true;
                        }
                        else
                        {
                            Enemis.ElementAt(i).Touche();
                        }
                        Joueur1.Tirs.ElementAt(j).Dispose();
                        Joueur1.Tirs.RemoveAt(j);
                        break;
                    }
                }
                for (int j = 0; j < Joueur2.Tirs.Count; j++)
                {
                    if (Joueur2.Tirs[j].Location.X + Joueur2.Tirs[j].Width >= Enemis[i].Location.X &&
                        Joueur2.Tirs[j].Location.X + Joueur2.Tirs[j].Width <= Enemis[i].Location.X + Enemis[i].Width &&
                        Joueur2.Tirs[j].Location.Y <= Enemis[i].Location.Y + Enemis[i].Height &&
                        Joueur2.Tirs[j].Location.Y >= Enemis[i].Location.Y
                        )
                    {
                        if (Enemis[i].Lives <= 0)
                        {
                            Joueur2.score += Enemis[i].score;
                            if (pBChargeJ2.Value < pBChargeJ2.Maximum)
                            {
                                Joueur2.enchainement += 5;
                            }
                            Enemis.ElementAt(i).mort = true;
                        }
                        else
                        {
                            Enemis.ElementAt(i).Touche();
                        }
                        Joueur2.Tirs.ElementAt(j).Dispose();
                        Joueur2.Tirs.RemoveAt(j);
                        break;
                    }
                }
            }
        }

        private void Form6_KeyUp(object sender, KeyEventArgs e)
        {
            direction = Keys.E;
            if (e.KeyData == Keys.Space)
            {
                tirer = Keys.E;
            }
        }

        private void timerTir_Tick(object sender, EventArgs e)
        {
            Joueur1.Tir(tirer);
            if (coordonees[2] != null) // une fois que le parsing est fait, on regarde dans la deuxieme case du tableau quelle valeur s'y trouve.
            {
                if (coordonees[2].Equals("666"))// si aucune touche n'est enfoncée
                {
                    Joueur2.Tir("bo");
                }
                if (coordonees[2].Equals("777"))// si il y a super tir
                {
                    Joueur2.Tir("ee");
                }
                if (coordonees[2].Equals("555"))// si il y a tir
                {
                    Joueur2.Tir("fi");
                }
            }
        }

        private void timerBouge_Tick(object sender, EventArgs e)
        {
            Joueur1.AvanceTir();
            Joueur2.AvanceTir();
        }

        private void timerDeplacement_Tick(object sender, EventArgs e) // on regarde ici la position du joueur.
        {
            Parsing(); // On décode les données recues.
            if (coordonees.Count() >= 5)
            {
                if (coordonees[4] != null) // Pour éviter que dans les premiers instants du jeux, il n'y aie un null pointeur exception
                {
                    if (int.Parse(coordonees[4]) == 1) { } else { Joueur2.enVie = false; } // on vérifie si le joueur2 n'est pas mort. 
                }
            }
            if (coordonees.Count() >= 4)
            {
                if (coordonees[3] != null)
                {
                    Joueur2.score = int.Parse(coordonees[3]); // le score du joueur est aussi synchronisé via le réseau
                    labelScoreJ2.Text = Joueur2.score + "";
                }
                else { labelScoreJ2.Text = Joueur2.score + ""; }
            }
            else { labelScoreJ2.Text = Joueur2.score + ""; }
            labelScoreJ1.Text = Joueur1.score + "";
            Joueur1.Bouge(direction);
            str = Joueur1.Location.X + ":" + Joueur1.Location.Y + ":"; // on inscrit dans le string la position du joueur1. On l'envera sur le réseau
            if (coordonees.Count() >= 2)
            {
                if (coordonees[0] != null && coordonees[1] != null)
                {
                    Point z = new Point(int.Parse(coordonees[0]), int.Parse(coordonees[1])); // on regarde les deux primere cases du tableau qui correspondent a la position du joueur
                    Joueur2.Location = z;
                }
            }
            if (tirer == Keys.Space || tirer == Keys.Enter) // on regarde si le joueur1 tire et on rempli la string qu'on enverra en fonction de la touche qui a été enfoncée
            {
                if (tirer == Keys.Space)
                {
                    str += "555:";
                }

                if (tirer == Keys.Enter)
                {
                    str += "666:";
                }
            }
            else { str += "777:"; } 
            str += positionEnemi + ":"; // tout est séparé par un ":" pour pouvoir parser plus facilement
            str += Joueur1.score+":";
            if (Joueur1.enVie)
            {
                str += "1:"; // on note si le joueur1 est mort ou pas
            }
            else { str += "0:"; }
            verif(); // on envoie sur le réseau 
        }

        private void timerExplosion_Tick(object sender, EventArgs e) // comme pour le singlePlayer, si un des joueurs est mort, on le fait exploser
        {
            for (int i = 0; i < Enemis.Count; i++) 
            {
                if (Enemis.ElementAt(i).mort) 
                {
                    Enemis.ElementAt(i).explo += 1;
                    Enemis.ElementAt(i).Death();
                    if (Enemis.ElementAt(i).explo == 3)
                    {
                        Enemis.ElementAt(i).Dispose();
                        Enemis.RemoveAt(i);
                    }
                }
            }
            if (!Joueur1.enVie&&Joueur1.explo<3) 
            {
                    Joueur1.explo += 1;
                    Joueur1.Mort();
            }
             if (Joueur1.explo == 3) 
             {
                 Joueur1.Dispose();
             }
             if (!Joueur2.enVie && Joueur2.explo < 3)
             {
                 Joueur2.explo += 1;
                 Joueur2.Mort();
             }
             if (Joueur2.explo == 3)
             {
                 Joueur2.Dispose();
             }
             if (!Joueur1.enVie && !Joueur2.enVie) // si les deux joueurs sont morts, on ouvre la fenetre game over.
             {
                 FormGameOver frm = new FormGameOver();
                 frm.SetScoreMulti(Joueur1.score,Joueur2.score);
                 frm.Show();
                 ok = false;
                 frm.BringToFront();
                 this.Close(); // quand cette fenetre ce ferme, elle ferme automatiquement la FormReseau qui a son tour fait apparaitre la fentre du menu.
             }
        }

        private void Parsing() {
            coordonees = rcvString.Split(separator); // on remplis le tableau avec les données recue en les séparant au moyen des ":"
        }
        
        private void Launch() // le thread qui va lire ce qui se passe sur le réseau
        {
            try
            {
              while (ok) // la variable ok est "true" tant qu'on ne ferme pas le jeu.
                {
                    byte[] b = new byte[60]; // on crée un tableau de 60 bytes qui va contenir les données brutes qui viennent du flux
                    while (ok)
                    {
                        b = new byte[60]; // on vide le tableau
                        stm.Read(b, 0, b.Length);  // on lit le flux
                        ASCIIEncoding asen = new ASCIIEncoding(); // on convertit les bytes en ASCII
                        rcvString = asen.GetString(b); // on rempli la variable avec la string recue
                        Console.Write("recu : " + rcvString); // Pour le débug
                    }
                    stm.Close(); // on coupe le flux de données
                    cl.Close(); // on coupe le lien TCP
                    myList.Stop(); // On coupr le listener
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }
        }

        private void verif() // on envoie les informations sur le réseau
        {
            if (!str.Equals(""))
            {
                ASCIIEncoding asen = new ASCIIEncoding(); // on encode en code ascii
                byte[] ba = asen.GetBytes(str); // on rempli le tableau qui va être envoyé sur le réseau
                try
                {
                    stm.Write(ba, 0, ba.Length);// on envoie sur le réseau
                    stm.Flush(); // les bytes qui sont restés sur le buffer sont envoyés
                }
                catch { }
            }
        }

        private void FormServeur_FormClosing(object sender, FormClosingEventArgs e)
        {
            // évenement nécessaire pour la l'ouverture des autres fenetres
        }
    }
}
