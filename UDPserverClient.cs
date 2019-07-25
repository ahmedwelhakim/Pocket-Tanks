using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Game
{
    class UDPserverClient
    {
        private Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        private const int buffSize = 8 * 1024;
        private State state = new State();      
        private EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
        private AsyncCallback recv = null;

        public class State
        {
            public byte[] buffer = new byte[buffSize];
        }

        public void Server(String address , int port)
        {
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
            socket.Bind(new IPEndPoint(IPAddress.Parse(address), port));
            //Recieve();            TODO with deserialization
        }

        public void Client (String address,int port)
        {
            socket.Connect(IPAddress.Parse(address), port);
            //Recieve();            TODO with deserialization
        }

        public void Send(GameForm game)
        {
            //TODO with serialization
        }

        private void Recieve()
        {
            //TODO with deserializtion
        }

    }
}
