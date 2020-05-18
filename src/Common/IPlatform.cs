namespace Common
{
    public interface IPlatform
    {
        /// <summary>
        /// Method to call to set wallpaper on the respective OS platform.
        /// </summary>
        /// <param name="filePath"></param>
        public void SetWallpaper(string filePath);
    }
}