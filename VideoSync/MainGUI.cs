using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using Utilities;

namespace VideoSyncSpace
{
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
            initMainGUI();
        }

        public static MainGUI mainProg;
        public static string curPath;
        public static string logName;
        public static string progState="Running";

        Server server;
        Client client;
        globalKeyboardHook keyboardHook;
        Thread serverThread = null, clientThread = null;
        
        int curMode = Common.NO_MODE ;

        public void initMainGUI()
        {
            curPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);  //get exe path
            logName = DateTime.Now.ToString("HH-mm-ss---yyyy-MM-dd"); // "HH-mm-ss "
            LoggerGUI.init(this, curPath, logName);
        }

        #region Button Handler

        private void serverButton_Click(object sender, EventArgs e)
        {
            if (curMode == Common.CLIENT_MODE)
                threadClose();
            curMode = Common.SERVER_MODE;
            guiChangeButtonColor(curMode); // newMode

            server = new Server();
            serverThread = new Thread(new ThreadStart( server.start_up ));

            try { serverThread.Start(); }
            catch (Exception error)
            {
                LoggerGUI.log(error.ToString());
            }

            
            // open client too
            client = new Client();
            button_Connect_Click(new object(), new EventArgs());
            
        }

        private void clientButton_Click(object sender, EventArgs e)
        {
            if (curMode == Common.SERVER_MODE)
                threadClose();
            curMode = Common.CLIENT_MODE;
            guiChangeButtonColor(curMode);

            client = new Client();
        }
        private void button_Connect_Click(object sender, EventArgs e) 
        {
            keyHookInit();

            try {
                String procName = cut_exe_name(this.processName_TextBox.Text);

                clientThread = new Thread(() => client.startUP(this.textbox_ServerIP.Text, procName, keyboardHook));
                clientThread.SetApartmentState(ApartmentState.STA);
                clientThread.Start();
            }
            catch (Exception error)
            {
                LoggerGUI.log(error.ToString());
            }
        }
        #endregion

        private String cut_exe_name(String org_name)
        {
            int pos = org_name.IndexOf(".exe");
            if (pos==-1)
                return org_name;
            else
                return org_name.Substring(0,pos);
        }
        
        #region Key Hook

        void gkh_KeyDown(object sender, KeyEventArgs e)
        {
            LoggerGUI.log("User pressed pause.");
            e.Handled = false;  // false = the key will still effects.
            Thread thr = new Thread(new ThreadStart(client.userPressedCtrlKey));
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
        }
        
        void keyHookInit()
        {
            keyboardHook = new globalKeyboardHook();
            keyboardHook.HookedKeys.Add(Keys.Space);
            keyboardHook.KeyDown += new KeyEventHandler(gkh_KeyDown);
        }

        #endregion
        
        private void formClosed(object sender, FormClosedEventArgs e)
        {
                //client.commander.killThisProcess();
            threadClose();
            //programEnd(false);
        }

        ///////////////////
        #region GUI control
        /////////////////// 
         

        public delegate void DelegateRefreshGUI(string sMsg);
        DelegateRefreshGUI delGUI;
        public delegate void DelegateButton(int arg);
        DelegateButton delButton;

        void guiAddTextInv(string msg) 
        { 
            mainTextBox.Text = mainTextBox.Text + msg;
            mainTextBox.SelectionStart = mainTextBox.TextLength;
            mainTextBox.ScrollToCaret();  // Scroll置底?
        } 

        void guiChangeButtonColorInv(int newMode)
        {
            if (newMode == Common.SERVER_MODE)
            {
                this.serverButton.BackColor = Color.FromName("DarkSeaGreen"); 
                this.clientButton.BackColor = Color.FromName("Control");
            }
            else if (newMode == Common.CLIENT_MODE)
            {
                this.clientButton.BackColor = Color.FromName("DarkSeaGreen");
                this.serverButton.BackColor = Color.FromName("Control");
            }
        }

        ///
        
        public void guiChangeButtonColor(int newMode)
        {
            delButton = new DelegateButton(guiChangeButtonColorInv);
            this.BeginInvoke(delButton, newMode);
        }

        public void guiAddText(string msg)
        {
            // thread safe because of invoke
            delGUI = new DelegateRefreshGUI(guiAddTextInv);
            this.BeginInvoke(delGUI, msg + "\r\n");
        }

        #endregion


        ///////////////////
        #region  Error Handling
        ///////////////////

        public void errorClose(string errMsg)
        {
            if (progState == "Running")
            {
                LoggerGUI.logError(errMsg);
                //mainProg.programEnd(false);
                MessageBox.Show(errMsg);
                progState = "End";
            }
            if (threadClose() == false)
                Environment.Exit(1);
        }

        bool threadClose()
        {
            if ( curMode == Common.SERVER_MODE )
            {
                bool c = clientClose();
                bool s = serverClose();
                return c & s ;
            }
            else if ( curMode == Common.CLIENT_MODE )
                return clientClose();
            else  return true;
        }

        bool serverClose()
        {
            if (  serverThread == null)
                    return false;
                server.end();
                serverThread.Abort(); // close Thread.
            return true;
        }
        bool clientClose()
        {
            if (  clientThread == null)
                    return false;
                client.end();
                clientThread.Abort(); // close Thread.
                return true;
        }

        #endregion

    }
}
