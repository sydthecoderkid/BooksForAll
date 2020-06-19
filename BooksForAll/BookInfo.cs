using System;
using Xamarin.Forms;

namespace BooksForAll
{
    public class BookInfo : ContentPage
    {
        private int timescalled = 0;
        public BookInfo(BookCover bookcover)
        {
            string summary = bookcover.thisbook.summary;

            string booktextone = "";

            string booktextwo = "";

            string booktextthree = "";

            string booktexfour = "";

             int textheight = summary.Length;

            
      

        int summaryheight = 140;

            if (summary.Length >= 1200)
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
                TranslationY = 0,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,

            };


            Image bookimage = new Image
            {
                Source = bookcover.imagesource,
                Scale = 3.8,
                TranslationY = -10,
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
                FontSize = 25,
                TranslationY = 160,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontAttributes = FontAttributes.Bold,
                TextDecorations = TextDecorations.Underline,
            };

            CheckBox savebox = new CheckBox
            {
                TranslationY = 120,
                
            };


            textheight = setheight(textheight);
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

             if (textheight >= 1200){

                textheight = 1700;
            }
            else
            {
                textheight = 1000;
            }


            return textheight;

        }

    }


}
