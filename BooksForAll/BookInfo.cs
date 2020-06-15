using System;
using Xamarin.Forms;

namespace BooksForAll
{
    public class BookInfo : ContentPage
    {
        public BookInfo(BookCover bookcover)
        {
            string summary = bookcover.thisbook.summary;

            string booktextone = "";

            string booktextwo = "";

            string booktextthree = "";

            string booktexfour = "";

             int textheight = summary.Length;

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
                TranslationY = 3,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,

            };


            Image bookimage = new Image
            {
                Source = bookcover.imagesource,
                Scale = 3.8,
                TranslationY = 400,
            };

            Label Synopsis = new Label
            {

                Text = "Synopsis",
                FontSize = 25,
                TranslationY = 540,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };


            textheight = setheight(textheight);
            ScrollView scrollView = new ScrollView
            {


                Content = new StackLayout
                {
                    HeightRequest = textheight,
                    Children =
                    {
                        
                        bookimage,
                         Synopsis,
                        new Label { Text = booktextone, TranslationY = 520,  Margin = new Thickness (20)},
                        new Label {Text = booktextwo, TranslationY = 520,  Margin = new Thickness (20)},
                        new Label {Text = booktextthree, TranslationY = 520,  Margin = new Thickness (20)},
                        new Label {Text = booktexfour, TranslationY = 520,  Margin = new Thickness (20)},
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
