using System;
using System.Collections;
using Xamarin.Forms;
using System.Collections.Generic;
namespace BooksForAll
{
    public class CurrentBook : Image
    {
        public string isbn = "9780605039070";
        public string filelocation = "BookCover.jpg";
        public int xposition;
        public string bookname;
        public UriImageSource imagesource;
        public string authorname;
        public CurrentBook()
        {
            this.WidthRequest = 500;
            this.HeightRequest = 500;
            this.TranslateTo(8, 80);
            this.Aspect = Aspect.AspectFit;


        }
    }
}