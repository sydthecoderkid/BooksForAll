using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using PanCardView;
using CarouselView = PanCardView.CarouselView;

namespace BooksForAll
{

  
    public partial class Reccomendation : ContentPage
    {
       CarouselView carouselView = new CarouselView();
       public static ObservableCollection<BookCover> bookcovers = new ObservableCollection<BookCover>();
        public static ArrayList booktypes = new ArrayList();
        public Reccomendation()
        {
            booktypes.Add("Black");
            booktypes.Add("LGBTQ");
            QueryDatabase.calldatabase();
            carouselView.ItemsSource = bookcovers;



            carouselView.TranslationY = 400;
            carouselView.Scale = 3;
            Picker picker = new Picker
            {
                Title = "Book Type",
                TranslationY = 100,
                };

                foreach (string types in booktypes)
                {
                    picker.Items.Add(types);
                }



            
                picker.SelectedIndexChanged += (sender, args) =>
                {
                   
                        string preference1 = picker.Items[picker.SelectedIndex];
                       
                    
                };

                // Accomodate iPhone status bar.
                this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

                // Build the page.
                this.Content = new StackLayout
                {
                    Children = {

                    picker,
                    carouselView,

                    }
                 
                };

            }
        
    }
}


 

