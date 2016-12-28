using System;
using System.IO;
using System.Threading;

namespace HaurchefantBot
{
	class MainClass
	{
        static HaurchefantBot bot;
        static JSONHandler handler;
        static Thread child;

		public static void Main(string[] args)
		{

            Thread th = Thread.CurrentThread;
            th.Name = "Main";
			Console.WriteLine("Updating reddit json...");
            handler = new JSONHandler();

            Start();
            Console.ReadKey();

        }

        public static void BotThread() {
            bot = new HaurchefantBot(handler);
        }

        public static void ShutDown() {
            Console.WriteLine("Stopping HaurchefantBot...");
            child.Abort();

        }

        public static void Start() {
            Console.WriteLine("Starting HaurchefantBot...");
            ThreadStart childref = new ThreadStart(BotThread);
            child = new Thread(childref);
            child.Start();
        }

        public static void Restart()
        {
            ShutDown();
            Start();
        }



    }
}
