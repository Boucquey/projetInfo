using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace WindowsFormsApplication1
{
    class Serveur
    {
        TcpListener listener;
        List<TcpClient> clients;

        private bool stopped;

        public Serveur()
        {
            listener = new TcpListener(IPAddress.Parse("127.0.0.1"),1234);
            clients = new List<TcpClient>();

        }

        public void Start()
        {
            stopped = false;
            listener.Start();
            Thread t = new Thread(ManageConnection);
            t.Start();
            Console.WriteLine("Server started");
        }


        public void Stop()
        {
            stopped = true;
        }


        private void ManageConnection()
        {
            while (!stopped)
            {
                if (listener.Pending())
                {
                    TcpClient client = listener.AcceptTcpClient();
                    clients.Add(client);

                    Thread t = new Thread(ManageClient);
                    t.Start(client);
                    Console.WriteLine("client {0} connected", client.Client.RemoteEndPoint);
                }

                Thread.Sleep(10);
            }
            foreach(TcpClient cl in clients)
            {
                cl.Close();
            }
            clients.Clear();
            listener.Stop();
            Console.WriteLine("server stopped");
        }

        private void ManageClient(object connectedClient)
        {
            TcpClient client = (TcpClient)connectedClient;
            NetworkStream stream = client.GetStream();
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] rcvMsg;
            byte[] sndMsg;
            
            while (!stopped)
            {
                rcvMsg = new byte[client.Available];
                try
                {
                    if (stream.Read(rcvMsg, 0, client.Available) == 0)
                    {
                        stream.Flush();
                    }
                    Console.WriteLine("msg from client {0} < --------- {1} --------->", client.Client.RemoteEndPoint, encoder.GetString(rcvMsg)); 
                }
                catch
                {
                    break;
                }
            }
            Console.WriteLine("connection with client {0} closed", client.Client.RemoteEndPoint);
            clients.Remove(client);
            stream.Close();
            client.Close();
            
        }
    }
}
