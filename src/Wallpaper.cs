using System;
using Common;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace wallpaper
{
    public class Wallpaper
    {
        internal static void SetWallpaperFromSource(string sourceName)
        {
            //Find required source
            IWallpaperSource source = (IWallpaperSource)Activator.CreateInstance(Utils.sourceMap[sourceName]);
            var wallpaperPath = source.DownloadWallpaper();

            IPlatform platform = null;
            if(RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                platform = new Platform.Linux();

            if(RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                platform = new Platform.Windows();

            if(RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                platform = new Platform.OSX();

            if(platform != null)
                platform.SetWallpaper(wallpaperPath);
            
        }
    }
}