using System;
using System.Linq;
using System.Collections.Generic;

namespace wallpaper
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length == 0)
            {
                //Select a random source and set wallpaper
                Wallpaper.SetWallpaperFromSource(Common.Utils.sourceMap.Keys.First());
            }
            else
            {
                switch (args[0])
                {
                    case "-h": case "--help" :
                        //display help
                        break;
                    case "-ls":
                        Console.WriteLine("Available Sources :");
                        foreach (var sourceName in Common.Utils.sourceMap.Keys)
                        {
                            Console.WriteLine("\t" + sourceName);
                        }
                        break;
                    case "-u":
                        //set wallpaper from specified source
                    default:
                        //display help
                        break;
                    
                }
            }
        }
    }
}
