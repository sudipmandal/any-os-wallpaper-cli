using System;
using System.Diagnostics;
using Common;
namespace Platform
{
    public class Linux : IPlatform
    {
        public void SetWallpaper(string filePath)
        {
            string setWallpaperCmd = "gsettings set org.gnome.desktop.background picture-uri " + Utils.GetExeFolder() + "/wallpaper.jpg";
            Bash(setWallpaperCmd);
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