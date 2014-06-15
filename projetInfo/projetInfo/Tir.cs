using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WindowsFormsApplication1
{
    class Tir
    {

        PictureBox tir;
        Panel panelFond;

        public Tir(Joueur joueur)
        {
            panelFond = joueur.panel;
            tir = new PictureBox();
            Point p = new Point();
            p.Y = joueur.Location.Y + (joueur.Height) / 2;
            p.X = joueur.Location.X + joueur.Width;
            tir.Location = p;
            tir.BackColor = Color.White;
            tir.Width = 10;
            tir.Height = 2;
            joueur.panel.Controls.Add(tir);
            Console.Beep(1000, 2);
        }


        public PictureBox forme
        {
            get { return this.tir; }
        }

        public int Width
        {

            get { return this.tir.Width; }
            set { this.tir.Width = value; }

        }

        public int Height
        {

            get { return this.tir.Height; }
            set { this.tir.Height = value; }

        }

        public Point Location 
        {
            get { return this.tir.Location; }
            set { this.tir.Location = value; }
        
        }


        public void Dispose()
        {
            this.tir.Dispose();
        }
    }
}
