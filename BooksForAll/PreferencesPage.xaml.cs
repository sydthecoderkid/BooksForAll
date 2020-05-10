using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.StateSquid;
namespace BooksForAll
{
    public partial class PreferencesPage : ContentPage
    {

        private bool blackbooks, asianbooks, latinobooks, nativeamericanbooks;

        private bool childbooks, youngadultbooks, adultbooks;

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
                TranslationY = 355   //Lower number, higher text
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
                TranslationY = 30,   //Lower number, higher text
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

            Label nativeamericanlabel = new Label
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
                TranslationY = 40,   //Higher number, lower text
            };

            Label youngadults = new Label
            {
                Text = "Young Adults",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 40,
                TranslationY = 40,   //Higher number, lower text
            };

            Label adults = new Label
            {
                Text = "Adults",
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center,
                TranslationX = 40,
                TranslationY = 40,   //Higher number, lower text
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

            CheckBox nativeamericanbox = new CheckBox
            {

                TranslationX = 264,
                TranslationY = -30

        };


            CheckBox childrenbox = new CheckBox
            {

                TranslationX = 274,
                TranslationY = -51
            };

            CheckBox youngadultsbox = new CheckBox
            {

                TranslationX = 274,
                TranslationY = -75
            };



            CheckBox adultsbox = new CheckBox
            {

                TranslationX = 274,
                TranslationY = -97
            };

            Button continuebutton = new Button
            {

                ScaleX = 0.2,
                ScaleY = 0.4,
                BackgroundColor = Color.Blue,
                Text = "Continue!",
                FontSize = 60,
                BorderWidth = 3,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.LightBlue,
                TranslationX = 120,
                TranslationY = 720,
                

            };

            continuebutton.Clicked += OnButtonClicked;




            adultsbox.CheckedChanged += (sender, e) =>
            {
                if (adultsbox.IsChecked)
                {
                    adultbooks = true;
                }
                else
                {
                    adultbooks = false;
                }
            };

            youngadultsbox.CheckedChanged += (sender, e) =>
            {
                if (youngadultsbox.IsChecked)
                {
                    youngadultbooks = true;
                }
                else
                {
                    youngadultbooks = false;
                }
            };


            childrenbox.CheckedChanged += (sender, e) =>
            {
                if (childrenbox.IsChecked)
                {
                    childbooks = true;
                }
                else
                {
                    childbooks = false;
                }
            };

            blackbox.CheckedChanged += (sender, e) =>
            {
                if (blackbox.IsChecked)
                {
                    blackbooks = true;
                }
                else
                {
                    blackbooks = false;
                }
            };

            asianbox.CheckedChanged += (sender, e) =>
            {
                if (asianbox.IsChecked)
                {
                    asianbooks = true;
                }
                else
                {
                    asianbooks = false;
                }
            };

            latinobox.CheckedChanged += (sender, e) =>
            {
                if (latinobox.IsChecked)
                {
                    latinobooks = true;
                }
                else
                {
                    latinobooks = false;
                }
            };


            nativeamericanbox.CheckedChanged += (sender, e) =>
            {
                if (nativeamericanbox.IsChecked)
                {
                    nativeamericanbooks = true;
                }
                else
                {
                    nativeamericanbooks = false;
                }
            };




            this.Content = new StackLayout
            {
                Children =
                {
                    continuebutton,
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
                     nativeamericanlabel,
                     nativeamericanbox,
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

        async void OnButtonClicked(object sender, EventArgs args)

        {

            await Navigation.PushModalAsync(new MyTabbedPage());
        }

    }
    
}
        