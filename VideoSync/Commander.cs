using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace VideoSyncSpace
{
    class Commander
    {
        String playerProcessName;
        Process playerProcess;
        IntPtr windowHandle;
        public bool tempSwitch = false;  // false = not pressed yet.

        public Commander(String procName) 
        { 
            playerProcessName = procName;
            windowHandle = getProcessAndHandle(procName);
        }

        // Get a handle to an application window.
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("USER32.DLL")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("USER32.DLL")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [DllImport("USER32.DLL")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// Command Functions to Media Player.
        /// </summary>


        public void do_pause_play(String timeline)
        {
            SwitchToThisWindow(windowHandle, true);
            SendKeys.SendWait(" g" + timeline +"{ENTER}{ESC}");
        }

        [STAThread]
        public String getCurTimeline() 
        {
            SwitchToThisWindow(windowHandle, true);
            SendKeys.SendWait("g");
            // important for PotPlayer !!  no delay -> it could have cmd fail.
            Thread.Sleep(100); 
            SendKeys.SendWait("^c{ESC}");
            IDataObject data = Clipboard.GetDataObject();
            if (data.GetDataPresent(DataFormats.Text))
            {
                LoggerGUI.log("*****Got Video Timeline: " + data.GetData(DataFormats.Text).ToString() );
                return data.GetData(DataFormats.Text).ToString();
            }
            return "wrong";
        }
        public String getCurTitle() { return playerProcess.MainWindowTitle; }
        public bool playerOnFocus()
        {
            IntPtr focusWin = GetForegroundWindow();
            return focusWin == windowHandle;
        }
        
        //public void do_paste_timeline() { SendKeys.SendWait("g^v{ENTER}{ESC}"); }

        private IntPtr getProcessAndHandle(String processName)
        {
            Process[] procs = Process.GetProcessesByName(processName);

            if (procs.Length == 0)
            {
                LoggerGUI.logError("找不到指定程序 (" + processName + ")");
                return IntPtr.Zero;
            }
            else
            {
                if ((procs.Length > 1))
                    LoggerGUI.logError("Found 2 or more (" + processName + ") , Did you opened 2 player ?");
                playerProcess = procs[0];
            }

            return playerProcess.MainWindowHandle;
        }

        /*
        public void killThisProcess()
        {
            getProcessAndHandle("VideoSync");
            playerProcess.Kill();
        }*/
 
    } // class Commander
} // namsspace
