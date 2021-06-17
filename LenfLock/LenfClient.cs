using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LenfLock {
    class LenfClient {
        private Socket ClientSocket;
        public LenfClient() {
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public LenfClient Connect(string IP, Int32 Port) {
            try {
                ClientSocket.Connect(IP, Port);
                new Thread(() => Receive()) { IsBackground = true }.Start();
                return this;
            } catch(SocketException e) {
                Console.WriteLine("無法連接到{0}:{1}{2}", IP, Port, e);
            }
            return null;
        }
        public void DisConnect() {
            ClientSocket.Disconnect(true);
        }
        public LenfClient Send(string msg) {
            if(ClientSocket.Connected) {
                ClientSocket.Send(Encoding.UTF8.GetBytes(msg));
            } else {
                Console.WriteLine("伺服器並未連線");
            }
            return this;
        }
        private void Receive() {
            while(ClientSocket.Connected) {
                try {
                    byte[] ByteReceive = new byte[1024];
                    int ReceiveLenght = ClientSocket.Receive(ByteReceive);
                    string msg = Encoding.UTF8.GetString(ByteReceive, 0, ReceiveLenght);
                } catch(Exception e) {
                    Console.WriteLine(e.StackTrace);
                    break;
                }
            }
        }
    }
}
