namespace Common
{
    public interface IWallpaperSource
    {
        /// <summary>
        /// Function to Download wallpaper from the source
        /// </summary>
        /// <returns>File path of the downloaded wallpaper</returns>
        public string DownloadWallpaper();
    }
}