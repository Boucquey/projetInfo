using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WindowsFormsApplication1
{
    class programmeServeur
    {
        public void Start(){

            try
            {
                IPAddress ipAd = IPAddress.Parse("127.0.0.1"); //use local m/c IP address, and use the same in the client
                /* Initializes the Listener */
                TcpListener myList = new TcpListener(ipAd, 8001);
                /* Start Listeneting at the specified port */
                myList.Start();
                Console.WriteLine("The server is running at port 8001...");
                Console.WriteLine("The local End point is :" + myList.LocalEndpoint);
                Console.WriteLine("Waiting for a connection.....");
                //Socket s = myList.AcceptSocket();
                TcpClient cl = myList.AcceptTcpClient();
                Console.WriteLine("Connection accepted from " + cl.Client.RemoteEndPoint);
                NetworkStream stm = cl.GetStream();
                string rcvString = "";
                string sndString = "The string was recieved by the server.";
                byte[] b = new byte[100];
                while (stm.Read(b, 0, b.Length) != 0)
                {
                    //int k = s.Receive(b);
                    Console.WriteLine("Recieved...");
                    //for (int i = 0; i < k; i++)
                    //   Console.Write(Convert.ToChar(b[i]));
                    ASCIIEncoding asen = new ASCIIEncoding();
                    rcvString = asen.GetString(b);
                    Console.WriteLine(rcvString);
                    //s.Send(asen.GetBytes("The string was recieved by the server."));
                    stm.Write(asen.GetBytes(sndString), 0, sndString.Length);

                    Console.WriteLine("\nSent Acknowledgement");
                    /* clean up */
                }
                stm.Close();
                cl.Close();
                myList.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
                Console.ReadLine();
            } 
        }

    }
}
