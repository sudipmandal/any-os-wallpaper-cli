# Home for elegant desktop wallpapers
This is a cross platform command line interface to set beautiful images as desktop background from the internet irrespective of the Platform or OS. 

Download the latest from the [releases](https://github.com/sudipmandal/any-os-wallpaper-cli/releases).

You may need to install the dotnet core 3.1 runtime framework if not already installed
[https://dotnet.microsoft.com/download/dotnet-core/3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

### To set random wallpaper

Simply run the program to set a random wallpaper. (First run will be slow, consecutives runs will be faster)

### To set Bing Homepage image as your wallpaper

- Windows Users 
  From command promt or powershell : `wallpaper.exe -s Bing`
- Linux Users
  From bash or equivalent : `./wallpaper -s Bing`
  
## Important Note for Linux Users
Due to the hundreds of desktop environments for linux, the program may simply be unable to set the wallpaper for your desktop environment, if you are in this boat dont worry do the following

- Create a file called *script.sh* in the folder containing the wallpaper app
- Write the script which works on your desktop to change the wallpaper using `$1` as the path of the new wallpaper
- Ensure the file is executable and run wallpaper again... Viola it should now work for your desktop.

For eg (for debian/ubuntu/deepin desktops the script.sh could look like below)

`gsettings set org.gnome.desktop.background picture-uri $1`

here $1 will be the path of the image downloaded by wallpaper.

