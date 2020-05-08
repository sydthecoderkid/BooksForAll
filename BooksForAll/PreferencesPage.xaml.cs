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
                FontSize = 45,
                HorizontalOptions = LayoutOptions.Center,
               TranslationY = 90     //Higher number, lower text.
                
            };

            Label racedescription = new Label
            {
                Text = "•I want to see books with ",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 250,   //Higher number, lower text
                TranslationX = -80
            };
            Label characters = new Label
            {
                Text = "characters ",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 122,   //Higher number, lower text
                TranslationX = 142.8
            };

            Label underscore = new Label
            {
                Text = "_________",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 150,   //Higher number, lower text
                TranslationX = 58
            };

            Label blacklabel = new Label
            {
                Text = "Black",
                FontSize = 19,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 145,   //Higher number, lower text
                TranslationX = 45
            };

            Label asianlabel = new Label
            {
                Text = "Asian",
                FontSize = 19,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 100,   //Higher number, lower text
                TranslationX = 45
            };

            Label latinolabel = new Label
            {
                Text = "Latino",
                FontSize = 19,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 55,   //Higher number, lower text
                TranslationX = 48
            };

            CheckBox blackbox = new CheckBox
            {
                
                TranslationX = 260,
                TranslationY = 105
                



            };

            CheckBox asianbox = new CheckBox
            {

                TranslationX = 260,
                TranslationY = 60




            };


            CheckBox latinobox = new CheckBox
            {

                TranslationX = 260,
                TranslationY = 16




            };


            this.Content = new StackLayout
            {
                Children =
                {
                    racedescription,
                    header,
                    underscore,
                    characters,
                    blacklabel,
                     blackbox,
                     asianlabel,
                     asianbox,
                     latinolabel,
                     latinobox

                }
            };

        }
    }
}
        