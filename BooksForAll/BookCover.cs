using System;
using System.Collections;
using Xamarin.Forms;
using System.Collections.Generic;
namespace BooksForAll
{
    public class BookCover : Image
    {

        public String filelocation;
        public int xposition;
        public Image image;

        public BookCover(String filelocation, int xvalue, int yvalue)
        {


            this.WidthRequest = 250;
            this.HeightRequest = 250;
            this.TranslateTo(xvalue, yvalue);
            this.Aspect = Aspect.AspectFit;
            this.Source = ImageSource.FromFile(filelocation);
       

        }
    }
}
