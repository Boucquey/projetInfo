using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Joueur
    {
        Panel panelFond; // On sauvegarde le panel du jeu
        PictureBox pBJoueur; // on crée la variable pour le pB du joueur
        List<Tir> tirs = new List<Tir>(); // On a la liste des tirs du joueur (indispensable pour cintabiliser les points)
        Boolean alive = true;   // Permet de savoir si le joueur doit exploser ou pas
        Boolean destruction = false; //Permet de savoir si le joueur a utilisé son super tir ou pas
        int combo; // Memorise le nombre d'enemis détruits afin d'avoir le super tir
        int expl = 0; // Pour savoir où il en est dans la cinématique d'explosion
        int totalPoint; // le score du joueur
        Boolean joueur1; // Pour permettre de savoir si c'est le joueur 1 ou le joueur 2 (afin de changer la couleur)
        public Joueur(Panel panel, Point loc, bool j1)
        {
            pBJoueur = new PictureBox();
            pBJoueur.Location = loc;
            pBJoueur.BackColor = Color.Transparent;
            Bitmap vaisseau;
            if (j1)
            {
                joueur1 = true;
                vaisseau = new Bitmap(@".\vaisseau.bmp");
                vaisseau.MakeTransparent((vaisseau.GetPixel(0, vaisseau.Size.Height - 1)));
            }
            else
            {
                joueur1 = false;
                vaisseau = new Bitmap(@".\vaisseau2.bmp");
                vaisseau.MakeTransparent((vaisseau.GetPixel(0, vaisseau.Size.Height - 1)));
            }

            pBJoueur.Size = new Size(50, 50);
            pBJoueur.Image = vaisseau;
            pBJoueur.BringToFront();
            this.panelFond = panel;
            panelFond.Controls.Add(pBJoueur);
            pBJoueur.Refresh();
            totalPoint = 0;
            pBJoueur.Bounds.IntersectsWith(pBJoueur.Bounds);
            combo = 1000;
        }


        public void Bouge(Keys direction)
        {
            Point p = new Point();
            p = pBJoueur.Location;

            switch (direction)
            {
                case Keys.Up:
                    if (p.Y > 0) 
                    { 
                    p.Y -= 10;
                    }
                    break;

                case Keys.Down:
                    if (p.Y+ pBJoueur.Height < panelFond.Height)
                    {
                        p.Y += 10;
                    }
                    break;

                case Keys.Left:
                    if (p.X > 0)
                    {
                        p.X -= 10;
                    }
                    break;

                case Keys.Right:
                    if(p.X + pBJoueur.Width < panelFond.Width)
                    p.X += 10;
                    Image vaisseau;
                    if (joueur1)
                    {
                        vaisseau = Image.FromFile(@".\vaisseauDroite.png");
                    }
                    else
                    {
                        vaisseau = Image.FromFile(@".\vaisseau2Droite.bmp");
                    }
                    pBJoueur.Image = vaisseau;
                    pBJoueur.Refresh();
                    break;
                

                default:
                    if (alive)
                    {
                        pBJoueur.BackColor = Color.Transparent;
                        Image vaisseauStop;
                        if(joueur1){
                        vaisseauStop = Image.FromFile(@".\vaisseau.png");
                        }else{
                            vaisseauStop = Image.FromFile(@".\vaisseau2.bmp");
                        }
                        pBJoueur.Image = vaisseauStop;
                    }
                    break;
                
            }

            pBJoueur.Location = p;
        }


        public void Bouge(string direction)
        {
            Point p = new Point();
            p = pBJoueur.Location;
            
            switch (direction)
            {
                case "up":
                    if (p.Y > 0)
                    {
                        p.Y -= 10;
                    }
                    break;

                case "do":
                    if (p.Y + pBJoueur.Height < panelFond.Height)
                    {
                        p.Y += 10;
                    }
                    break;

                case "le":
                    if (p.X > 0)
                    {
                        p.X -= 10;
                    }
                    break;

                case "ri":
                    if (p.X + pBJoueur.Width < panelFond.Width)
                        p.X += 10;
                    Image vaisseau = Image.FromFile(@".\vaisseauDroite.png");
                    pBJoueur.Image = vaisseau;
                    pBJoueur.Refresh();
                    break;


                default:
                    if (alive)
                    {
                        pBJoueur.BackColor = Color.Transparent;
                        Image vaisseauStop = Image.FromFile(@".\vaisseau.png");
                        pBJoueur.Image = vaisseauStop;
                    }
                    break;

            }

            pBJoueur.Location = p;
        }

        public void Mort()
        {
            alive = false;
            switch (this.expl)
            {

                case 0: Image explosion = Image.FromFile(@".\expl1.png");
                    this.pBJoueur.Image = explosion;

                    pBJoueur.Refresh();
                    
                    break;

                case 1: explosion = Image.FromFile(@".\expl2.png");
                    this.pBJoueur.Image = explosion;

                    pBJoueur.Refresh();
                    
                    break;

                case 2: explosion = Image.FromFile(@".\expl3.png");
                          this.pBJoueur.Image = explosion;

                    pBJoueur.Refresh();
                    
                    break;
                
            }
           
        }

        public int explo
        {
            get { return expl; }
            set { this.expl = value; }
        }

        public void Dispose() 
        {

            pBJoueur.Dispose();
                        
        }

        public PictureBox forme
        {
            get { return this.pBJoueur; }

        }

        public Point Location {

            get { return this.pBJoueur.Location; }
            set { pBJoueur.Location = value; }

        }

        public Boolean enVie {

            get { return this.alive; }
            set { this.alive = value; }

        }


        public List<Tir> Tirs
        {

            get { return this.tirs; }
            set { this.tirs = value; }

        }

        public Panel panel
        {

            get { return this.panelFond; }
            set { this.panelFond = value; }

        }

        public int Width {

            get { return this.pBJoueur.Width; }
            set { pBJoueur.Width = value; }

        }


        public int Height
        {

            get { return this.pBJoueur.Height; }
            set { pBJoueur.Height = value; }

        }

        public Boolean destroy {
            get { return this.destruction; }
            set { destruction = value; }
        
        }
        public int score
        {
            get { return this.totalPoint; }
            set { this.totalPoint = value; }
        }

        public int enchainement
        {
            get { return this.combo; }
            set { if(combo <= 995){this.combo = value;} }
        }

        public void Tir(Keys fire)
        {
            if (fire.Equals(Keys.Space) && alive) { 
            Tir tir = new Tir(this);
            tirs.Add(tir);
            if (totalPoint > 0) {
                totalPoint--;
            }
        }
            if (fire.Equals(Keys.Enter) && alive && combo == 1000 && !destruction) {
                combo = 0;
                
                destruction = true;
               
            }
        }


        public void Tir(string fire)
        {
            if (fire.Equals("fi") && alive)
            {
                Tir tir = new Tir(this);
                tirs.Add(tir);
                if (totalPoint > 0)
                {
                    totalPoint--;
                }
            }

            if (fire.Equals("bo") && alive && combo == 1000 && !destruction)
            {
                combo = 0;

                destruction = true;

            }
        }

        public void AvanceTir()
        {
            for (int i = 0; i < tirs.Count; i++)
            {
                Point p = new Point();
                p = tirs[i].Location;
                p.X += tirs[i].Width;

                tirs[i].Location = p;
                tirs[i].forme.BringToFront();
                if (tirs[i].Location.X >= panelFond.Width)
                {
                    this.tirs.ElementAt(i).Dispose();
                    this.tirs.RemoveAt(i);
                }

            }
    
        }
    }
}
