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
        public static ArrayList genders = new ArrayList();


        public string racepreference;

        public string agepreference;

        public string genderpreference;

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

           

            Picker gender = new Picker
            {
                Title = "Gender",
                TranslationY = 110,
            };

            Label generatebooks = new Label
            {
                Text = "Fill in the tags to generate books!",
                FontSize = 25,
                TextColor = Color.SlateGray,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                
            };

            age.ItemsSource = agetypes;

            race.ItemsSource = racetypes;

            gender.ItemsSource = genders;


            race.SelectedIndexChanged += (sender, args) =>
            {
                 racepreference = race.Items[race.SelectedIndex];
                checkiffilled();
            };
            age.SelectedIndexChanged += (sender, args) =>
            {
                 agepreference = age.Items[age.SelectedIndex];
                checkiffilled();
            };
           
            gender.SelectedIndexChanged += (sender, args) =>
            {
                 genderpreference = gender.Items[gender.SelectedIndex];
                checkiffilled();
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
                    generatebooks,
                    carouselView,

                    }

            };


        }

        void checkiffilled()
        {
            if (racepreference != null && agepreference != null && genderpreference != null)
            {
                Console.WriteLine("Here!");
            }
        }


    }

    
}


 

