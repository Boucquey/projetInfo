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
       
       
        List<Enemy1> Enemis = new List<Enemy1>();
        Joueur Joueur1;


        public Form1()
        {
            InitializeComponent();
            Joueur1 = new Joueur(panelFond, new Point(100, 100));
        }




        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            direction = e.KeyData;
            Joueur1.Bouge(direction);
        }

        private void timerTir_Tick(object sender, EventArgs e)
        {
            Joueur1.Tir();
        }

        private void timerBouge_Tick(object sender, EventArgs e)
        {
            Joueur1.AvanceTir();
        }

        private void timerEnemis_Tick(object sender, EventArgs e)
        {
            NewEnemi();
        }

        private void timerVitesseEnemi_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Enemis.Count; i++)
            {
                Enemis[i].Avance(10);

                if (Enemis[i].Location.X + Enemis[i].Width <= 0)
                {
                    Enemis.ElementAt(i).Dispose();
                    Enemis.RemoveAt(i);
                }

                if (Enemis[i].Location.X + Enemis[i].Width >= Joueur1.Location.X &&
                    Enemis[i].Location.X + Enemis[i].Width <= Joueur1.Location.X + Joueur1.Width &&
                    Enemis[i].Location.Y <= Joueur1.Location.Y + Joueur1.Height &&
                    Enemis[i].Location.Y >= Joueur1.Location.Y)
                {

                    //Mort();
                }


                for (int j = 0; j < Joueur1.Tirs.Count; j++)
                {
                    if (Joueur1.Tirs[j].Location.X + Joueur1.Tirs[j].Width >= Enemis[i].Location.X &&
                        Joueur1.Tirs[j].Location.X + Joueur1.Tirs[j].Width <= Enemis[i].Location.X + Enemis[i].Width &&
                        Joueur1.Tirs[j].Location.Y <= Enemis[i].Location.Y + Enemis[i].Height &&
                        Joueur1.Tirs[j].Location.Y >= Enemis[i].Location.Y
                        )
                    {
                        Enemis.ElementAt(i).Dispose();
                        Enemis.RemoveAt(i);

                        Joueur1.Tirs.ElementAt(j).Dispose();
                        Joueur1.Tirs.RemoveAt(j);

                    }
                }
            }

        }

        private void NewEnemi() {

            Enemy1 enemi = new Enemy1(panelFond);
            Enemis.Add(enemi);

        }
    }
        
}

