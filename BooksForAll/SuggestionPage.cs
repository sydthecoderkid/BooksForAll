using System;

using Xamarin.Forms;

namespace BooksForAll
{
    public class SuggestionPage : ContentPage
    {
        public SuggestionPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

