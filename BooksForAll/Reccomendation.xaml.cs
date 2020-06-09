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
        public static ObservableCollection<string> bookauthors = new ObservableCollection<string>();
        public static ObservableCollection<string> booktitles = new ObservableCollection<string>();
        public static ArrayList racetypes = new ArrayList();
        public static ArrayList agetypes = new ArrayList();
        public static ArrayList genders = new ArrayList();
        private int bookspulled = 0;
        private int bookswiped = 2;

        public static string racepreference;

        public static string agepreference;

        public static string genderpreference;



        public static Label generatebooks = new Label()
        {
            Text = "Fill in the tags to generate books!",
            FontSize = 25,
            TextColor = Color.SlateGray,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.CenterAndExpand,

        };


        public static Label BookTitle = new Label()
        {
            Text = "Book title",
            FontSize = 25,
            TextColor = Color.SlateGray,
            TranslationY = -120,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
        };


        public static Label AuthorName = new Label()
        {
            Text = "Author Name",
            FontSize = 25,
            TextColor = Color.SlateGray,
            TranslationY = -120,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
        };


        public Picker race = new Picker
        {
            Title = "Race",

            TranslationY = 110,

        };

        private Picker age = new Picker
        {
            Title = "Age",

            TranslationY = 110,
        };




        private Picker gender = new Picker
        {
            Title = "Gender",
            TranslationY = 110,
        };




        public Reccomendation()
        {

            racetypes.Add("Any race");
            racetypes.Add("Black characters");
            racetypes.Add("Asian characters");
            racetypes.Add("Latino characters");
            racetypes.Add("Native American characters");

            agetypes.Add("Any age");
            agetypes.Add("Children's books");
            agetypes.Add("Young Adult books");
            agetypes.Add("Adult books");


            genders.Add("Any gender");
            genders.Add("Male Leads");
            genders.Add("Female Leads");



            carouselView.TranslationY = 350;
            carouselView.Scale = 3;




            age.ItemsSource = agetypes;

            race.ItemsSource = racetypes;

            gender.ItemsSource = genders;


            race.SelectedIndexChanged += (sender, args) =>
            {
                QueryDatabase.anyrace = false;

                racepreference = race.Items[race.SelectedIndex];
                racepreference = parsepreference(racepreference);
                if (racepreference.Equals("Any"))
                {
                    QueryDatabase.anyrace = true;

                }
                checkiffilled();
            };
            age.SelectedIndexChanged += (sender, args) =>
            {
                QueryDatabase.anyage = false;
                agepreference = age.Items[age.SelectedIndex];
                agepreference = parsepreference(agepreference);
                if (agepreference.Equals("Any"))
                {
                    QueryDatabase.anyage = true;
                }
                checkiffilled();
            };

            gender.SelectedIndexChanged += (sender, args) =>
            {
                QueryDatabase.anygender = false;
                genderpreference = gender.Items[gender.SelectedIndex];
                genderpreference = parsepreference(genderpreference);
                if (genderpreference.Equals("Any"))
                {
                    QueryDatabase.anygender = true;
                }
                checkiffilled();
            };

            carouselView.ItemSwiped += (sender, args) =>
            {
                if (bookspulled % bookswiped == 0)
                {
                    QueryDatabase.calldatabase();
                }

                bookspulled++;
            };


            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            this.Content = new StackLayout
            {
                Children = {
                    race,
                    age,
                    gender,
                    carouselView,
                    generatebooks,
                    BookTitle,
                    AuthorName
                    }

            };


        }

        private string parsepreference(string preference)
        {

            string holder = "";
            if (preference.Equals("Children's books"))
            {
                holder = "Children";
                return holder;
            }

            for (int i = 0; i < preference.Length; i++)
            {
                char held = preference[i];
                if (!char.IsWhiteSpace(held))
                {
                    holder += preference[i];
                }

                else if (char.IsWhiteSpace(held))
                {
                    preference = holder;
                    return preference;

                }




            }
            return preference;
        }

        void checkiffilled()
        {
            if (racepreference != null && agepreference != null && genderpreference != null)
            {
                if (bookcovers.Count == 0)
                {
                    generatebooks.Text = "Grabbing books...";
                }
                else
                {
                    generatebooks.Text = "";
                }

                if (bookcovers.Count > 0)
                {
                    bookcovers.Clear();
                    QueryDatabase.booksindexed = 0;
                }
                carouselView.ItemsSource = bookcovers;
                QueryDatabase.calldatabase();



            }
        }


    }


}




