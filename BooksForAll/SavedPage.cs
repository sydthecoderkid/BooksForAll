using System;

using Xamarin.Forms;

namespace BooksForAll
{
    public class SavedPage : ContentPage
    {
        public SavedPage()
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

