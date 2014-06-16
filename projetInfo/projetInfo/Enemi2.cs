using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Enemi2
    {
         PictureBox enemi;
         int lives;

        public Enemi2(Panel panel)
        {
            Random rnd = new Random();
            enemi = new PictureBox();
            Point p = new Point();
            p.X = panel.Width;
            p.Y = rnd.Next(0, panel.Height - enemi.Height);
            enemi.Height = 40;
            enemi.BackColor = Color.Green;
            enemi.Location = p;
            panel.Controls.Add(enemi);
            lives = 3;
        }

        public int Width
        {

            get { return this.enemi.Width; }
            set { this.enemi.Width = value; }

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

        public void Dispose(){
            this.enemi.Dispose();
        }

        public void Avance(int vitesse, Joueur joueur) {
            
            Point p = new Point();
            p = this.enemi.Location;


            if (joueur.Location.Y + joueur.Height / 2 <= this.enemi.Location.Y + this.enemi.Height / 2)
            {
                p.Y -= vitesse;
            }
            else if (joueur.Location.Y + joueur.Height / 2 > this.enemi.Location.Y + this.enemi.Height / 2)
            {
                p.Y += vitesse;
            }
   
                p.X -= vitesse*2;
                enemi.Location = p;
        }

        public void Touche()
        {

            this.lives--;
            this.enemi.BackColor = Color.White;
            //Thread.Sleep(10);

        }

        public Color Color
        {

            get { return this.enemi.BackColor; }
            set { this.enemi.BackColor = value; }

        }

        public int Lives
        {

            get { return this.lives; }
            set { this.lives = value; }

        }
    }
    
}
