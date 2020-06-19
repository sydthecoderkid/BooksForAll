using System;
using System.Collections;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using PanCardView;
using CarouselView = PanCardView.CarouselView;

namespace BooksForAll
{
    public class SavedPage : ContentPage
    {
        public static ObservableCollection<BookCover> savedBooks = new ObservableCollection<BookCover>();

        public SavedPage()
        {
            Label Saved = new Label
            {
                Text = "My Books",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                TextColor = Color.Blue,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
               TranslationY = 45, 
                
            };

              ImageButton backarrow = new ImageButton
            {
                TranslationX = -85,
                TranslationY = -25,
                 Source = ImageSource.FromFile("FlippedArrow.png"),
                 Scale = 0.3,

            };

            CarouselView savedbooks = new CarouselView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            savedbooks.ItemsSource = savedBooks;




            backarrow.Clicked += backarrow_Clicked;
            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand, 
                 
                Children = {
                   Saved,
                    backarrow,
                    savedbooks,
                }
            };


            async void backarrow_Clicked(object sender, EventArgs args)

            {
                await Navigation.PushModalAsync(new MainPage());

            }
        }
    }
}

