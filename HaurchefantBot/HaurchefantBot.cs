using System;
using System.IO;
using Discord;
using Discord.Commands;
using System.Collections.Generic;

namespace HaurchefantBot
{
	public class HaurchefantBot
	{
		Random rng;
        DiscordClient client;
		CommandService commands;

        Dictionary<String, String> SimpleReply;
        Dictionary<String, String[]> RandomReply;
        Dictionary<String, String[]> TriggerWords;

        HaurchefantData data;
        JSONHandler handler;

        enum randomtype { Text, Image };

        public HaurchefantBot(JSONHandler h)
		{
            handler = h;
            RandomReply = new Dictionary<String, String[]>();
            SimpleReply = new Dictionary<String, String>();
            TriggerWords = new Dictionary<String, String[]>();

            rng = new Random();
            data = new HaurchefantData();

            /*   listOfCommands = new String[] {
                  "Hello", "How are you?", "You're so beautiful", "Help", "Do you love me?", "Commands", "dank meme", "update your links"
              };
              */

            RandomReply.Add("How are you?", data.quips);
            RandomReply.Add("You're so beautiful", data.images);

            SimpleReply.Add("Help", data.helpText);

            TriggerWords.Add("diablo", data.noDiablo);
            TriggerWords.Add("futa", data.futaJokes);

            #region Connection
            client = new DiscordClient(x =>
			{
				x.LogLevel = LogSeverity.Info;
				x.LogHandler = Log;
			});



			client.UsingCommands(input =>
			{
				
				input.AllowMentionPrefix = true;

			});

			commands = client.GetService<CommandService>();
            #endregion


            RegisterMemeCommand("dank meme");
            RegisterRandomReplyCommand("How are you?", randomtype.Text);
            RegisterRandomReplyCommand("You're so beautiful", randomtype.Image);
            RegisterStringCommand("Help");

            RegisterTriggerMessage("futa", true);
            RegisterTriggerMessage("diablo");



            #region Special Commands
            commands.CreateCommand("Do you love me?")
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

            commands.CreateCommand("Refresh")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Alright, refreshing my memes!");
                    handler.ResetLinks();

                });

            commands.CreateCommand("Shutdown")
                .Do(async (e) =>
                {
                    if (e.User.Name == "Matih")
                    {
                        await client.Disconnect();
                        MainClass.ShutDown();
                    }

                });

            commands.CreateCommand("Restart")
                .Do(async (e) =>
                {
                    if (e.User.Name == "Matih")
                    {
                        await client.Disconnect();
                        MainClass.Restart();
                    }

                });


            client.MessageReceived += async (s, e) => {
                if (!e.Message.IsAuthor)
                {
                    if (rng.Next(1, 60) == 1)
                    {
                        var i = rng.Next(0, data.sillyStuff.Length);
                        await e.Channel.SendMessage(data.sillyStuff[i]);
                    }
                }
            };

            #endregion


            client.ExecuteAndWait(async () =>
			{
				await client.Connect("MjU3MTE4MTc3NjU2MzA3NzEy.Cy2Fgg.sDWagor3gQD1NHqDwZ1g4Z_gCsM", TokenType.Bot);
			});


		}







		private void Log(object sender, LogMessageEventArgs e)
		{
			Console.WriteLine(e.Message);
		}




        void RegisterTriggerMessage(String word, bool RNG = false)
        {
            if (RNG)
            {
                client.MessageReceived += async (s, e) =>
                {
                    if (!e.Message.IsAuthor)
                    {
                        if (e.Message.Text.Contains(word))
                        {
                            if (rng.Next(0, 8) == 8)
                            {
                                await e.Channel.SendMessage(TriggerWords[word][rng.Next(0, TriggerWords[word].Length)]);
                            }
                        }
                    }
                };
            }
            else {
                client.MessageReceived += async (s, e) =>
                {
                    if (!e.Message.IsAuthor)
                    {
                        if (e.Message.Text.Contains(word))
                        {
                            await e.Channel.SendMessage(TriggerWords[word][rng.Next(0, TriggerWords[word].Length)]); 
                        }
                    }
                };
            }

            
        }





        void RegisterMemeCommand(String command) {

            commands.CreateCommand(command)
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage(handler.GetYouTubeLink());
                    });
        }



        void RegisterStringCommand(String command)
        {

            String reply = SimpleReply[command];

            commands.CreateCommand(command)
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage(reply);
            });
        }





        void RegisterRandomReplyCommand(String command, randomtype type) {

            if (type == randomtype.Text)
            {
                commands.CreateCommand(command)
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage(RandomReply[command][rng.Next(0, RandomReply[command].Length)]);
                    });
            }

            if (type == randomtype.Image)
            {
                commands.CreateCommand(command)
                    .Do(async (e) =>
                    {
                        await e.Channel.SendMessage("I know.");
                        await e.Channel.SendFile(Directory.GetCurrentDirectory() + "/images/" + RandomReply[command][rng.Next(0, RandomReply[command].Length)]);
                    });
            }
            

        }




     
    }

}
