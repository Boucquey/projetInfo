using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Enemy1
    {

        PictureBox enemi;


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

        public void Avance(int vitesse) {
            Point p = new Point();
            p = this.enemi.Location;
            p.X -= vitesse;
            enemi.Location = p;
        }
    }
}
