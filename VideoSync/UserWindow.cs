/*
 *  The Main Program 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;



namespace Wifi_ATS
{
    public class UserWindow : MainGUI
    {
        public const string EndPoint_IP = "127.0.0.1";
        public const string CONFIG_FILE = "Config.xlsx";
        public const string MODULE_FILE = "Module.txt";

        ArrayList connectlist;

        public UserWindow() : base() { mainProg = this; }

        public override void progamStart()
        {
            init();
            //new Test().chariot();
            //new Test().pingTest();
            //new Test().classTest();
            //new Test().connectAndTelnet();
            

            programEnd(true);
        }

        void init()
        {
            
        }

        public override void programEnd(bool success)
        {
            

            if (success == true)
            {
                LoggerGUI.logTitle("Test Finished");
                LoggerGUI.log("歡迎下次光臨");
            }
            else
            {
                LoggerGUI.logTitle("Test Abort");
                LoggerGUI.log("請洽 Administrator");
            }
            LoggerGUI.close();
        }

    }
}
