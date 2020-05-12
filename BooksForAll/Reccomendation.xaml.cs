using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BooksForAll
{
    public partial class Reccomendation : ContentPage
    {
        public Reccomendation()
        {
            CarouselView carouselView = new CarouselView()
            {
                TranslationX = 200,
             
                ItemsSource = new FileImageSource[]{
                   "BookCover.jpg"
                }
                

            };

          

            Content = new StackLayout()
            {
                Children = {
                carouselView,
                }
            };
            InitializeComponent();
        }

      
        

    }
}
