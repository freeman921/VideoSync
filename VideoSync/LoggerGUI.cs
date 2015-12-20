using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection; // class Missing
using System.IO; // Directory
using System.Windows.Forms;

namespace VideoSyncSpace
{
    public class LoggerGUI
    {
        static MainGUI orgClass;

        public static void init(MainGUI orggg, string curPath, string saveName)
        {
            orgClass = orggg;
            Logger.init(curPath, saveName);
        }

        public static void log(string msg)
        {
            Logger.log(msg);
        }
        public static void logTitle(string msg)
        {
            log("### " + msg + " ###");
                //orgClass.guiChangeTitle(msg);
        }
        public static void logError(string msg) 
        {
            String err = "!!!!!   Error   !!!!! ";
            MessageBox.Show(msg,err);
            logForUser(err + msg);
        }
        public static void logForUser(string msg)
        {
            Logger.log(msg);
            orgClass.guiAddText(msg);
        }

        public static void close() { Logger.close(); }
    } // LoggerGUI

    
}
