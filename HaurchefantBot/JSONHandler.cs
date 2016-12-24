using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace HaurchefantBot
{
	public class JSONHandler
	{

		List<String> lastPostedLinks;

		SampleClass redditClass;

		public JSONHandler()
		{
			UpdateRedditInfo();
			lastPostedLinks = new List<String>();


		}

		public void UpdateRedditInfo() { 
			var json = new WebClient().DownloadString("https://www.reddit.com//r/youtubehaiku/top/.json?limit=10");

			string s = json;

			redditClass = JsonConvert.DeserializeObject<SampleClass>(s);
			Console.WriteLine("Updated Reddit JSON from: " + "https://www.reddit.com//r/youtubehaiku/top/.json?limit=10");
		}


		public string GetYouTubeLink() {

			for (int i = 0; i < redditClass.data.children.Length; i++)
			{
				if (!lastPostedLinks.Contains(redditClass.data.children[i].data.url))
				{
					lastPostedLinks.Add(redditClass.data.children[i].data.url);
					return redditClass.data.children[i].data.url;
				}
			}

			// If we get here we are out of links?
			ResetLinks();
			return "Out of links. Try again in a minute!";


		}

		public void ResetLinks() {
			UpdateRedditInfo();
			lastPostedLinks.Clear();
		}

	}





	public class Oembed
	{
		public string provider_url;
		public string title;
		public string html;
		public int thumbnail_width;
		public int height;
		public int width;
		public string version;
		public string author_name;
		public string provider_name;
		public string thumbnail_url;
		public string type;
		public int thumbnail_height;
		public string author_url;
	}

	public class SecureMedia
	{
		public string type;
		public Oembed oembed;
	}

	public class SecureMediaEmbed
	{
		public string content;
		public int width;
		public bool scrolling;
		public int height;
	}

	public class Oembed2
	{
		public string provider_url;
		public string title;
		public string html;
		public int thumbnail_width;
		public int height;
		public int width;
		public string version;
		public string author_name;
		public string provider_name;
		public string thumbnail_url;
		public string type;
		public int thumbnail_height;
		public string author_url;
	}

	public class Media
	{
		public string type;
		public Oembed2 oembed;
	}

	public class Source
	{
		public string url;
		public int width;
		public int height;
	}

	public class Resolution
	{
		public string url;
		public int width;
		public int height;
	}

	public class Variants
	{
	}

	public class Image
	{
		public Source source;
		public Resolution[] resolutions;
		public Variants variants;
		public string id;
	}

	public class Preview
	{
		public Image[] images;
	}

	public class MediaEmbed
	{
		public string content;
		public int width;
		public bool scrolling;
		public int height;
	}

	public class Data2
	{
		public bool contest_mode;
		public object banned_by;
		public string domain;
		public string subreddit;
		public object selftext_html;
		public string selftext;
		public object likes;
		public object suggested_sort;
		public object[] user_reports;
		public SecureMedia secure_media;
		public bool saved;
		public string id;
		public int gilded;
		public SecureMediaEmbed secure_media_embed;
		public bool clicked;
		public object report_reasons;
		public string author;
		public Media media;
		public string name;
		public int score;
		public object approved_by;
		public bool over_18;
		public object removal_reason;
		public bool hidden;
		public Preview preview;
		public string thumbnail;
		public string subreddit_id;
		public bool edited;
		public string link_flair_css_class;
		public object author_flair_css_class;
		public int downs;
		public object[] mod_reports;
		public bool archived;
		public MediaEmbed media_embed;
		public string post_hint;
		public bool is_self;
		public bool hide_score;
		public bool spoiler;
		public string permalink;
		public bool locked;
		public bool stickied;
		public double created;
		public string url;
		public object author_flair_text;
		public bool quarantine;
		public string title;
		public double created_utc;
		public string link_flair_text;
		public object distinguished;
		public int num_comments;
		public bool visited;
		public object num_reports;
		public int ups;
	}

	public class Child
	{
		public string kind;
		public Data2 data;
	}

	public class Data
	{
		public string modhash;
		public Child[] children;
		public string after;
		public object before;
	}

	public class SampleClass
	{
		public string kind;
		public Data data;
	}

}
