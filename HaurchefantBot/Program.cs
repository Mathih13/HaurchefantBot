using System;

namespace HaurchefantBot
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Starting HaurchefantBot...");
			Console.WriteLine("Updating reddit json...");

			JSONHandler handler = new JSONHandler();



			HaurchefantBot haurchefant = new HaurchefantBot(handler);

		}



	}
}
