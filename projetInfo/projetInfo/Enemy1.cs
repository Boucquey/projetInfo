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
        Boolean dead = false;
        int expl = 0;

        Point p;

        public Enemy1(Panel panel)
        {
            Random rnd = new Random();
            enemi = new PictureBox();
            p = new Point();
            p.X = panel.Width;
            p.Y = rnd.Next(0, panel.Height - enemi.Height);
            Image vaisseau = Image.FromFile(@".\enemi1.png");
            enemi.Image = vaisseau;
            enemi.Height = 30;
            enemi.Width = 60;
            enemi.BackColor = Color.Transparent;
            enemi.Location = p;
            panel.Controls.Add(enemi);
            lives = 2;
 
        }


        public Enemy1(Panel panel, Point z)
        {
            this.p.X = z.X;
            this.p.Y = z.Y;
            enemi = new PictureBox();
            Image vaisseau = Image.FromFile(@".\enemi1.png");
            enemi.Image = vaisseau;
            enemi.Height = 30;
            enemi.Width = 60;
            enemi.BackColor = Color.Transparent;
            enemi.Location = p;
            panel.Controls.Add(enemi);
            lives = 2;

        }
        public int Lives 
        {

            get { return this.lives; }
            set { this.lives = value; }
        
        }
        public Boolean mort {
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

        public void Dispose(){
            this.enemi.Dispose();
        }

        public void Avance(int vitesse) {

                Point p = new Point();
                p = this.enemi.Location;
                p.X -= vitesse;
                enemi.Location = p;
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

        public void Touche(){

            this.lives--;
      
        }

        public void Death(){
            switch (this.expl){
            
                case 0 : Image explosion = Image.FromFile(@".\expl1.png");
                         this.enemi.Image = explosion;

                         enemi.Refresh();
                         enemi.Visible = true;
                         break;

                case 1 : explosion = Image.FromFile(@".\expl2.png");
                         this.enemi.Image = explosion;

                         enemi.Refresh();
                         enemi.Visible = true;
                         break;

                case 2 : explosion = Image.FromFile(@".\expl3.png");
                         this.enemi.Image = explosion;

                         enemi.Refresh();
                         enemi.Visible = true;
                         break;
               
            }

        }
    }
}
