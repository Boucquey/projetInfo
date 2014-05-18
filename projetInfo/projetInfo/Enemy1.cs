using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace WindowsFormsApplication1
{
    class Enemy1
    {

        PictureBox enemi;
        int lives;
        int points = 100;

        public Enemy1(Panel panel)
        {
            Random rnd = new Random();
            enemi = new PictureBox();
            Point p = new Point();
            p.X = panel.Width;
            p.Y = rnd.Next(0, panel.Height - enemi.Height);
            enemi.Height = 30;
            enemi.BackColor = Color.Red;
            enemi.Location = p;
            panel.Controls.Add(enemi);
            lives = 2;
 
        }
        public int Lives 
        {

            get { return this.lives; }
            set { this.lives = value; }
        
        }
        public int Width
        {

            get { return this.enemi.Width; }
            set { this.enemi.Width = value; }

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

        public void Dispose(){
            this.enemi.Dispose();
        }

        public void Avance(int vitesse) {

                Point p = new Point();
                p = this.enemi.Location;
                p.X -= vitesse;
                enemi.Location = p;
        }


        public 


        public void Touche(){

            this.lives--;
            this.enemi.BackColor = Color.White;
            //Thread.Sleep(10);
           
        
        }
    }
}
