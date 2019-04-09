using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Sockets;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress[] addresslist = Dns.GetHostAddresses("192.168.137.240");

            Socket transferSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            transferSock.Connect(new IPEndPoint(addresslist[0], 1234));

            lightEntities le = new lightEntities();
            Light light = new Light();

            //byte[] transferStr = Encoding.Default.GetBytes("Hi");
            //transferSock.Send(transferStr);

            //byte[] receivedStr = new byte[11];

            //transferSock.Receive(receivedStr);
            //Console.WriteLine(Encoding.Default.GetString(receivedStr));

            while (true)
            {
                //Random r = new Random();

                //int rnd = r.Next(1, 1001);

                //byte[] transferInt = Encoding.Default.GetBytes(String.Format("{0}","a"));
                //transferSock.Send(transferInt);

                byte[] receivedStr = new byte[10];

                transferSock.Receive(receivedStr);

                Console.WriteLine(Encoding.Default.GetString(receivedStr));
            }
        }
    }
}
