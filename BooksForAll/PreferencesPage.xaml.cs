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
                TranslationX = -80,
                TranslationY = 270   //Higher number, lower text
            };

            Label agedescription = new Label
            {
                Text = "•I want my books to be for ",
                FontAttributes = FontAttributes.Bold,
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = -80,
                TranslationY = 380   //Higher number, lower text
            };
            Label characters = new Label
            {
                Text = "characters ",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 142.8,
                TranslationY = 157,   //Higher number, lower text
            };

            Label ageunderscore = new Label
            {
                Text = "_________",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 58,
                TranslationY = 55,   //Higher number, lower text
            };

            Label underscore = new Label
            {
                Text = "__________",
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 58,
                TranslationY = 182,   //Higher number, lower text
            };


            Label blacklabel = new Label
            {
                Text = "Black",
                FontSize = 16,
                
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 45,
                TranslationY = 145,   //Higher number, lower text
            };

            Label asianlabel = new Label
            {
                Text = "Asian",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 45,
                TranslationY = 100,   //Higher number, lower text
            };

            Label latinolabel = new Label
            {
                Text = "Latino",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 48,
                TranslationY = 55,   //Higher number, lower text
            };

            Label pacificislanderlabel = new Label
            {
                Text = "Native American",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 18,
                TranslationY = 9,   //Higher number, lower text
            };

            Label children = new Label
            {
                Text = "Children",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 40,
                TranslationY = 60,   //Higher number, lower text
            };

            Label youngadults = new Label
            {
                Text = "Young Adults",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 40,
                TranslationY = 60,   //Higher number, lower text
            };

            Label adults = new Label
            {
                Text = "Adults",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 40,
                TranslationY = 60,   //Higher number, lower text
            };


            CheckBox blackbox = new CheckBox
            {
                
                TranslationX = 264,
                TranslationY = 105,
                
                
            };

            CheckBox asianbox = new CheckBox
            {

                TranslationX = 264,
                TranslationY = 60




            };


            CheckBox latinobox = new CheckBox
            {

                TranslationX = 264,
                TranslationY = 16




            };

            CheckBox pacificislanderbox = new CheckBox
            {

                TranslationX = 264,
                TranslationY = -30

        };


            CheckBox childrenbox = new CheckBox
            {

                TranslationX = 274,
                TranslationY = -27
            };

            CheckBox youngadultsbox = new CheckBox
            {

                TranslationX = 274,
                TranslationY = -51
            };

            CheckBox adultsbox = new CheckBox
            {

                TranslationX = 274,
                TranslationY = -78
            };
            this.Content = new StackLayout
            {
                Children =
                {
                    racedescription,
                   
                    header,
                    underscore,
                    characters,
                    agedescription,
                    blacklabel,
                     blackbox,
                     
                     asianlabel,
                     asianbox,
                     latinolabel,
                     latinobox,
                     pacificislanderlabel,
                     pacificislanderbox,
                    ageunderscore,
                     children,
                     youngadults,
                     adults,
                     childrenbox,
                     youngadultsbox,
                     adultsbox,

           


                }

    };

        }

       void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
       {
       
            Console.WriteLine("Clicked a box");
       }

        
    }
    
}
        