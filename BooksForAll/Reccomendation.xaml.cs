using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using PanCardView;

namespace BooksForAll
{

  
    public partial class Reccomendation : ContentPage
    {
        PanCardView.CarouselView carouselView = new PanCardView.CarouselView();
        ObservableCollection<BookCover> bookcovers = new ObservableCollection<BookCover>();

        public Reccomendation()
        {
            bookcovers.Add(new BookCover(MainPage.thisbook.imagesource));
            bookcovers.Add(new BookCover("https://homepages.cae.wisc.edu/~ece533/images/airplane.png"));
            carouselView.ItemsSource = bookcovers;
            TranslationY = 550;
            Scale = 1.8;
            Content = new StackLayout
            {
                Children =
                {
                    carouselView,
                }
            };
        }


    }
}
    

