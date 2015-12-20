using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Threading;

namespace VideoSyncSpace
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //test();
            Application.Run( new MainGUI() );
            
        }

        static void test()
        {
            Thread[] thread = new Thread[4];

            for (int i = 0; i < 4; i++)
            {
                thread[i] = new Thread(() => function(i));
                thread[i].Start();
            }
            Thread.Sleep(100000);
            Console.ReadLine();
        }

        static void function(int num)
        {
            Thread.Sleep(1000);
            Console.WriteLine(num);
        }

    }
}
