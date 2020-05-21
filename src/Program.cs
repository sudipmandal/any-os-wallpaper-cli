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
                Wallpaper.SetWallpaperFromSource("RandomFromWeb");
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
                    case "-s":
                        //set wallpaper from specified source
                        if (args.Length < 2)
                            Console.WriteLine("Source not specified");
                        else if (args.Length > 2)
                            Console.WriteLine("Invalid number of arguments\n correct format is wallpaper -s SOURCENAME");
                        else
                        {
                            string usrSel = args[1];
                            //check if this is a valid source name
                            if (!Common.Utils.sourceMap.Keys.Contains(usrSel))
                                Console.WriteLine("Soruce {0} not found. \n To view list of valid sources run : wallpaper -ls");
                            else
                                Wallpaper.SetWallpaperFromSource(usrSel);
                        }
                        
                        break;
                    default:
                        //display help
                        break;
                    
                }
            }
        }
    }
}
