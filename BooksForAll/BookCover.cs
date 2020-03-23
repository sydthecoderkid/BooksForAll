using System;
using System.Collections;
using Xamarin.Forms;
using System.Collections.Generic;
namespace BooksForAll
{
    public class BookCover : ContentPage
    {

        public String filelocation;
        public int xposition;
        public Image image;

        public BookCover(String filelocation)
        {
             image = new Image
            {
                Source = new UriImageSource
                {
                    Uri = new Uri(filelocation)
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            // Build the page.
          

        }
    }
}
