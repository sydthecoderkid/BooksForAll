using System;
using Xamarin.Essentials;
namespace BooksForAll
{
    public class UserPreferences
    {

        public UserPreferences()
        {

        }

        public static void setPreferences()
        {
            Preferences.Set("Race", "Black");
        }
    }
}
