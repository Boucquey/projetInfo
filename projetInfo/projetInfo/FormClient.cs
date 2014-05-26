using System;
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
    public partial class FormClient : Form
    {

        Joueur Joueur1;
        Joueur Joueur2;
        Boolean connected;

        List<Enemy1> Enemis = new List<Enemy1>();

        String recu = "";

        String str = "";
        Keys direction;
        Keys tirer;

        String rcvString = "";

        TcpClient tcpclnt;

        string[] coordonees = new String[6];
        char[] separator = new Char[] { ':', ':', ':',':',':' };

   
        /// //////////


        NetworkStream stm;
      
        /// //////
   

        public FormClient()
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
                tcpclnt = new TcpClient();
                Console.WriteLine("Connecting.....");
                tcpclnt.Connect("127.0.0.1", 8001); // use the ipaddress as in the server program
                Console.WriteLine("Connected");
                stm = tcpclnt.GetStream();
                connected = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }

            Thread th1 = new Thread(Launch);

            th1.Name = "Client";

            th1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Joueur2.Tir(tirer);

            if (coordonees[2] != null)
            {
                if (coordonees[2].Equals("666"))
                {
                    Joueur1.Tir("bo");
                }
                if (coordonees[2].Equals("777"))
                {
                    Joueur1.Tir("ee");
                }
                if (coordonees[2].Equals("555"))
                {
                    Joueur1.Tir("fi");
                }
                Console.Write("tir : " + coordonees[2]);
            }
        }

        public void Parsing()
        {

            coordonees = rcvString.Split(separator);

        }

        private void timerDeplacement_Tick(object sender, EventArgs e)
        {
            Parsing();



            Joueur2.Bouge(direction);
            str = Joueur2.Location.X + ":" + Joueur2.Location.Y +":";

            if (coordonees.Count() >= 2)
            {
                if (coordonees[0] != null && coordonees[1] != null)
                {
                    //Console.WriteLine("les coordonees :  " + coordonees.ToString());
                    Point z = new Point(int.Parse(coordonees[0]), int.Parse(coordonees[1]));

                    //    point z = new point(convert.toint32(coordonees[2]), convert.toint32(coordonees[4]));

                    //    joueur2.location = rcvstring;
                    Joueur1.Location = z;
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
            Console.WriteLine("coisman  : " + str);
            verif();
        }

        private void FromClient_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {
                case Keys.O:  direction = Keys.Up; break;
                case Keys.L:  direction = Keys.Down; break;
                case Keys.K:  direction = Keys.Left; break;
                case Keys.M:  direction = Keys.Right; break;
                case Keys.E:  direction = Keys.E; break;
                   
            }

           

            if (e.KeyData == Keys.R)
            {
                tirer = Keys.Space;

            }
            if (e.KeyData == Keys.T)
            {
                tirer = Keys.Enter;

            }
            
        }

        private void FromClient_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FromClient_KeyUp(object sender, KeyEventArgs e)
        {
            direction = Keys.E;
           // str = "ee";
            if (e.KeyData == Keys.R || e.KeyData == Keys.T)
            {
                tirer = Keys.E;
            }
        }

        public void Connect()
        {

        }


        private void timerBouge_Tick(object sender, EventArgs e)
        {
            Joueur1.AvanceTir();
            Joueur2.AvanceTir();
        }


        private void verif() {

            if (!str.Equals("") && connected) { 
            Console.Write("touche : " + str);
            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            stm.Write(ba, 0, ba.Length);
            stm.Flush();
             byte[] bb = new byte[100];

          }
        }

        public void Launch()
        {
            try
            {
                while (true)
                {

                    byte[] b = new byte[50];
                  

                    while (true)
                    {
                        b = new byte[50];

                       
                        stm.Read(b, 0, b.Length);
                       
                        ASCIIEncoding asen = new ASCIIEncoding();
                        rcvString = asen.GetString(b);
                        Console.Write("recu chez client : " + rcvString);

                    }
                
                    stm.Close();
                 
          
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            }
        }

        private void timerTimerEnemis_Tick(object sender, EventArgs e)
        {
            if (coordonees[3] != null && coordonees[4] != null)
            {
                Point p = new Point(int.Parse(coordonees[3]),int.Parse(coordonees[4]));
                Enemy1 enemi = new Enemy1(panelFond,p);
                Enemis.Add(enemi);
            }
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

        private void timerExplosion_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < Enemis.Count; i++)
            {
                if (Enemis.ElementAt(i).mort)
                {
                    Enemis.ElementAt(i).explo += 1;
                    Enemis.ElementAt(i).Death();
                    if (Enemis.ElementAt(i).explo == 3)
                    {
                        Enemis.ElementAt(i).Dispose();
                        Enemis.RemoveAt(i);

                    }
                }

            }
            if (!Joueur1.enVie && Joueur1.explo < 3)
            {
                Joueur1.explo += 1;
                Joueur1.Mort();
            }
            if (Joueur1.explo == 3)
            {
                Joueur1.Dispose();
                Form3 frm = new Form3();
                frm.SetScore(Joueur1.score);
                frm.Show();

                this.Dispose();

            }
            
        }

    }
}
