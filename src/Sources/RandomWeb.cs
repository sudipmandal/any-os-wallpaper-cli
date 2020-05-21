using Common;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Net.Http;

namespace Sources
{
    public class RandomWeb : IWallpaperSource
    {
        //FUTURE : We can make this user configurable, so that user can define own wallpaper topics to search internet from
        string[] topics = new string[] { "Mountains", "Birds", "Nature", "Sunset", "Galaxy", "Rivers", "Flowers", "Animals", "Abstract" };

        public string DownloadWallpaper()
        {
            //Pick a random item from the topics array
            Random randomGen = new Random();
            int topicNo = randomGen.Next(0, topics.Length - 1);
            string topic = topics[topicNo];

            //Search Bing images using this topic

            string bingImagesUrl = $"https://bing.com/images/search?q={topic}&qft=+filterui:imagesize-wallpaper&FORM=IRFLTR";
        
            HttpClient wc = new HttpClient();
            wc.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.138 Safari/537.36");
            wc.DefaultRequestHeaders.Add("Accept", "*/*");
            var data = wc.GetStringAsync(bingImagesUrl).Result;

            //Scrape out the image urls using regex

            Regex regex = new Regex("(?<=murl\\&quot;:\\&quot;)(.|\n)*?(?=\\&quot;,\\&quot;turl)");
            var matches = regex.Matches(data);


            //Pick a random url

            var urls = matches.Select(x => x.Value).Where(p => p.EndsWith("jpg") || p.EndsWith("png") || p.EndsWith("jpeg")).ToList();

            var sUrl = urls[randomGen.Next(0, urls.Count - 1)];

            //Download file and return path
            return Utils.DownloadUrlToDisk(sUrl);
        }

        public string Name()
        {
            return "RandomFromWeb";
        }
    }
}
