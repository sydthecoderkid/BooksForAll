using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.StateSquid;
namespace BooksForAll
{
    public partial class PreferencesPage : ContentPage
    {


        public PreferencesPage()
        {
            Label header = new Label
            {
                Text = "Preferences",
                FontSize = 55,
                HorizontalOptions = LayoutOptions.Center,
               TranslationY = 100     //Higher number, lower text.
                
            };

            Label racedescription = new Label
            {
                Text = "I want to see books with ",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 250,   //Higher number, lower text
                TranslationX = -80
            };
            Label characters = new Label
            {
                Text = "characters ",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 122,   //Higher number, lower text
                TranslationX = 145.8
            };

            Label underscore = new Label
            {
                Text = "________",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 200,   //Higher number, lower text
                TranslationX = 100
            };
            this.Content = new StackLayout
            {
                Children =
                {
                    racedescription,
                    header,
                    underscore,
                    characters
                    
                }
            };

        }
    }
}
        