using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Net;
using Newtonsoft.Json.Linq;

namespace Common
{
    public class Utils
    {
        internal static JObject GetConfig()
        {
            var configPath  = Utils.GetExeFolder() + "/config.json";
            if(File.Exists(configPath))
            {
                try
                {
                    JObject configObj = JObject.Parse(File.ReadAllText(configPath));
                    return configObj;
                    
                }
                catch {}
            }
            return null;
        }

        private static Dictionary<string,Type> _sourceMap;
        public static Dictionary<string,Type> sourceMap { get{
            if(_sourceMap == null)
                _sourceMap = GetSourcesMap();
            
            return _sourceMap;

        } private set
        { 
            _sourceMap = value;
        }}


        internal static string GetExeFolder()
        {
#if DEBUG
           
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
#else
            return Environment.CurrentDirectory;
#endif

        }

        internal static string DownloadUrlToDisk(string url)
        {
            WebClient wc = new WebClient();
            string pathToSave = Utils.GetExeFolder() + "/wallpaper.jpg";
            wc.DownloadFile(url, pathToSave);

            return pathToSave;
        }

        static Dictionary<string,Type> GetSourcesMap()
        {
            Dictionary<string,Type> map = new Dictionary<string, Type>();
            var sourceTypes = Assembly.GetExecutingAssembly().GetTypes()
                                    .Where(x => typeof(IWallpaperSource).IsAssignableFrom(x) 
                                                && x.IsClass)
                                                .ToList();
            foreach (var t in sourceTypes)
            {
                var wsource = Activator.CreateInstance(t) as IWallpaperSource;
                map.Add( wsource.Name(), t);
            }

            return map;
        }

        
    }
}