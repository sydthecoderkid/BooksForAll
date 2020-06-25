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

        public BookCover disappearingbook;
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

            Label NoBooks = new Label
            {
                Text = "No books saved!",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                TextColor = Color.Blue,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };
            Label booktitle = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Text = "Book Title",

            };

            Label author = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Text = "Author",

            };

            if (savedBooks.Count > 0)
            {
                NoBooks.Text = "";
                
            }
            ImageButton backarrow = new ImageButton
            {
                TranslationX = -85,
                TranslationY = -25,
                 Source = ImageSource.FromFile("FlippedArrow.png"),
                 Scale = 0.3,

            };

            CarouselView savedbookimages = new CarouselView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            

            savedbookimages.ItemsSource = savedBooks;



            
            backarrow.Clicked += backarrow_Clicked;

            savedbookimages.Scale = 3;
            savedbookimages.TranslationX = 100;

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand, 
                 
                Children = {
                   Saved,
                    backarrow,
                    savedbookimages,
                    NoBooks,
                    booktitle,
                    author,
                }
            };

            savedbookimages.ItemDisappearing += (sender, args) =>
            {
                if (savedBooks.Count > 0)
                {
                    disappearingbook = (BookCover)savedbookimages.SelectedItem;
                    booktitle.Text = disappearingbook.thisbook.booktitle;
                    author.Text = disappearingbook.thisbook.authorname;
                }


            };

        }

        async void backarrow_Clicked(object sender, EventArgs args)

        {
            await Navigation.PushModalAsync(new MainPage());

        }
    }
}

