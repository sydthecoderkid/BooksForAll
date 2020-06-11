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

            
            Margin = 10;
            BorderColor = Color.LightGray;
            CornerRadius = 3;
            HeightRequest = 53;
            WidthRequest = 25;

            
            HasShadow = true;
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            this.Content = new Image
            {
               
                Source = imagesource,
                Aspect = Aspect.AspectFill,
                Margin = -20,
                HeightRequest = 15,
                WidthRequest = 15
            };
        }

    }

}

     

    

