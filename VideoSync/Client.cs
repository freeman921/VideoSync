using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

using System.Windows.Forms;
using Utilities;

namespace VideoSyncSpace
{
    class Client
    {
        TcpClient tcpClient;

        NetworkStream nStream;
        IFormatter formatter = new BinaryFormatter();

        public Commander commander;
        globalKeyboardHook keyboardHook;
        private Socket clientSocket = null;
        bool ctrlKeyOn = true;

        public Client() { }  // keyHook = new KeyHook();

        public void startUP (String serverIP, String playerProcessName, globalKeyboardHook hook)
        {
            commander = new Commander(playerProcessName);
            keyboardHook = hook;
            //keyHookInit();

            connect(serverIP);

            try
            {
                while (true)
                {
                    LoggerGUI.logTitle("Waiting for Command");
                    MSG msg = (MSG)formatter.Deserialize(nStream);

                    LoggerGUI.logForUser("從(" + msg.senderAddress + ")送來了控制訊息 -> " + msg.curTimeLine);
                    LoggerGUI.log("@Video= " + msg.curVideo);
                    LoggerGUI.log("@Command= " + msg.cmd + "  @Timeline=" + msg.curTimeLine);

                    //if (msg.cmd == Common.CMD_PAUSE)
                    receivedPauseMsg(msg);
                }
                
            }
            catch (IOException ioe) { LoggerGUI.logError("IOException: Server shutdown.  "); LoggerGUI.log(ioe.ToString()); }
            catch (SocketException se) { LoggerGUI.logError("SocketException: Server shutdown." + se.ToString() ); }
        }

        /// <summary>
        /// According to User keyboard events
        /// </summary>

        public void userPressedCtrlKey()
        {
            if (commander.playerOnFocus() && ctrlKeyOn == true) // temp
            {
                String time = commander.getCurTimeline();
                MSG msg = new MSG(commander.getCurTitle(), Common.CMD_PAUSE, time);
                LoggerGUI.logForUser("你放出了暫停 -> " + msg.curTimeLine);

                Thread thrd = new Thread(new ThreadStart(() => pauseOthers(msg) ));
                thrd.Start();
            }
        }

        private void receivedPauseMsg(MSG msg)
        {
            // temp
            //if (commander.tempSwitch == true) return;
            //LoggerGUI.logTitle("receivedPauseMsg");

            
                //keyboardHook.unhook();
            ctrlKeyOn = false;
            commander.do_pause_play(msg.curTimeLine);
                //keyboardHook.hook();
            ctrlKeyOn = true;

        }

        private void pauseOthers(MSG msg)
        {
            LoggerGUI.logTitle("Sent pause to Server.");
            LoggerGUI.log("@Video= " + msg.curVideo);
            LoggerGUI.log("@Command= " + msg.cmd + "  @Timeline=" + msg.curTimeLine);

            formatter.Serialize(nStream, msg);
        }

        private void connect(String serverIP)
        {
            try
            {
                tcpClient = new TcpClient(serverIP, Common.PORT);
                LoggerGUI.logForUser("已連線到" + serverIP);
            }
            catch (SocketException ex) { LoggerGUI.logForUser("Server連接失敗:" + ex.Message); }
            LoggerGUI.log("本機位置: " + tcpClient.Client.LocalEndPoint.ToString());

            nStream = tcpClient.GetStream();

        } // connect()

        //public void do_pause() { commander.do_pause_play(); }

        
        #region Key Hook : abandoned
        /*
        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            LoggerGUI.log("User pressed Space.");
            e.Handled = false;  // false = the key will still effects.
        }

        void keyHookInit()
        {
            keyboardHook = new globalKeyboardHook();
            keyboardHook.HookedKeys.Add(Keys.Space);
            keyboardHook.KeyDown += new KeyEventHandler(gkh_KeyDown);
        }
        */
        #endregion


        public void end()
        {
            if (clientSocket != null) clientSocket.Close();
            LoggerGUI.logForUser("Client Socket已關閉!!");
        } 

    } // class Client
} // namespace 
