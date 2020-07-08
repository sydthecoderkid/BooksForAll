using System;
using Xamarin.Forms;

namespace BooksForAll
{
    public class BookInfo : ContentPage
    {
        public BookCover bookcover;
        private int timescalled = 0;

        public CheckBox savebox = new CheckBox
        {
            Scale = 1.5,
            Margin = new Thickness(255, 85, 0, 0), //Further positive on the x to move right
        };

        public Label savelabel = new Label
        {
            Margin = new Thickness(85, -40, 0, 0),//Go further negative for Y increase
            Font = Font.SystemFontOfSize(NamedSize.Title),
            FontAttributes = FontAttributes.Bold,
            TextColor = Color.DarkBlue,
            Text = "Save Book",
        };

       public Image bookimage = new Image
        {
           
            Scale = 3.9,
            TranslationY = -10,
        };


        public BookInfo(BookCover bookcover)
        {
            string summary = bookcover.thisbook.summary;

            bookimage.Source = bookcover.imagesource;

            string booktextone = "";

            string booktextwo = "";

            string booktextthree = "";

            string booktexfour = "";

             int textheight = summary.Length;

            if (!Reccomendation.prodevice)
            {
                bookimage.Scale = 2.7;
            }

            this.bookcover = bookcover;
        int summaryheight = 250;
            if (summary.Length >= 1100)
            {
                int currentindex = 0;
                int maxlength = (summary.Length);
                booktextone = summary.Substring(0, (maxlength / 4));
                booktextwo = summary.Substring(booktextone.Length, (maxlength / 4));
                currentindex += (booktextwo.Length + booktextone.Length);
                booktextthree = summary.Substring(currentindex, (maxlength / 4));
                currentindex += booktextthree.Length;
                booktexfour = summary.Substring(currentindex, maxlength / 4);

                
                if (!booktexfour.EndsWith(".") && !booktexfour.EndsWith("?"))
                {
                    booktexfour += ".";
                }
                

            }

             

            else
            {
                booktextone = summary;
                if (!booktextone.EndsWith("."))
                {
                    booktextone += ".";
                }
            }


            Label booksummary = new Label
            {

                Text = summary,

                Font = Font.SystemFontOfSize(NamedSize.Body),
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, -20, 0 , 0),
            };


            
            ImageButton backbutton = new ImageButton
            {
                Source = ImageSource.FromFile("FlippedArrow.png"),
                Scale = 0.3,
                TranslationY = 0,
                TranslationX =-120,
            };

            backbutton.Clicked += BackToReccomended;
            Label Synopsis = new Label
            {

                Text = "Synopsis",
                Margin = new Thickness(0, -300, 0, 0),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontAttributes = FontAttributes.Bold,
                Font = Font.SystemFontOfSize(NamedSize.Title),
                
            };

           
            



            textheight = setheight(textheight);
            savebox.CheckedChanged += OnChecked;

            if (SavedPage.savedBooks.Contains(bookcover))
            {
                savebox.IsChecked = true;
                savelabel.Text = "Saved";
                savelabel.TextColor = Color.Gray;
            }

            ScrollView scrollView = new ScrollView
            {


                Content = new StackLayout
                {
                    HeightRequest = textheight,
                    Children =
                    {
                        backbutton,
                        bookimage,
                         Synopsis,
                         savebox,
                         savelabel,
                        new Label { Text = booktextone, TranslationY = summaryheight,  Margin = new Thickness (20)},
                        new Label {Text = booktextwo, TranslationY = summaryheight,  Margin = new Thickness (20)},
                        new Label {Text = booktextthree, TranslationY = summaryheight,  Margin = new Thickness (20)},
                        new Label {Text = booktexfour, TranslationY = summaryheight,  Margin = new Thickness (20)},
                    }
                }
                
            };

           
            this.Content = new StackLayout
            {


                Children = {

                    scrollView,
                  
                }

            };

           

        }

        async void BackToReccomended(object sender, EventArgs e)
        {

            if (timescalled == 0)
            {
                await Navigation.PushModalAsync(new Reccomendation());
                timescalled += 1;
            }
                
            
        }

        public static string getauthor(Book thisbook)
        {

            return thisbook.authorname;
        }

        public static string getbooktitle(Book thisbook)
        {
            return thisbook.booktitle;
        }

        public static int setheight(int textheight) {

             if (textheight >= 1100){

                textheight = 1600;
            }
            else
            {
                textheight = 1000;
            }


            return textheight;

        }

        async void OnChecked(object sender, EventArgs args)

        {

            if (!SavedPage.savedBooks.Contains(bookcover) && savebox.IsChecked)
            {
                SavedPage.savedBooks.Add(bookcover);
                savelabel.Text = "Saved";
                savelabel.TextColor = Color.Gray;
            }

            else if(SavedPage.savedBooks.Contains(bookcover) && !savebox.IsChecked)
            {
                savelabel.Text = "Save Book";
                savelabel.TextColor = Color.Black;
                SavedPage.savedBooks.Remove(bookcover);
            }

        }


    }


}
