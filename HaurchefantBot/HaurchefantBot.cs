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
        String[] futaJokes;
        String[] sillyStuff;

        DiscordClient client;
		CommandService commands;

		public HaurchefantBot(JSONHandler handler)
		{

            // TODO: Dictionary this you dumb
			listOfCommands = new String[] { 
				"Hello", "How are you?", "You're so beautiful", "Help", "Do you love me?", "Commands", "dank meme", "update your links"
			};

			rng = new Random();
			quips = new String[] { 
				"Well I'm dead, so there's that...",
                "*dabs*",
                "A knight lives to serve─to aid those in need.",
				"Ah bloo bloo bloo",
				"*Cleans WoLs drool off his armor*"
				
			};

			images = new String[] { 
				"haurche1.png",
				"haurche2.jpg",
				"haurche3.jpg",
				"haurche4.jpg",
				"haurche5.png"
			};

            futaJokes = new String[] {
                "Tbh, I wish the Warrior of Light had a feminine penis...",
                "Mmm, futa.",
                "Do you guys thing the Warrior of Light has a girlc- nevermind.",
				"It's not gay if she doesn't have balls",
				">she",
				"https://www.youtube.com/watch?v=fRkXSgjd4XQ&feature=youtu.be"

            };

            sillyStuff = new String[] {
                "A smile... Better suits... A hero...",
                "*tiny sad violin*",
                "Hey what about 'We are Number One', but everytime 'one' is played it is replaced with a Final Fantasy cutscene?",
                "The people who love anime more than real life have it figured out",
                "If I was to play Overwatch I think my main would be Lucio",
                "That Laz guy on youtube makes some pretty funny Overwatch videos",
				"<:widowmemer:247818678408577024>",
				"<:barrybee:240215495175831562>",
				"<:peep:236234509253607425>",
				"<:toddhoward:247820078916042752>",
				"Pickles are ruining my life",
				"I raid you guys",
				"Tbh, I like face 4 MaleRa..."

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
							await e.Channel.SendMessage(":trident: Haurchefant Bot v1.1 - A Tiny, Undead, Robot Knight :trident:");
                            await e.Channel.SendMessage("Type !Commands for help with commands!");
                            await e.Channel.SendMessage("What's new: Expanded vokabulary, decreased my intellect. Lowered risk of turning into SkyNet");

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

            commands.CreateCommand(listOfCommands[5])
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("'Hello' - Say hello to me!");
                        await e.Channel.SendMessage("'How are you?' - Get me to say funny stuff!");
                        await e.Channel.SendMessage("'You're so beautiful' - I'll prove it with an image of myself!");

                    });

			commands.CreateCommand(listOfCommands[6])
					.Do(async (e) =>
					{
						await e.Channel.SendMessage(handler.GetYouTubeLink());

					});

			commands.CreateCommand(listOfCommands[7])
					.Do(async (e) =>
					{
						await e.Channel.SendMessage("Alright, refreshing my memes!");
						handler.ResetLinks();

					});


           
            client.MessageReceived += async (s, e) => {
                if (!e.Message.IsAuthor)
                {
                    if (e.Message.Text.Contains("Diablo 3") || e.Message.Text.Contains("diablo 3") || e.Message.Text.Contains("Diablo"))
                    {
                        await e.Channel.SendMessage("<:nodiablo:243032600468258817>");
                    }
                }
            };


            client.MessageReceived += async (s, e) => {
                if (!e.Message.IsAuthor)
                {
                    if (e.Message.Text.Contains("futa"))
                    {
                        if (rng.Next(1, 7) == 1)
                        {
                            var i = rng.Next(0, futaJokes.Length);
                            await e.Channel.SendMessage(futaJokes[i]);

                        }
                    }
                }
            };

            client.MessageReceived += async (s, e) => {
                if (!e.Message.IsAuthor)
                {
                    if (rng.Next(1, 50) == 1)
                    {
                        var i = rng.Next(0, sillyStuff.Length);
                        await e.Channel.SendMessage(sillyStuff[i]);
                    }
                }
            };


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
