using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace VideoSyncSpace
{
    public class Common
    {
        // Commons
        public const int PORT = 9527;
        public const int MAX_FILENAME_LEN = 256+1;

        // Mode
        public const int NO_MODE = 0;
        public const int SERVER_MODE = 1; 
        public const int CLIENT_MODE = 2;

        // Play State
        public const bool STATE_PLAY = true;
        public const bool STATE_PAUSE = false;

        // Player Settings
        public const string PLAYER_CLASSNAME = "PotPlayer";

        // Commands
        public const string CMD_PAUSE = "pause";

        // Keyboard Hotkeys
            //public const string Pause = " ";
        public const string MOVE_TO_HOSTS_TIME = "";
        public const int VKCODE_PAUSE = 0x20;
        
    }

    //public class CMD

    [Serializable]
    public class MSG
    {
        public String curVideo;
        public String cmd;
        public String curTimeLine;
        public String senderAddress;
        public bool curPlayState;

        public MSG(String curVideo, String cmd, String curTimeLine)
        {
            this.curVideo = curVideo;
            this.cmd = cmd;
            this.curTimeLine = curTimeLine;
        }
    }
}
