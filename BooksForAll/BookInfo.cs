using System;
using Xamarin.Forms;

namespace BooksForAll
{
    public class BookInfo : ContentPage
    {
        public static BookCover bookcover;
        private int timescalled = 0;

        public static bool fromrec;

        public CheckBox savebox = new CheckBox
        {
            Scale = 1.5,
            
            Margin = new Thickness(255, -43, 0, 0), //Further positive on the x to move right
        };

        public Label savelabel = new Label
        {
            Margin = new Thickness(90, 300, 0, 0),//Go further negative for Y increase
            Font = Font.SystemFontOfSize(NamedSize.Title),
            TextColor = Color.DarkBlue,
            FontAttributes = FontAttributes.Bold,
            Text = "Save Book",
        };

       public Image bookimage = new Image
        {
           
            Scale = 3.9,
            HorizontalOptions = LayoutOptions.Center,
           Margin = new Thickness(0, 200, 0, 0),
       };


        public BookInfo(BookCover passedbookcover)
        {

            bookcover = passedbookcover;

            string summary = bookcover.thisbook.summary;

            bookimage.Source = bookcover.imagesource;


            string booktextone = "";

            string booktextwo = "";

            string booktextthree = "";

            string booktexfour = "";

             int textheight = summary.Length;
         
            for(int i = 0; i < SavedPage.savedBooks.Count; i++)
            {
                if (SavedPage.savedBooks[i].thisbook.booktitle.Equals(bookcover.thisbook.booktitle)){
                    bookcover = SavedPage.savedBooks[i];
                }
            }
            if (SavedPage.savedBooks.Contains(bookcover)) {
                savelabel.Text = "Saved";
                savelabel.TextColor = Color.Gray;
                savebox.IsChecked = true;
            }


         

            if (summary.Length >= 1000)
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

                Font = Font.SystemFontOfSize(NamedSize.Default),
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, -20, 0 , 0),
            };


            
            ImageButton backbutton = new ImageButton
            {
                Source = ImageSource.FromFile("FlippedArrow.png"),
                Scale = .2,
                Margin = new Thickness(-250, -350, 0, 0),
            };

            backbutton.Clicked += BackToReccomended;
            Label Synopsis = new Label
            {

                Text = "Synopsis",
                Margin = new Thickness(0, -150, 0, 0),
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(NamedSize.Title),
                
            };

            if (Reccomendation.prodevice) {

                Synopsis.Margin = new Thickness(0, -125, 0, 0);
                savelabel.Margin = new Thickness(100, 346, 0, 0);
                savebox.Margin = new Thickness(265, -45, 0, 0);
                backbutton.Margin = new Thickness(-270, -300, 0, 0);
                backbutton.Scale = .4;

            }

            if (!Reccomendation.prodevice)
            {
                bookimage.Scale = 2.7;
            }






            textheight = setheight(textheight);
            savebox.CheckedChanged += OnChecked;



            ScrollView scrollView = new ScrollView
            {


                Content = new StackLayout
                {
                    HeightRequest = textheight,
                    Children =
                    {
                         bookimage,

                        backbutton,
                         Synopsis,
                          savelabel,
                         savebox,
                        new Label { Text = booktextone,  Margin = new Thickness (20, 10, 0 , 0)},
                        new Label {Text = booktextwo,  Margin = new Thickness (20, 20, 0 , 0)},
                        new Label {Text = booktextthree,  Margin = new Thickness (20, 30, 0 , 0)},
                        new Label {Text = booktexfour,  Margin = new Thickness (20, 40, 0 , 0)},
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


            if (fromrec)
            {
                await Navigation.PushModalAsync(new Reccomendation());
            }
            else {

                await Navigation.PushModalAsync(new SavedPage());
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

             if (textheight >= 1000){

                textheight = 1600;     //Sets the height of the scrollview based on the height of the actual text
            }
            else
            {
                textheight = 1100;
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
                savelabel.TextColor = Color.DarkBlue;
                SavedPage.savedBooks.Remove(bookcover);
            }

        }


    }


}
