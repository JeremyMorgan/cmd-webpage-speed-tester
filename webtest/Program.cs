using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace webtest
{
	class Program
	{

		public static bool loadPage(string url)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			Stream resStream = response.GetResponseStream();
			return true;
		}

		static void Main(string[] args)
		{		

			if (args.Length == 0)
			{
				Console.WriteLine("Usage: webtest.exe [URL]");
			}
			else {

			string url = args[0];

			Stopwatch stopWatch = new Stopwatch();
			stopWatch.Start();
			loadPage(url);
			stopWatch.Stop();

			TimeSpan ts = stopWatch.Elapsed;

			string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
			ts.Hours, ts.Minutes, ts.Seconds,
			ts.Milliseconds / 10);

			Console.WriteLine("Page Loaded in " + elapsedTime);

			}
		}
	}
}
