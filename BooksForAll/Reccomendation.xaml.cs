﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using PanCardView;
using CarouselView = PanCardView.CarouselView;
using System.Collections.Specialized;

namespace BooksForAll
{


    public partial class Reccomendation : ContentPage
    {
        public static CarouselView carouselView = new CarouselView();
        public static ObservableCollection<BookCover> bookcovers = new ObservableCollection<BookCover>();
        public static ArrayList racetypes = new ArrayList();
        public static ArrayList agetypes = new ArrayList();
        public static ArrayList genders = new ArrayList();
        private int bookspulled = 0;
        private int bookswiped = 0;
        private int maxbooks = 2;
        private static int temp;

        private static bool firstbook = true;
        public static string racepreference;

        public static string agepreference;

        public static string genderpreference;

        public static Color textcolor = Color.DarkBlue;

        public static int swipedindex = 0;

        public static Label generatebooks = new Label()
        {
            Text = "Fill in the tags to generate books!",
            FontSize = 25,
            TextColor = textcolor,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.CenterAndExpand,

        };


        public static Label BookTitle = new Label()
        {
            Text = "Book title",
            FontSize = 25,
            TextColor = textcolor,
            TranslationY = -50, //Go closer to one hundred to lower text
            HorizontalOptions = LayoutOptions.CenterAndExpand,
        };


        public static Label AuthorName = new Label()
        {
            Text = "Author Name",
            FontSize = 25,
            TextColor = textcolor,
            TranslationY = -50,
            HorizontalOptions = LayoutOptions.CenterAndExpand,
        };


        public Picker race = new Picker
        {
            Title = "Race",
            TitleColor = textcolor,
            TextColor = textcolor,
            TranslationY = 110,
            WidthRequest = 30,
        };

        private Picker age = new Picker
        {
            Title = "Age",
            TitleColor = textcolor,
            TextColor = textcolor,
            TranslationY = 110,

        };




        private Picker gender = new Picker
        {
            Title = "Gender",
            TitleColor = textcolor,
            TextColor = textcolor,
            TranslationY = 110,
        };


        public static Button ReadMore = new Button
        {
            FontFamily = "Montserrat-Light",
            Margin = new Thickness(60, 35, 60, 20),
            Text = "Read More",
            Font = Font.SystemFontOfSize(NamedSize.Title),
            FontSize = 20,
            //ScaleX = 1.2,
            HorizontalOptions = LayoutOptions.Center,
            TranslationY = -40,
            BackgroundColor = Color.LightBlue,
            TextColor = Color.Black,
            IsVisible = false,

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



            carouselView.TranslationY = 235;
            carouselView.Scale = 3.6;

            bookcovers.CollectionChanged += booksretrieved;


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

                Console.WriteLine(temp);
                Console.WriteLine(carouselView.SelectedIndex);

                if (swipedindex == bookcovers.Count)
                {
                    swipedindex = 0;
                }

                if(temp < carouselView.SelectedIndex )
                {
                    swipedindex -= 1;
                }
                BookCover thisbookcover = bookcovers[swipedindex];
                Book thisbook = new Book();
                thisbook = bookcovers[swipedindex].thisbook;
                BookTitle.Text = thisbook.booktitle;
                AuthorName.Text = thisbook.authorname;

                    swipedindex += 1; //It adds a one to the swipe index in anticipation of a swipe.
                
                



               



                if (bookspulled % maxbooks == 0)
                {
                    QueryDatabase.calldatabase();
                }

                bookspulled++;

                 temp = carouselView.SelectedIndex;


            };





            // Accomodate iPhone status bar.
            // this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            this.Content = new StackLayout
            {
                BackgroundColor = Color.AliceBlue, //Default is Alice Blue

                Children = {

                    race,
                    age,
                    gender,
                    carouselView,
                    generatebooks,
                    BookTitle,
                    AuthorName,
                    ReadMore,
                    }

            };


        }

        public static void booksretrieved(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (firstbook)
            {
                BookTitle.Text = bookcovers[0].thisbook.booktitle;
                AuthorName.Text = bookcovers[0].thisbook.authorname;
                carouselView.SelectedItem = bookcovers[0];
                swipedindex = 1;
                firstbook = false;
            }
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




                ReadMore.IsVisible = true;


            }
        }


    }


}




