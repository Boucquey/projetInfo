using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Keys direction;
       
        List<PictureBox> tirs = new List<PictureBox>();


        public Form1()
        {
            InitializeComponent();
        }


        private void Bouge()
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            direction = e.KeyData;
            Bouge();
   
        }

        private void timerTir_Tick(object sender, EventArgs e)
        {
            PictureBox tir = new PictureBox();
            Point p = new Point();
            p.Y = pBJoueur.Location.Y + (pBJoueur.Height)/2;
            p.X = pBJoueur.Location.X + pBJoueur.Width;
            tir.Location = p;
            tir.BackColor = Color.White;
            tir.Width = 10;
            tir.Height = 2;
            panelFond.Controls.Add(tir);
            tirs.Add(tir);
        }

        private void timerBouge_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < tirs.Count; i++) { 
                Point p = new Point();
                p = tirs[i].Location;
                p.X += tirs[i].Width;

                tirs[i].Location= p;

                if (tirs[i].Location.X >= panelFond.Width) {
                    tirs.RemoveAt(i);
                }
            }

        }

        private void timerEnemis_Tick(object sender, EventArgs e)
        {
            PictureBox enemi = new PictureBox();
            Point p = new Point();

            enemi.Width = 50;
            enemi.Height = 30;

            Random rnd = new Random();

            p.X = panelFond.Width;
            p.Y = rnd.Next(0, panelFond.Height - enemi.Height);

            enemi.Location = p;
            enemi.BackColor = Color.Red;
 
            panelFond.Controls.Add(enemi);
            
        }

        private void timerVitesseEnemi_Tick(object sender, EventArgs e)
        {



        }
        
    }
        
}
