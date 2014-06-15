using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApplication1
{
    class Enemy
    {

        private PictureBox enemi; // On crée le pB de l'enemi
        private int lives;        // On crée la variable pour ses vies
        private int points = 100; // On lui attribue une certaine valeur pour le score
        private Boolean dead = false;// Permet de savoir si il doit exploser ou pas
        private int expl = 0;        // permet de savoir où il en est dans sa cinématique d'explosion

        private Point p;// position

        public Enemy(Panel panel, Boolean multi) // création, il recoit le panel sur lequel il va apparaitre et aussi si il est utilisé en multijoueur ou pas
        {
            Random rnd = new Random(); // On crée un nombre aléatoire
            enemi = new PictureBox(); // on instancie le pB
            p = new Point(); // on instancie la position
            p.X = panel.Width; // On le met à droite du panel
            p.Y = rnd.Next(0, panel.Height - enemi.Height); // sa hauteur est aléatoire
            Image vaisseau = Image.FromFile(@".\enemi1.png"); // On lui met une image
            enemi.BringToFront(); // On le met au premier plan pour pas qu'il ne soit recouvert par un autre picturebox
            enemi.Image = vaisseau; // on attribue l'image au pB
            enemi.Height = 30; // on donne sa hauteur et largeur a l'enemi
            enemi.Width = 60;
            if (!multi)
            {
                enemi.BackColor = Color.Transparent; // pour éviter des pertes de performance en multijoueur, on laisse le carré noir
            }
            enemi.Location = p; // on le place en p
            panel.Controls.Add(enemi);// On ajoute son controle au panel (redondance)
            lives = 2; // On lui attribue 2 vies
            enemi.Refresh(); // Redondance pour etre sur que son dessin soit mis
 
        }


        public Enemy(Panel panel, Point z, Boolean multi) //Permet de créer un enemi en multijoueur du coté client. Le client recoit la coordonnée de l'apparition de l'enemi
        {
            this.p.X = z.X;
            this.p.Y = z.Y;
            enemi = new PictureBox();
            Image vaisseau = Image.FromFile(@".\enemi1.png");
            enemi.Image = vaisseau;
            enemi.BringToFront();
            enemi.Height = 30;
            enemi.Width = 60;
            if (!multi)
            {
                enemi.BackColor = Color.Transparent;
            }
            enemi.Location = p;
            panel.Controls.Add(enemi);
            lives = 2;

        }

        public void Avance(int vitesse) //Parametre l'avancée de l'enemi, on peut faire varier la vitesse en choisisant un autre int
        {
            Point p = new Point();
            p = this.enemi.Location;
            p.X -= vitesse;
            enemi.Location = p;
        }

        public void Touche() // retire des vies a l'enemi qui a été touché
        {
            this.lives--;
        }

        public void Death() // méthode pour faire l'explosion de l'enemi
        {
            switch (this.expl)
            {

                case 0: Image explosion = Image.FromFile(@".\expl1.png");
                    this.enemi.Image = explosion; // On charge l'image de l'explosion correspondante
                    enemi.Refresh(); // redondance pour éviter les bugs
                    enemi.Visible = true; // redondance
                    break;

                case 1: explosion = Image.FromFile(@".\expl2.png");
                    this.enemi.Image = explosion;
                    enemi.Refresh();
                    enemi.Visible = true;
                    break;

                case 2: explosion = Image.FromFile(@".\expl3.png");
                    this.enemi.Image = explosion;
                    enemi.Refresh();
                    enemi.Visible = true;
                    break;
            }

        }

        public void Dispose() //Permet de raccourcir la commande de destuction de l'ennemis
        {
            this.enemi.Dispose();
        }


        /// <>
        /// Variables d'acces.
        /// <>
       

        public int Lives 
        {
            get { return this.lives; }
            set { this.lives = value; }     
        }

        public Boolean mort 
        {
            get { return this.dead; }
            set { this.dead = value; }
        }

        public int Width
        {
            get { return this.enemi.Width; }
            set { this.enemi.Width = value; }
        }

        public Point Coordonees
        {
            get { return this.p; }
            set { this.p = value; }
        }

        public Color Color 
        {
            get { return this.enemi.BackColor; }
            set { this.enemi.BackColor = value; }
        }

        public int Height
        {
            get { return this.enemi.Height; }
            set { this.enemi.Height = value; }
        }

        public Point Location
        {
            get { return this.enemi.Location; }
            set { this.enemi.Location = value; }
        }

        public int score 
        {
            get { return this.points; }
            set { this.points = value; }
        }

        public PictureBox forme 
        {
            get { return enemi; }
            set { this.enemi = value; }
        }

        public int explo
        {
            get { return expl; }
            set { this.expl = value; }
        }
    }
}
