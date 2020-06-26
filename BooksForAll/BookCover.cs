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
            Margin = 6;
            BorderColor = Color.LightGray;
            CornerRadius = 3;
            HeightRequest = 80;
            WidthRequest = 80;
            IsClippedToBounds = true;
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            Image thisimage = new Image
            {
                Source = imagesource,
                Margin = -20,
                HeightRequest = 70,
                WidthRequest = 70

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





