using System;
using System.IO;
using Discord;
using Discord.Commands;

namespace HaurchefantBot
{
	public class HaurchefantBot
	{
		Random rng;

		// TODO: Bad database. Go think about what you've done
		String[] quips;
		String[] images;
		String[] listOfCommands;

		DiscordClient client;
		CommandService commands;

		public HaurchefantBot()
		{
			Console.WriteLine("Starting...");

			listOfCommands = new String[] { 
				"Hello", "How are you?", "You're so beautiful", "Help", "Do you love me?"
			};

			rng = new Random();
			quips = new String[] { 
				"Well I'm dead, so there's that...",
				"A knight lives to serve─to aid those in need.",
				"Ah bloo bloo bloo",
				"*Cleans WoLs drool off his armor*",
				"*dabs*"
			};

			images = new String[] { 
				"haurche1.png",
				"haurche2.jpg",
				"haurche3.jpg",
				"haurche4.jpg",
				"haurche5.png"
			};


			client = new DiscordClient(x =>
			{
				x.LogLevel = LogSeverity.Info;
				x.LogHandler = Log;
			});



			client.UsingCommands(input =>
			{
				input.PrefixChar = '!';
				input.AllowMentionPrefix = true;

			});

			commands = client.GetService<CommandService>();


			commands.CreateCommand(listOfCommands[0])
					.Do(async (e) =>
						{
							await e.Channel.SendMessage("Hi!");
						});

			commands.CreateCommand(listOfCommands[1])
					.Do(async (e) =>
						{
							var i = rng.Next(0, quips.Length);
							await e.Channel.SendMessage(quips[i]);
						});

			commands.CreateCommand(listOfCommands[2])
					.Do(async (e) => { 
						var i = rng.Next(0, images.Length);
						await e.Channel.SendMessage("I know.");
						await e.Channel.SendFile(Directory.GetCurrentDirectory() + "/images/" + images[i]);
					});


			commands.CreateCommand(listOfCommands[3])
					.Do(async (e) =>
						{
							await e.Channel.SendMessage("Fear not, Warrior! The Knight serves you!");
							await e.Channel.SendMessage(":trident: Haurchefant Bot v1 - A Tiny, Undead, Robot Knight :trident:");
							await e.Channel.SendMessage("Commands:");
							await e.Channel.SendMessage("'Hello' - Say hello to me!");
							await e.Channel.SendMessage("'How are you?' - Get me to say funny stuff!");
							await e.Channel.SendMessage("'You're so beautiful' - I'll prove it with an image of myself!");
						});

			commands.CreateCommand(listOfCommands[4])
					.Do(async (e) =>
						{
							if (e.User.Name == "fujoshit")
							{
								await e.Channel.SendMessage("With all my heart, Guy!");
							}
							else {
								await e.Channel.SendMessage("My heart belongs to Guy, " + e.User.Name);
							}

						});

			client.ExecuteAndWait(async () =>
			{
				await client.Connect("MjU3MTE4MTc3NjU2MzA3NzEy.Cy2Fgg.sDWagor3gQD1NHqDwZ1g4Z_gCsM", TokenType.Bot);
			});




		}

		private void Log(object sender, LogMessageEventArgs e)
		{
			Console.WriteLine(e.Message);
		}

	}

}
