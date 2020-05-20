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
            for(int i = 0; i < MainPage.books.Count; i++){
                Console.WriteLine("Heyo");
                Book book = (Book) MainPage.books[i];
                bookcovers.Add(book.bookCover);
            }
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
    

