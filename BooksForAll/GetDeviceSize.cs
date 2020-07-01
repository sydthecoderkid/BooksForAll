using System;
using Xamarin.Essentials;

namespace BooksForAll
{
    public class GetDeviceSize
    {

        
        

        public static bool IsLarge()
        {
            string device = DeviceInfo.Name;

            
            return device.Contains("Pro") || device.Contains("Plus");
           
        }
    }
}
