﻿using System;
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
       
        public static ObservableCollection<BookCover> bookcovers = new ObservableCollection<BookCover>();
        public static ArrayList racetypes = new ArrayList();
        public static ArrayList agetypes = new ArrayList();
        public static ArrayList genders = new ArrayList();
        private int bookswiped = 0;
        private int maxbooks = 2;

        public static bool prodevice = false;
        public static bool moreinfo = true;

        public static bool clickhome = true;


        public static BookCover disappearingbook;


        private static bool  firstbook = true;
        public static string racepreference = null;

        public static string agepreference = null;

        public static string genderpreference = null;

        public static string racepreferenceUP = "Race";

        public static string agepreferenceUP = "Age";

        public static string genderpreferenceUP = "Gender";


        public static Color textcolor = Color.DarkBlue;

        public static int swipedindex = 0;

        public static bool assignedlists = false;

        public static string booktitle;

        public static string authorname;

        public static int titlelength;

        public static int authorlength;



        private Picker age = new Picker
        {
            Title = agepreferenceUP,
            TitleColor = textcolor,
            TextColor = textcolor,
            VerticalOptions = LayoutOptions.Start,
            WidthRequest = -5,
            Margin = 90,

        };



        public Picker race = new Picker
        {
            Title = racepreferenceUP,
            TitleColor = textcolor,
            TextColor = textcolor,
             VerticalOptions = LayoutOptions.Start,
            WidthRequest = -5,
            Margin = 90,
             

        };



        private Picker gender = new Picker
        {
            Title = genderpreferenceUP,
            TitleColor = textcolor,
            TextColor = textcolor,
            VerticalOptions = LayoutOptions.Start,
            WidthRequest = -50,
            Margin = 90,
        };

        public static ImageButton homeicon = new ImageButton
        {
            Source = ImageSource.FromFile("House"),
            Scale = 0.15,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Aspect = Aspect.AspectFit,
            
             Margin = new Thickness(-110, -245, 0, 0), //Further negative in y to raise up image || Further positive in x to move image lect
        };



        public static CarouselView carouselView = new CarouselView
        {
           Margin = new Thickness(-20, -140, 0, 0),
            VerticalOptions = LayoutOptions.Center,
            Scale = 3.5,
        };


        public static Label generatebooks = new Label
        {
            Text = "Fill in the tags to generate books!",
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
            Margin = new Thickness(100, 160, 0, 0),
            TextColor = Color.DarkBlue,
        };

        public static Label BookTitle = new Label
        {
            Text = "Book Title",
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
            Margin = new Thickness(115, 525, 0, 0), //Go further negative for Y increase
            TextColor = Color.DarkBlue,
        };

        public static Label AuthorName = new Label
        {
            Text = "Author Name",
            VerticalOptions = LayoutOptions.End,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            FontSize = Device.GetNamedSize(NamedSize.Title, typeof(Label)),
            Margin = new Thickness(115, 200, 0, 0), //Go further negative for Y increase
            TextColor = Color.DarkSlateBlue,
        };


        public static Button ReadMore = new Button
        {

            Margin = new Thickness(60, 400, 60, 20),
            Text = "Read More",
            Font = Font.SystemFontOfSize(NamedSize.Title),
            HorizontalOptions = LayoutOptions.Center,
            BackgroundColor = Color.LightBlue,
            TextColor = Color.Black,
            IsVisible = false,
             

        };



        public Image arrowimage = new Image
        {
            Source = ImageSource.FromFile("Arrow.png"),
            Scale = 0.2,
            VerticalOptions = LayoutOptions.Start,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Aspect = Aspect.AspectFit,
            IsVisible = false,
            Margin = new Thickness(55, -250, 0, 0), //Further negative in y to raise up image || Further positive in x to move image left
        };
















        public Reccomendation()
        {
            BookInfo.fromrec = true;
           if(agepreference != null)
            {
                 age.SelectedItem = agepreferenceUP;
                 
            }

           if(racepreference != null)
            {
                race.SelectedItem = racepreferenceUP;     //Checks on load if the pickers have been reset
            }

           if(genderpreference != null)
            {
                gender.SelectedItem = genderpreferenceUP;
            }
            carouselView.ItemsSource = bookcovers;




            
            if (prodevice)
            {
                homeicon.Scale = .2;
                homeicon.Margin = new Thickness(-70, -200, 0, 0);
                arrowimage.Scale = .4;
                //Go further negative for Y increase
            }

            else if (!prodevice)
            {

                BookTitle.Margin = new Thickness(110, 380, 0, 0);
                AuthorName.Margin = new Thickness(105, 190, 0, 0);
                carouselView.Margin  = new Thickness(20, -70, 0, 0);

                carouselView.Scale = 3.25;

                

            }

            if (moreinfo) {
                ReadMore.Clicked += OnButtonClicked;
                moreinfo = false;
            }

            if (clickhome)
            {

               homeicon.Clicked += BacktoHome;
                clickhome = false;
            }

            if (!assignedlists)
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

                assignedlists = true;

            }

 

          

            bookcovers.CollectionChanged += booksretrieved;

            

            age.ItemsSource = agetypes;

            race.ItemsSource = racetypes;

            gender.ItemsSource = genders;


            race.SelectedIndexChanged += (sender, args) =>
            {
                QueryDatabase.anyrace = false;

                racepreference = race.Items[race.SelectedIndex];
                racepreferenceUP = racepreference;
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
                agepreferenceUP = agepreference;
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
                genderpreferenceUP = genderpreference;
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
                if (bookcovers.Count > 0)
                {

                    disappearingbook = (BookCover)carouselView.SelectedItem;
                    booktitle = disappearingbook.thisbook.booktitle;
                    authorname = disappearingbook.thisbook.authorname;

                    titlelength = booktitle.Length;
                    authorlength = authorname.Length;

                    SetTitleLength();
                    GetTitleSize();
                    
                    BookTitle.Text = booktitle;
                    AuthorName.Text = authorname;
                }

            };






            // Accomodate iPhone status bar.
            // this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            this.Content = new StackLayout
            {

                BackgroundColor = Color.AliceBlue, //Default is Alice Blue
                Orientation = StackOrientation.Vertical,

                Margin = new Thickness(0),
                Spacing = -170, //Go positively to increase spacing
                
                Children = {
                    age,
                    race,
                    gender,

                    generatebooks,
                    homeicon,
                    BookTitle,
                    AuthorName,
                    carouselView,
                    ReadMore,
                     arrowimage,


                    }

            };


        }

        private void SetTitleLength()
        {
            for(int i = 0; i< titlelength; i++)
            {
                if (char.IsPunctuation(booktitle[i]))
                {
                    titlelength -= 1;
                }
            }

        }

        private static void GetTitleSize()
        {
            

            if (titlelength >= 20 && !prodevice)
            {

                carouselView.Margin = new Thickness(-20, -75, 0, 0);
                ReadMore.Margin = new Thickness(60, 400, 60, 20);
            }

            else if (titlelength >= 20 && prodevice)
            {

                carouselView.Margin = new Thickness(20, -100, 0, 0);
                ReadMore.Margin = new Thickness(60, 425, 60, 20);
            }

             if (authorlength >= 20 && prodevice)
            {
                carouselView.Margin = new Thickness(5, -155, 0, 0);
                ReadMore.Margin = new Thickness(70, 450, 70, 20);
            }

            else if (authorlength >= 20 && !prodevice)
            {
                carouselView.Margin = new Thickness(5, -75, 0, 0);
                ReadMore.Margin = new Thickness(95, 400, 140, 20);
            }


           

            else if(authorlength < 20 && titlelength <20)
            {
                carouselView.Margin = new Thickness(-20, -70, 0, 0);
                ReadMore.Margin = new Thickness(60, 400, 60, 20);
            }

            if (titlelength >= 30 && authorlength >= 20 && !prodevice)
            {
                carouselView.Margin = new Thickness(20, -135, 0, 0);
                ReadMore.Margin = new Thickness(60, 435, 60, 20);
            }



        }

        public void booksretrieved(object sender, NotifyCollectionChangedEventArgs e)
        {
            generatebooks.Text = " ";
            if (firstbook && bookcovers.Count> 0)
            {
                
                BookTitle.Text = bookcovers[0].thisbook.booktitle;
                AuthorName.Text = bookcovers[0].thisbook.authorname;
                carouselView.SelectedItem = bookcovers[0];
                booktitle = BookTitle.Text;
                authorname = AuthorName.Text;
                swipedindex = 1;
                firstbook = false;
                ReadMore.IsVisible = true;
                GetTitleSize();
                arrowimage.IsVisible = true;
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
                    Device.GetNamedSize(NamedSize.Title, typeof(Label));
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

                
                QueryDatabase.calldatabase(); //If all of the pickers are filled, call the database.
            }
        }
        public async void FadeOutArrow()
        {

            arrowimage.Opacity = 1;
            await arrowimage.TranslateTo(-100, arrowimage.Y, 1300);
            await arrowimage.FadeTo(0, 1000);


        }

        async void OnButtonClicked(object sender, EventArgs args)

        {
            await Navigation.PushModalAsync(new BookInfo(disappearingbook));
            return;

        }

        async void BacktoHome(object sender, EventArgs args)
            
        {
               await Navigation.PushModalAsync(new MainPage());
            QueryDatabase.booksindexed = 0;
            bookcovers.Clear();
            racepreferenceUP = "Race";
            agepreferenceUP = "Age";
            genderpreferenceUP = "Gender";
            agepreference = null;
            racepreference = null;
            genderpreference = null;
            ReadMore.IsVisible = false;
            BookTitle.Text = "Book Title";
            AuthorName.Text = "Author Name";
            generatebooks.Text = "Fill in the tags to generate books!";
            firstbook = true;
            return;
            


        }


    }

}




