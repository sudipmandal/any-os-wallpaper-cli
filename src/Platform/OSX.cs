using System.Diagnostics;
using Common;

namespace Platform
{
    public class OSX : IPlatform
    {
        public void SetWallpaper(string filePath)
        {
            //Fingers crossed this works
            //I am not rich enough to test this :) - no mac

            string osxCommand = $"osascript -e 'tell application \"Finder\" to set desktop picture to POSIX file \"{filePath}\"'";
            Process.Start("bash",$"-c {osxCommand}");
        }
    }
}