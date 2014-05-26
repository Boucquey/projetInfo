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

        String str = "";
        Keys direction;
        Keys tirer;

        TcpClient tcpclnt;
        

        List<Enemy1> Enemis = new List<Enemy1>();
   
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


            Thread th1 = new Thread(Connect);

            th1.Name = "Client";

            th1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timerDeplacement_Tick(object sender, EventArgs e)
        {
            Joueur2.Bouge(direction);
            str = Joueur2.Location.X + ":" + Joueur2.Location.Y;
            Console.WriteLine("coisman  : " + str);
            verif();
        }

        private void FromClient_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {
                case Keys.O: direction = Keys.Up; break;
                case Keys.L: direction = Keys.Down; break;
                case Keys.K:  direction = Keys.Left; break;
                case Keys.M:  direction = Keys.Right; break;
                case Keys.E:  direction = Keys.E; break;
                   
            }

           

            if (e.KeyData == Keys.Space || e.KeyData == Keys.Enter)
            {
                tirer = e.KeyData;
            }
            
        }

        private void FromClient_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void FromClient_KeyUp(object sender, KeyEventArgs e)
        {
            direction = Keys.E;
            str = "ee";
            if (e.KeyData == Keys.Space)
            {
                tirer = Keys.E;
            }
        }

        public void Connect()
        {
            try
            {
                TcpClient tcpclnt = new TcpClient();
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
        }


        private void timerBouge_Tick(object sender, EventArgs e)
        {
            
        }


        private void verif() {

            if (!str.Equals("") && connected) { 
            Console.Write("touche : " + str);

            ASCIIEncoding asen = new ASCIIEncoding();
            
            
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Transmitting.....");



            
            stm.Write(ba, 0, ba.Length);
            // byte[] bb = new byte[100];
            //int k = stm.Read(bb, 0, 100);
            // Console.WriteLine(asen.GetString(bb));

           // tcpclnt.Close();
          }
        }
    }
}
