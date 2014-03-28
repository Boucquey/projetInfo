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

        public Joueur(Panel panel, Point loc)
        {
            pBJoueur = new PictureBox();
            pBJoueur.Location = loc;
            pBJoueur.BackColor = Color.White;
            pBJoueur.Size = new Size(50, 50);
            this.panelFond = panel;
            panelFond.Controls.Add(pBJoueur);
        }


        public void Bouge(Keys direction)
        {
            Point p = new Point();
            p = pBJoueur.Location;

            switch (direction)
            {
                case Keys.Up:
                    p.Y -= 10;
                    break;

                case Keys.Down:
                    p.Y += 10;
                    break;

                case Keys.Left:
                    p.X -= 10;
                    break;

                case Keys.Right:
                    p.X += 10;
                    break;
                default: break;
            }

            pBJoueur.Location = p;
        }


        public Point Location {

            get { return this.pBJoueur.Location; }
            set { pBJoueur.Location = value; }

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

        public void Tir()
        {
            Tir tir = new Tir(this);
            tirs.Add(tir);

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
                    tirs.RemoveAt(i);
                }


            }
    
        }
    }
}
