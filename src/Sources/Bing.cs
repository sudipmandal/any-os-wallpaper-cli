
using System;
using System.Net;
using Common;
using Newtonsoft.Json.Linq;

namespace Sources
{
    public class Bing : IWallpaperSource
    {
        public string DownloadWallpaper()
        {
            WebClient wc = new WebClient();
            string jsonString = wc.DownloadString("http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n=1&pid=hp");

            JObject result = JObject.Parse(jsonString);
            string imgURL = "http://bing.com" + result["images"][0]["url"].ToString();
            

            return Utils.DownloadUrlToDisk(imgURL);
        }

        public string Name()
        {
            return "Bing";
        }
    }
}