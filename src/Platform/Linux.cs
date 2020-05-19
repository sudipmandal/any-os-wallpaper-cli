using System;
using System.Diagnostics;
using System.IO;
using Common;
namespace Platform
{
    public class Linux : IPlatform
    {
        //Linux has like a million desktops and there is no one way to handle all of them 
        //We will try to target major ones and provide a mechanism for users of other linux
        //desktops to provide their own script to set their wallpaper.
        public void SetWallpaper(string filePath)
        {
            //check if script.sh is present, if so use the user script to set desktop background 
            //else try to determine desktop and set for supported ones
            string userScriptFile = Utils.GetExeFolder() + "/script.sh";
            if(File.Exists(userScriptFile))
            {
                //call the script with filepath parameter
                Bash(userScriptFile + " \"" + filePath + "\"");
            }
            else
            {
                string setWallpaperCmd = "gsettings set org.gnome.desktop.background picture-uri " + filePath;
                Bash(setWallpaperCmd);
            }

            
        }
        string Bash(string cmd)
        {
            var escapedArgs = cmd.Replace("\"", "\\\"");
            
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "/bin/bash",
                    Arguments = $"-c \"{escapedArgs}\"",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return result;
        }


    }
}