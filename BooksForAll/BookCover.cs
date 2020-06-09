using System;
using System.Collections;
using Xamarin.Forms;
using System.Collections.Generic;


namespace BooksForAll
{

    public class BookCover : ImageButton
    {
        public string imagesource;
        public Book thisbook;
        public BookCover(string imagesource, Book thisbook)
        {

            this.Source = imagesource;
            this.imagesource = imagesource;
            this.thisbook = thisbook;
            this.Clicked += (object o, EventArgs e) => {
                OnImageButtonClicked();
            };

        }



     
       async void OnImageButtonClicked()
        {
             await Navigation.PushModalAsync(new BookInfo(this));
        }



    }
}
