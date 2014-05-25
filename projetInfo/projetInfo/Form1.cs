using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        Keys direction;
        Keys tirer;

        List<Enemy1> Enemis = new List<Enemy1>();
        Joueur Joueur1;

        private delegate void Deplacer();

        public Form1()
        {
            InitializeComponent();
            Joueur1 = new Joueur(panelFond, new Point(100, 100));
            labelScore.Text = "0";
            pBCharge.Maximum = 1000;
            pBCharge.Minimum = 0;
            //panelExplosion.BackColor = Color.FromArgb(2, 88, 44, 2);
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            direction = e.KeyData;

            if (e.KeyData == Keys.Space || e.KeyData == Keys.Enter)
            {
                tirer = e.KeyData;
            }
        }

        private void timerTir_Tick(object sender, EventArgs e)
        {
            Joueur1.Tir(tirer);
            
        }

        private void timerBouge_Tick(object sender, EventArgs e)
        {
            Joueur1.AvanceTir();
        }

        private void timerEnemis_Tick(object sender, EventArgs e)
        {
            NewEnemi();
            // Thread Enemi = new Thread(Avance);
            //Enemi.Start();
        }

        private void timerVitesseEnemi_Tick(object sender, EventArgs e)
        {
            labelScore.Text = Joueur1.score + "";
            pBCharge.Value = Joueur1.enchainement;
            if (Joueur1.destroy)
            {
                Destroy();
            }
            for (int i = 0; i < Enemis.Count; i++)
            {
                if (Enemis[i].Color.Equals(Color.White))
                {
                    Enemis[i].Color = Color.Green;
                }

                Enemis[i].Avance(10);

                if (Enemis[i].Location.X + Enemis[i].Width <= 0)
                {
                    Enemis.ElementAt(i).Dispose();
                    Enemis.RemoveAt(i);
                }
                /*        if (Enemis[i].Location.X + Enemis[i].Width >= Joueur1.Location.X &&
                            Enemis[i].Location.X + Enemis[i].Width <= Joueur1.Location.X + Joueur1.Width &&
                            Enemis[i].Location.Y <= Joueur1.Location.Y + Joueur1.Height &&
                            Enemis[i].Location.Y >= Joueur1.Location.Y)
                  */
                if (Joueur1.forme.Bounds.IntersectsWith(Enemis[i].forme.Bounds)&& !Enemis[i].mort)
                {
                    Joueur1.enVie = false ;
                }


                for (int j = 0; j < Joueur1.Tirs.Count; j++)
                {
                    if (Joueur1.Tirs[j].Location.X + Joueur1.Tirs[j].Width >= Enemis[i].Location.X &&
                        Joueur1.Tirs[j].Location.X + Joueur1.Tirs[j].Width <= Enemis[i].Location.X + Enemis[i].Width &&
                        Joueur1.Tirs[j].Location.Y <= Enemis[i].Location.Y + Enemis[i].Height &&
                        Joueur1.Tirs[j].Location.Y >= Enemis[i].Location.Y
                        )
                    {
                        if (Enemis[i].Lives <= 0)
                        {
                            Joueur1.score += Enemis[i].score;
                            if (pBCharge.Value < pBCharge.Maximum)
                            {
                                Joueur1.enchainement += 5;

                            }
                            Enemis.ElementAt(i).mort = true;

                          

                        }
                        else
                        {
                            Enemis.ElementAt(i).Touche();
                        }


                        Joueur1.Tirs.ElementAt(j).Dispose();
                        Joueur1.Tirs.RemoveAt(j);

                        break;

                    }
                }
            }
        }


        private void NewEnemi()
        {

            Enemy1 enemi = new Enemy1(panelFond);
            Enemis.Add(enemi);


        }

        private void labelScore_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            direction = Keys.E;

            if (e.KeyData == Keys.Space)
            {
                tirer = Keys.E;
            }
        }

        private void deplacement(object sender, EventArgs e)
        {
            Joueur1.Bouge(direction);

        }

        private void Destroy()
        {
            for (int i = 0; i < Enemis.Count; i++)
            {
               

                Joueur1.score += Enemis[i].score;

                Enemis.ElementAt(i).mort = true;

                Joueur1.destroy = false;
              
            }
        }

        private void timerExplosion_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Enemis.Count; i++) 
            {
                if (Enemis.ElementAt(i).mort) {
                    Enemis.ElementAt(i).explo += 1;
                    Enemis.ElementAt(i).Death();
                    if (Enemis.ElementAt(i).explo == 3)
                    {
                        Enemis.ElementAt(i).Dispose();
                        Enemis.RemoveAt(i);
                        
                    }
                }

            }
            if (!Joueur1.enVie&&Joueur1.explo<3) {
                    Joueur1.explo += 1;
                    Joueur1.Mort();
            }
             if (Joueur1.explo == 3) {
                 Joueur1.Dispose();
                 Form3 frm = new Form3();
                 frm.SetScore(Joueur1.score);
                 frm.Show();
                 
                 this.Dispose();

             }
            


        }
    }
        
}

