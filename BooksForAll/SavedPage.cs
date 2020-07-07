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
                Margin = new Thickness(0, 45, 0, 0)

            };

            Label NoBooks = new Label
            {
                Text = "No books saved!",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                TextColor = Color.Blue,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 60, 0, 0)

            };
            Label booktitle = new Label
            {
                 
                Text = "Book Title",
                FontSize = 20,
                TextColor = Color.DarkBlue,
            };

            Label author = new Label
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Text = "Author",
                FontSize = 20,
                TextColor = Color.DarkBlue,
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
               Scale = 3,
                Margin = new Thickness(80, 40, 0, 0)
            };

            

            savedbookimages.ItemsSource = savedBooks;



            
            backarrow.Clicked += backarrow_Clicked;

            if (!Reccomendation.prodevice)
            {
                savedbookimages.Scale = 0.8;
            }

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

