using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace LenfLock {
    class LenfServer {
        Socket serverSocket;
        List<Socket> clients;
        public LenfServer() {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clients = new List<Socket>();
        }
        public void Start() {
            serverSocket.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), 3141));
            serverSocket.Listen(100);
            new Thread(Accept) { IsBackground = true }.Start();
            Console.WriteLine("Server Start");
        }
        public void Accept() {
            while(true) {
                Socket client = serverSocket.Accept();
                clients.Add(client);

                new Thread(() => Receive(client)) { IsBackground = true }.Start();
                Console.WriteLine(((IPEndPoint)client.RemoteEndPoint).Address + " Connect");
            }
        }
        public void Receive(Socket Client) {
            while(Client.Connected) {
                try {
                    byte[] ByteReceive = new byte[1024];
                    int ReceiveLenght = Client.Receive(ByteReceive);
                    string msg = Encoding.UTF8.GetString(ByteReceive, 0, ReceiveLenght);

                    Console.WriteLine((Client.RemoteEndPoint as IPEndPoint).Address + ":" + msg);
                    if(msg == "secondApp") {
                        MainInterface.instance.Invoke((MethodInvoker)delegate {
                            MainInterface.instance.show();
                        });
                        break;
                    }
                    if(msg == "exit") {
                        Console.WriteLine((Client.RemoteEndPoint as IPEndPoint).Address + " disconnect");
                        break;
                    }
                    if(msg == "openapp") {
                        MainInterface.instance.Invoke((MethodInvoker)delegate {
                            MainInterface.instance.show();
                        });
                    }
                    if(msg == "status") {
                        string str = "";
                        MainInterface.instance.Invoke((MethodInvoker)delegate {
                            str = MainInterface.instance.isShow.ToString();
                        });
                        Client.Send(Encoding.UTF8.GetBytes(str));
                    }
                } catch(Exception e) {
                    Console.WriteLine(e.StackTrace);
                    break;
                }
            }

            Client.Disconnect(true);
            clients.Remove(Client);
        }
    }
}
