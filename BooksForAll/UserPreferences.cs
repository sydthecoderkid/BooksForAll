using System;
using Xamarin.Essentials;
namespace BooksForAll
{
    public class UserPreferences
    {

        public static void setPreferences(bool blackpreference, bool asianpreference, bool nativeamericanpreference, bool latinoprefernece)
        {
            Preferences.Set("Blackpreference", blackpreference);
            Preferences.Set("Asianpreference", asianpreference);
            Preferences.Set("NativeAmericanpreference", nativeamericanpreference);
            Preferences.Set("Latinopreference", latinoprefernece);
        }
    }
}
