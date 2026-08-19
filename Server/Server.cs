using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Server
    {
        private Socket osluskujuciSoket;
        
        public Server()
        {
        }

        public void Start()
        {
            osluskujuciSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            osluskujuciSoket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999));
            osluskujuciSoket.Listen();

            Thread acceptThread = new Thread(Accept);
            acceptThread.IsBackground = true;
            acceptThread.Start();
        }

        public void Accept()
        {
            try
            {
                while (true)
                {
                    Socket klijent = osluskujuciSoket.Accept();
                    ClientHandler handler = new ClientHandler(klijent);
                    Thread klijentNit = new Thread(handler.Handle);
                    klijentNit.IsBackground = true;
                    klijentNit.Start();
                }
            } catch (Exception ex)
            {
                Debug.WriteLine(">>>" + ex.ToString());
            }
        }

        public void Stop()
        {
            osluskujuciSoket?.Close();
        }
    }
}
