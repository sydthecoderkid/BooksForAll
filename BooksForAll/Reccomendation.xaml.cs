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
        public static ArrayList racetypes = new ArrayList();
        public static ArrayList agetypes = new ArrayList();
        public static ArrayList genres = new ArrayList();
        public static ArrayList genders = new ArrayList();

        public Reccomendation()
        {
            racetypes.Add("Any race");
            racetypes.Add("African American characters");
            racetypes.Add("Asian characters");
            racetypes.Add("Latino characters");
            racetypes.Add("Native American characters");

            agetypes.Add("Any age");
            agetypes.Add("Children's books");
            agetypes.Add("Young Adult books");
            agetypes.Add("Adult books");

            genres.Add("Any genre");
            genres.Add("Ficton");
            genres.Add("Non fiction");
            genres.Add("Fantasy");
            genres.Add("Autobiography");

            genders.Add("Any gender");
            genders.Add("Male");
            genders.Add("Female");
            genders.Add("Non-Binary");



            carouselView.ItemsSource = bookcovers;



            carouselView.TranslationY = 400;
            carouselView.Scale = 3;


            Picker race = new Picker
            {
                Title = "Race",

                TranslationY = 110,
              
            };

            Picker age = new Picker
            {
                Title = "Age",
                TranslationY = 110,
            };

            Picker genre = new Picker
            {
                Title = "Genre",
                TranslationY = 110,
            };

            Picker gender = new Picker
            {
                Title = "Gender",
                TranslationY = 110,
            };

            Label generatebooks = new Label
            {
                Text = "oh!",
                TextColor = Color.SlateGray,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                
            };

            age.ItemsSource = agetypes;

            race.ItemsSource = racetypes;

            genre.ItemsSource = genres;

            gender.ItemsSource = genders;

           

            race.SelectedIndexChanged += (sender, args) =>
            {
                string preference1 = race.Items[race.SelectedIndex];
            };
            age.SelectedIndexChanged += (sender, args) =>
            {
                string preference2 = age.Items[age.SelectedIndex];
            };
            genre.SelectedIndexChanged += (sender, args) =>
            {
                string preference3 = genre.Items[genre.SelectedIndex];
            };
            gender.SelectedIndexChanged += (sender, args) =>
            {
                string preference4 = gender.Items[gender.SelectedIndex];
            };

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children = {
                    race,
                    age,
                    gender,
                    genre,
                    generatebooks,
                    carouselView,

                    }

            };


        }
    }
}


 

