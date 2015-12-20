using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace VideoSyncSpace
{
    class Server
    {
        Socket serverSocket = null;
        List<SingleClientHandler> clientHandlerList = new List<SingleClientHandler>();

       // ~Server() { if (serverSocket != null)serverSocket.Close(); }

        public void start_up()
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, Common.PORT);
            serverSocket = new Socket(localEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(localEndPoint);　//於本機端建立關聯
            serverSocket.Listen(int.MaxValue); //接聽狀態
            LoggerGUI.logForUser("Server已啟動!!");

            while (true)
            {
                Socket clientSocket = serverSocket.Accept();

                SingleClientHandler sch = new SingleClientHandler(clientSocket,this);
                clientHandlerList.Add(sch);
                LoggerGUI.logForUser("Client加入: " + clientSocket.RemoteEndPoint.ToString());

                // Start a thread for receiving
                Thread receiveThread = new Thread(new ThreadStart(sch.startReceive));
                receiveThread.Start();
            }
        }
        
        public void orderAllClients(MSG msg, EndPoint exception_remoteEP)
        {
            msg.senderAddress = exception_remoteEP.ToString();
            foreach (SingleClientHandler handler in clientHandlerList)
            {
                if ( ! handler.getRemoteEndPoint().Equals(exception_remoteEP) )
                    handler.orderSingleClient(msg);
            }
        }
        

        public void end()
        {
            if (serverSocket != null) serverSocket.Close();
            LoggerGUI.logForUser("Server已關閉!!");
        } 
    }
}
