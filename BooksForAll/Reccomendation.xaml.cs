using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using PanCardView;
using CarouselView = PanCardView.CarouselView;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace BooksForAll
{


    public partial class Reccomendation : ContentPage
    {
        public static CarouselView carouselView = new CarouselView();
        public static ObservableCollection<BookCover> bookcovers = new ObservableCollection<BookCover>();
        public static ArrayList racetypes = new ArrayList();
        public static ArrayList agetypes = new ArrayList();
        public static ArrayList genders = new ArrayList();
        private int bookswiped = 0;
        private int maxbooks = 2;

        private int timescalled = 0;

        public static bool canclick = true;


        public static BookCover disappearingbook;


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
            TranslationY = -65,
            HorizontalOptions = LayoutOptions.CenterAndExpand,

        };


        public static Label BookTitle = new Label()
        {
            Text = "Book title",
            FontSize = 25,
            TextColor = textcolor,
            TranslationY = 5, //Go closer to negative one hundred to lower text
            HorizontalOptions = LayoutOptions.CenterAndExpand,
        };


        public static Label AuthorName = new Label()
        {
            Text = "Author Name",
            FontSize = 25,
            TextColor = textcolor,
            TranslationY = 5,
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
            HorizontalOptions = LayoutOptions.Center,
            TranslationY = -30,
            BackgroundColor = Color.LightBlue,
            TextColor = Color.Black,
            IsVisible = false,

        };

        public static Image arrowimage = new Image
        {
            Source = ImageSource.FromFile("Arrow.png"),
            Scale = 0.3,
            TranslationY = 58,
            TranslationX = 160,

        };

        public static ImageButton homeicon = new ImageButton
        {
            Source = ImageSource.FromFile("FlippedArrow.png"),
            Scale = 0.2,
            TranslationY = -310, //Further negative is a higher image
            TranslationX = -170,

        };











        public Reccomendation()
        {
            arrowimage.Opacity = 0;

            carouselView.ItemsSource = bookcovers;
            ReadMore.Clicked += OnButtonClicked;
            homeicon.Clicked += BacktoHome;

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



            carouselView.TranslationY = -100; //Larger the number, lower the image
            carouselView.Scale = 3;

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


                if (bookswiped % maxbooks == 0)
                {
                    QueryDatabase.calldatabase();
                }

                bookswiped++;
            };

            carouselView.ItemDisappearing += (sender, args) =>
            {

                disappearingbook = (BookCover)carouselView.SelectedItem;
                BookTitle.Text = disappearingbook.thisbook.booktitle;
                AuthorName.Text = disappearingbook.thisbook.authorname;


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
                    arrowimage,
                    homeicon,
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
                generatebooks.Text = "";
                swipedindex = 1;
                firstbook = false;
                arrowimage.IsEnabled = true;
                FadeOutArrow();
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
                QueryDatabase.calldatabase();




                ReadMore.IsVisible = true;


            }
        }
        public static async void FadeOutArrow()
        {

            arrowimage.Opacity = 1;
            await arrowimage.TranslateTo(-100, 58, 1500);
            await arrowimage.FadeTo(0, 1000);


        }

        async void OnButtonClicked(object sender, EventArgs args)

        {
            if (canclick)
            {
                await Navigation.PushModalAsync(new BookInfo(disappearingbook));
                canclick = false;
                ReadMore.Clicked -= OnButtonClicked;
            }
        }

        async void BacktoHome(object sender, EventArgs args)

        {
            if (timescalled == 0)
            {
                await Navigation.PushModalAsync(new MainPage());
                timescalled += 1;

            }


        }


    }

}




