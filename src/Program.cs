using System;

namespace wallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                //Select a random source and set wallpaper
            }
            else
            {
                switch (args[0])
                {
                    case "-h": case "--help" :
                        //display help
                        break;
                    case "-ls":
                        //list sources
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
