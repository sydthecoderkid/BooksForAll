using System;
using Xamarin.Essentials;



namespace BooksForAll
{
    
    public class GetDeviceSize
    {

        
        

        public static bool IsLarge()
        {
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            var width = mainDisplayInfo.Width;

            var height = mainDisplayInfo.Height;

            if(width >= 1080 && height >= 1920)
            {
                Console.WriteLine("Pro");
                return true;
                
            }


            return false;
           
        }
    }
}
