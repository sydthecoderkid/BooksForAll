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
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    
                }
            };

        }
    }
}
        