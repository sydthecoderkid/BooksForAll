using System;
using Xamarin.Essentials;
namespace BooksForAll
{
    public class UserPreferences
    {

        public static bool blackpreference;

        public static bool asianpreference;

        public static bool nativeamericanpreference;

        public static bool latinopreference;


        public static void setPreferences(bool blackpreference, bool asianpreference, bool nativeamericanpreference, bool latinoprefernece)
        {
            if (blackpreference)
            {
                Preferences.Set("Blackpreference", blackpreference);
            }
            if (asianpreference)
            {
                Preferences.Set("Asianpreference", asianpreference);
            }
            if (nativeamericanpreference)
            {
                Preferences.Set("NativeAmericanpreference", nativeamericanpreference);
            }
            if (latinoprefernece)
            {
                Preferences.Set("Latinopreference", latinoprefernece);
            }
        }

        public static void getPreferences()
        {
            if (Preferences.ContainsKey("Blackpreference"))
            {
                blackpreference = true;
            }

            if (Preferences.ContainsKey("Asianpreference"))
            {
                asianpreference = true;
            }

            if (Preferences.ContainsKey("NativeAmericanpreference"))
            {
                nativeamericanpreference = true;
            }
            if (Preferences.ContainsKey("Latinopreference"))
            {
                latinopreference = true;
            }
        }
    }
}
