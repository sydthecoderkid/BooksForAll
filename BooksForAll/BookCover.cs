using System;
using System.Collections;
using Xamarin.Forms;
using System.Collections.Generic;
namespace BooksForAll
{
    public class BookCover : Image
    {

        public String filelocation = "BookCover.jpg";
        public int xposition;
        public Image image;
        public string bookname;
        public string authorname;
        public BookCover()
        {


            this.WidthRequest = 250;
            this.HeightRequest = 250;
            this.TranslateTo(-100, 80);
            this.Aspect = Aspect.AspectFit;
            this.Source = ImageSource.FromFile(filelocation);

        }
    }
}