using System;
using Xamarin.Essentials;

namespace BooksForAll
{
    public class GetDeviceSize
    {

         static int smallWightResolution = 768;
         static int smallHeightResolution = 1280;
        public GetDeviceSize()
        {
        }


        public static bool IsASmallDevice()
        {
            // Get Metrics
            var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= smallWightResolution && height <= smallHeightResolution);
        }
    }
}
