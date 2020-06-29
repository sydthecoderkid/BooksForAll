using System;
using System.Collections;
using Xamarin.Forms;
using System.Collections.Generic;


namespace BooksForAll
{

    public class BookCover : Frame
    {
        public string imagesource;
        public Book thisbook;

        public BookCover(string imagesource, Book thisbook)
        {


            this.imagesource = imagesource;
            this.thisbook = thisbook;
            BorderColor = Color.LightGray;
            CornerRadius = 3;
            HeightRequest = 65;
            WidthRequest = 0;
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            HasShadow = true;
            Image thisimage = new Image
            {
                Source = imagesource,
                Margin = -20,
                HeightRequest = 60,
                WidthRequest = 80

            };


            Content = new StackLayout
            {

                Children = {

                 thisimage,

                }
            };
        }

    }

}
