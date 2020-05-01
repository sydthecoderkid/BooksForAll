using System;
using System.Collections;
using Xamarin.Forms;
using System.Collections.Generic;

using UIKit;

namespace BooksForAll
{
    public class BookCover : Image 
    {

        public int xposition;
        public Image image;
        public BookCover()
        {


            this.WidthRequest = 500;
            this.HeightRequest = 500;
            this.TranslateTo(8, 80);
            this.Aspect = Aspect.AspectFit;
             

        }

    


    }

   
}
