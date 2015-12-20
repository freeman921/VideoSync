using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace VideoSyncSpace
{
    class SingleClientHandler
    {
        Server server;
        Socket clientSocket;

        NetworkStream nStream;
        IFormatter formatter = new BinaryFormatter();
        //StreamReader reader;
        //StreamWriter writer;

        public SingleClientHandler(Socket cli_sock, Server s) 
        {
            server = s;
            this.clientSocket = cli_sock;
            nStream = new NetworkStream(cli_sock);
            //reader = new StreamReader(nsStream);
            //writer = new StreamWriter(nsStream);
        }

        public EndPoint getRemoteEndPoint() { return clientSocket.RemoteEndPoint; }
        
        public void startReceive()
        {
            try
            {
                while (true)
                {
                    MSG msg = (MSG)formatter.Deserialize(nStream);
                    //String videoTitle = reader.ReadLine();
                    LoggerGUI.log("Video= " + msg.curVideo);
                    //String cmd = reader.ReadLine();
                    LoggerGUI.log("Command= " + msg.cmd);

                    LoggerGUI.logTitle( clientSocket.RemoteEndPoint.ToString() + " Sent a command.");
                    server.orderAllClients( msg, clientSocket.RemoteEndPoint);
                }
            }
           catch (IOException) { LoggerGUI.log("IOException: client left."); }
            catch (SocketException se) { LoggerGUI.log("SocketException: client left." + se.ToString() ); }
        }

        public void orderSingleClient( MSG msg )
        {
            formatter.Serialize(nStream, msg);
            LoggerGUI.logTitle("Server sent a cmd set to (" +msg.senderAddress+")." );
        }

    }
}
