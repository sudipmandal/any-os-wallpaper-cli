using System;
using Common;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Win32;


namespace Platform
{
    public class Windows : IPlatform
    {
        const int SPI_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINIFILE = 0x01;
        const int SPIF_SENDWININICHANGE = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public void SetWallpaper(string filePath)
        {
            string windowsBmpPath = Utils.GetExeFolder() + "/wallpaper.bmp";
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var image = new Bitmap(fs))
                {
                    image.Save(windowsBmpPath, ImageFormat.Bmp);
                }
            }

            //Fix for some systems blocking wallpaper change
            try
            {
                RegistryKey k = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\ActiveDesktop", true);
                k.SetValue(@"NoChangingWallpaper", "0");
            }
            catch { }



            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            //Wallpaper style streched

            key.SetValue(@"WallpaperStyle", "2");
            key.SetValue(@"TileWallpaper", "0");

            SystemParametersInfo(SPI_SETDESKWALLPAPER,
                0,
                windowsBmpPath,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }


    }

}