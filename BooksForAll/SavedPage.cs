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
            BookInfo.fromrec = false;

            Label Saved = new Label
            {
                Text = "My Books",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                TextColor = Color.Blue,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 60, 0, 0)

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
                 
                Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                TextColor = Color.DarkBlue,
                Margin = new Thickness(125, 100, 0, 0),
            };

            Label author = new Label
            {
                Margin = new Thickness(125, 20, 0 ,0),
                 Text = "",
                FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
                TextColor = Color.DarkSlateBlue,
            };

           
            ImageButton backarrow = new ImageButton
            {
                
                 Source = ImageSource.FromFile("FlippedArrow.png"),
                 Scale = 0.2,
                Margin = new Thickness(-275, -105, 0, 0),

            };

            CarouselView savedbookimages = new CarouselView
            {
               Scale = 4,
                Margin = new Thickness(20, 40, 0, 0)
            };

            Button ReadMore = new Button
            {

                Margin = new Thickness(55, 0, 60, 20),
                Text = "Read More",
                Font = Font.SystemFontOfSize(NamedSize.Title),
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.LightBlue,
                TextColor = Color.Black,
                IsVisible = false,
            };

            ReadMore.Clicked += OnButtonClicked;


            savedbookimages.ItemsSource = savedBooks;



            
            backarrow.Clicked += backarrow_Clicked;

            if (!Reccomendation.prodevice)
            {
                savedbookimages.Scale = 4;
              
            }

            else if (Reccomendation.prodevice)
            {
                ReadMore.Margin = new Thickness(30, 40, 60, 20);
                savedbookimages.Margin = new Thickness(20, 90, 0, 0);
                booktitle.Margin = new Thickness(110, 100, 0, 0);
                author.Margin = new Thickness(105, 20, 0, 0);
                backarrow.Scale = .4;
                backarrow.Margin = new Thickness(-265, -95, 0, 0);
            }

            if (savedBooks.Count > 0)
            {
                NoBooks.Text = "";
                ReadMore.IsVisible = true;
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
                    ReadMore,
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

        async void OnButtonClicked(object sender, EventArgs args)

        {
            await Navigation.PushModalAsync(new BookInfo(disappearingbook));

            return;

        }
    }
}

