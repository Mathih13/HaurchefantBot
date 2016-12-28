using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaurchefantBot
{
    class HaurchefantData
    {

        public String[] quips { get; protected set; }
        public String[] images { get; protected set; }
        public String[] futaJokes { get; protected set; }
        public String[] sillyStuff { get; protected set; }
        public String[] noDiablo;
		public String[] fuckOff;


        public String helpText { get; protected set; }

        public HaurchefantData() {


            noDiablo = new String[] {
                "<:nodiablo:243032600468258817>"
            };
           

            helpText = "```Fear not, Warrior!The Knight serves you!\n\n### Haurchefant Bot v1.2 - A Tiny, Undead, Robot Knight ###\n\nType Commands for help with commands!\n\nWhat's new: Linking random meme videos, bugfixes and refactoring, less talkative, base for future custom commands added.```";


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

			fuckOff = new String[] {
				"<:peep:236234509253607425>",
				":(",
				"Aww..",
				"Duel me!",
				"B-but.."

			};
                
        }

    }
}
