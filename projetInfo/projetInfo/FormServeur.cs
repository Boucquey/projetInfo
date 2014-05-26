﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class FormServeur : Form
    {
        Keys direction;
        Keys tirer;
        string rcvString = "";

        List<Enemy1> Enemis = new List<Enemy1>();

        Joueur Joueur1;
        Joueur Joueur2;

        string[] coordonees = new String[4];
        char[] separator = new Char[] {':',':',':'};
        private delegate void Deplacer();
        Thread th1;

        String str = "";
        NetworkStream stm;


        String positionEnemi = "";

        TcpClient cl;

        TcpListener myList;
        
        public FormServeur()
        {



            InitializeComponent();
            Joueur1 = new Joueur(panelFond, new Point(100, 100));
            Joueur2 = new Joueur(panelFond, new Point(100, 150));
            labelScoreJ1.Text = "0";
            labelScoreJ2.Text = "0";
            pBChargeJ1.Maximum = 1000;
            pBChargeJ1.Minimum = 0;
            pBChargeJ2.Maximum = 1000;
            pBChargeJ2.Minimum = 0;
            
             try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1"); //use local m/c IP address, and use the same in the client
                /* Initializes the Listener */
                myList = new TcpListener(ipAd, 8001);
                /* Start Listeneting at the specified port */
                myList.Start();
                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is :" + myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");
                //Socket s = myList.AcceptSocket();
                cl = myList.AcceptTcpClient();
                Console.WriteLine("Connection accepted from " + cl.Client.RemoteEndPoint);
                stm = cl.GetStream();
             }
             catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }

            th1 = new Thread(Launch);

            th1.Name = "Serveur";

            th1.Start();
        
        }

        private void Form6_KeyDown(object sender, KeyEventArgs e)
        {
            direction = e.KeyData;

            if (e.KeyData == Keys.Space || e.KeyData == Keys.Enter)
            {
                tirer = e.KeyData;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NewEnemi();
            positionEnemi = Enemis.ElementAt(Enemis.Count-1).Coordonees.X + ":" + Enemis.ElementAt(Enemis.Count-1).Coordonees.Y;
        }


        private void Destroy1()
        {
            for (int i = 0; i < Enemis.Count; i++)
            {


                Joueur1.score += Enemis[i].score;

                Enemis.ElementAt(i).mort = true;

                Joueur1.destroy = false;

            }
        }

        private void Destroy2()
        {
            for (int i = 0; i < Enemis.Count; i++)
            {


                Joueur2.score += Enemis[i].score;

                Enemis.ElementAt(i).mort = true;

                Joueur2.destroy = false;

            }
        }


        private void NewEnemi()
        {

            Enemy1 enemi = new Enemy1(panelFond);
            Enemis.Add(enemi);


        }

        private void timerVitesseEnemis_Tick(object sender, EventArgs e)
        {
            labelScoreJ1.Text = rcvString;
            labelScoreJ2.Text = Joueur2.score + "";
            pBChargeJ1.Value = Joueur1.enchainement;
            pBChargeJ2.Value = Joueur2.enchainement;
            if (Joueur1.destroy)
            {
                Destroy1();
            }
            if (Joueur2.destroy)
            {
                Destroy2();
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
                if (Joueur1.forme.Bounds.IntersectsWith(Enemis[i].forme.Bounds) && !Enemis[i].mort)
                {
                   // Joueur1.enVie = false;
                }
                if (Joueur2.forme.Bounds.IntersectsWith(Enemis[i].forme.Bounds) && !Enemis[i].mort)
                {
                    //Joueur2.enVie = false;
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
                            if (pBChargeJ1.Value < pBChargeJ1.Maximum)
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

                for (int j = 0; j < Joueur2.Tirs.Count; j++)
                {
                    if (Joueur2.Tirs[j].Location.X + Joueur2.Tirs[j].Width >= Enemis[i].Location.X &&
                        Joueur2.Tirs[j].Location.X + Joueur2.Tirs[j].Width <= Enemis[i].Location.X + Enemis[i].Width &&
                        Joueur2.Tirs[j].Location.Y <= Enemis[i].Location.Y + Enemis[i].Height &&
                        Joueur2.Tirs[j].Location.Y >= Enemis[i].Location.Y
                        )
                    {
                        if (Enemis[i].Lives <= 0)
                        {
                            Joueur2.score += Enemis[i].score;
                            if (pBChargeJ2.Value < pBChargeJ2.Maximum)
                            {
                                Joueur2.enchainement += 5;

                            }
                            Enemis.ElementAt(i).mort = true;



                        }
                        else
                        {
                            Enemis.ElementAt(i).Touche();
                        }


                        Joueur2.Tirs.ElementAt(j).Dispose();
                        Joueur2.Tirs.RemoveAt(j);

                        break;

                    }
                }
            }
        }

        private void Form6_KeyUp(object sender, KeyEventArgs e)
        {
            direction = Keys.E;

            if (e.KeyData == Keys.Space)
            {
                tirer = Keys.E;
            }
        }

        private void timerTir_Tick(object sender, EventArgs e)
        {
            Joueur1.Tir(tirer);

            if (coordonees[2] != null)
            {
                if (coordonees[2].Equals("666"))
                {
                    Joueur2.Tir("bo");
                }
                if (coordonees[2].Equals("777"))
                {
                    Joueur2.Tir("ee");
                }
                if (coordonees[2].Equals("555"))
                {
                    Joueur2.Tir("fi");
                }
                Console.Write("tir : " + coordonees[2]);
            }
            
        }
        private void timerBouge_Tick(object sender, EventArgs e)
        {
            Joueur1.AvanceTir();
            Joueur2.AvanceTir();
        }

        private void timerDeplacement_Tick(object sender, EventArgs e)
        {

            Parsing();
            Console.WriteLine(th1.ToString()+"");
            Joueur1.Bouge(direction);
            str = Joueur1.Location.X + ":" + Joueur1.Location.Y + ":";

            if (coordonees.Count() >= 2)
            {
                if (coordonees[0] != null && coordonees[1] != null)
                {
                    //Console.WriteLine("les coordonees :  " + coordonees.ToString());
                    Point z = new Point(int.Parse(coordonees[0]), int.Parse(coordonees[1]));

                    //    point z = new point(convert.toint32(coordonees[2]), convert.toint32(coordonees[4]));

                    //    joueur2.location = rcvstring;
                    Joueur2.Location = z;
                }
            }
            if (tirer == Keys.Space || tirer == Keys.Enter)
            {
                if (tirer == Keys.Space)
                {
                    str += "555:";
                }

                if (tirer == Keys.Enter)
                {
                    str += "666:";
                }
            }
            else { str += "777:"; }

            if (tirer == Keys.E)
            {
                str += "777:";
            }
            str += positionEnemi;

            verif();
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



        public void Parsing() {

            coordonees = rcvString.Split(separator);
        
        }

        public void Launch()
        {
            try{
              while (true)
                {
               // rcvString = "";
                string sndString = "The string was recieved by the server.";
                byte[] b = new byte[50];
                  int w = 0;

                    while (true)//stm.Read(b, 0, b.Length) != 0)
                    {
                        b = new byte[50];
                        w++;
                        Console.WriteLine("Recieved..." + w);
                        stm.Read(b, 0, b.Length);
                        Console.WriteLine("ok pour w ");
                        //stm.Read(b, 0, b.Length);
                        //int k = s.Receive(b);
                        
                        //for (int i = 0; i < k; i++)
                        //   Console.Write(Convert.ToChar(b[i]));
                        ASCIIEncoding asen = new ASCIIEncoding();
                        rcvString = asen.GetString(b);

                        Console.Write("recu : " + rcvString);
                        //s.Send(asen.GetBytes("The string was recieved by the server."));
                       // stm.Write(asen.GetBytes(sndString), 0, sndString.Length);

                        //Console.WriteLine("\nSent Acknowledgement");
                        /* clean up */
                       
                    }
                    Console.WriteLine("sortit de la boucle");
                    stm.Close();
                    cl.Close();
                    myList.Stop();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }
        }
        private void verif()
        {

            if (!str.Equals(""))
            {
               // Console.Write("touche : " + str);
                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                stm.Write(ba, 0, ba.Length);
                stm.Flush();
               

            }
        }
    }
}
