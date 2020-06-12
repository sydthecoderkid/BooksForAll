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
            Image thisimage = new Image
            {
                Source = imagesource,
                Aspect = Aspect.AspectFill,
                Margin = -20,
                HeightRequest = 93,
                WidthRequest = 93
            };

            Label booktitle = new Label
            {
                FontSize = 6,
                VerticalOptions = LAYOUT
                Text = thisbook.booktitle
            };
            Content = new StackLayout
            {
                Children = {
                 
                 thisimage,
                  booktitle,

                }
            };
        }

    }

}

     

    

