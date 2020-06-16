using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Collections;

namespace BooksForAll
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private static bool buttonactive = false;

 

        public MainPage()
        {
           
            Button Explore = new Button
            {

                Margin = new Thickness(70, 35, 70, 20),
                Text = "Explore Books",
                Font = Font.SystemFontOfSize(NamedSize.Caption),
                FontSize = 35,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 190, //The closer to zero the lower the number
                BackgroundColor = Color.LightBlue,
                
                TextColor = Color.DarkBlue,

            };
            Explore.Clicked += OnExploreClicked;

            Button Saved = new Button
            {

                Margin = new Thickness(70, 35, 70, 20),
                Text = "My Books",
                Font = Font.SystemFontOfSize(NamedSize.Caption),
                FontSize = 35,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 190, //The closer to zero the lower the number
                BackgroundColor = Color.LightBlue,
                TextColor = Color.DarkBlue,

            };

            Saved.Clicked += OnSavedClicked;

            Button Suggest = new Button
            {

                Margin = new Thickness(70, 35, 70, 20),
                Text = "Suggest Books",
                Font = Font.SystemFontOfSize(NamedSize.Caption),
                FontSize = 35,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 190, //The closer to zero the lower the number
                BackgroundColor = Color.LightBlue,
                TextColor = Color.DarkBlue,

            };

            Suggest.Clicked += OnSuggestClicked;

            Label Welcome = new Label
            {

                Margin = new Thickness(60, 35, 60, 20),
                Text = "Welcome!",
                Font = Font.SystemFontOfSize(NamedSize.Title),
                FontSize = 45,
                HorizontalOptions = LayoutOptions.Center,
                TranslationY = 130, //The closer to zero the lower the number
                TextColor = Color.DarkBlue,

            };

            

            Content = new StackLayout
            {
                BackgroundColor = Color.AliceBlue, //Default is Alice Blue

                Children = {
                    Welcome,
                    Explore,
                    Saved,
                    Suggest,
                    }

            };

           
           


        }

        async void OnExploreClicked(object sender, EventArgs args)

        {
              await Navigation.PushModalAsync(new Reccomendation());

            
        }

        async void OnSuggestClicked(object sender, EventArgs args)

        { 
                await Navigation.PushModalAsync(new SuggestionPage());
           
            
        }

        async void OnSavedClicked(object sender, EventArgs args)

        {
             
                await Navigation.PushModalAsync(new SavedPage());
                
            }

        }

       
    }
