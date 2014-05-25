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
        Panel panelFond;
        PictureBox pBJoueur;
        List<Tir> tirs = new List<Tir>();
        Boolean alive = true;
        Boolean destruction = false;
        int combo;
        int expl = 0;
        int totalPoint;

        public Joueur(Panel panel, Point loc)
        {
            pBJoueur = new PictureBox();
            pBJoueur.Location = loc;
            pBJoueur.BackColor = Color.Transparent;
            Image vaisseau = Image.FromFile(@".\vaisseau.png");
            pBJoueur.Size = new Size(50, 50);
            pBJoueur.Image = vaisseau;
            this.panelFond = panel;
            panelFond.Controls.Add(pBJoueur);

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
                    break;
                default: break;
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


        public void AvanceTir()
        {
            for (int i = 0; i < tirs.Count; i++)
            {
                Point p = new Point();
                p = tirs[i].Location;
                p.X += tirs[i].Width;

                tirs[i].Location = p;

                if (tirs[i].Location.X >= panelFond.Width)
                {
                    this.tirs.ElementAt(i).Dispose();
                    this.tirs.RemoveAt(i);
                }

            }
    
        }
    }
}
