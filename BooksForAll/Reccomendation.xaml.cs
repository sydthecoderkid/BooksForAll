using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace BooksForAll
{
    public partial class Reccomendation : ContentPage
    {
        public Reccomendation()
        {

            CarouselView carouselView = new CarouselView();
            carouselView.SetBinding(ItemsView.ItemsSourceProperty, "TestCovers");

            carouselView.ItemTemplate = new DataTemplate(() =>
            {

                Image image = new Image {};
                image.SetBinding(Image.SourceProperty, MainPage.thisbook.imagesource);



                StackLayout stackLayout = new StackLayout
                {
                    Children = {  image, }
                };

                Frame frame = new Frame { };
                StackLayout rootStackLayout = new StackLayout
                {
                    Children = { frame }
                };

                return rootStackLayout;
            });



            Content = new StackLayout()
            {

                
                Children =
                {
                    carouselView,
                }
            };
        }

      
        

    }
}
