# Home for elegant desktop wallpapers
This is a cross platform command line interface to set beautiful images as desktop background from the internet irrespective of the Platform or OS. 

*Current Features :*
- Bing Homepage image as wallpaper
- Random HD image from internet as wallpaper
- Configurable topics for downloading images from internet

*Upcoming Features :*
- ~~Configurable topics for downloading images from internet~~
- AI (automatically set wallpaper based on the day, like Chrismas wallpaper for 25th Dec)

Download the latest from the [releases](https://github.com/sudipmandal/any-os-wallpaper-cli/releases).

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


