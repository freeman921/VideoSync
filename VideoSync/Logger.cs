using System;
using System.IO;

public class Logger
{
    static StreamWriter fileOut;
    static string filePath;

    public static void init(string curPath, string saveName)
    {
        String nowTime = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToLongTimeString();
        nowTime = nowTime.Replace("/", "-").Replace(":", "-");

        // crate dir if not exist
        if (Directory.Exists(curPath + "\\Log") == false)
            Directory.CreateDirectory(curPath + "\\Log");

        filePath = curPath + "\\Log\\log_" + saveName + ".txt";
        fileOut = new StreamWriter(filePath, true); // append = true
        log("\r\n---- Log Date : " + nowTime + "----\r\n");
    }

    public static void log(string msg)
    {
        Console.WriteLine(msg);
        fileOut.WriteLine(msg);
        fileOut.Flush();
    }
    public static void logTitle(string msg)
    {
        log("### " + msg + " ###");
    }
    public static void logError(string msg)
    {
        log("!!!!!   Error   !!!!!\r\n" + msg);
    }
    public static void close() { fileOut.Close(); }
} // Logger
