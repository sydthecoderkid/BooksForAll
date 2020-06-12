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

                if (!booktexfour.EndsWith("."))
                {
                    booktexfour += ".";
                }

            }

            else
            {
                if (!booktextone.EndsWith("."))
                {
                    booktextone += ".";
                }
                booktextone = summary;
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
                TranslationY = 200,
            };

            Label Synopsis = new Label
            {

                Text = "Synopsis",
                FontSize = 25,
                TranslationY = 450,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            ScrollView scrollView = new ScrollView
            {

                Content = new StackLayout
                {
                    HeightRequest = 1500,
                    Children =
                    {
                         Synopsis,
                        bookimage,
                        new Label { Text = booktextone, TranslationY = 520},
                        new Label {Text = booktextwo, TranslationY = 520},
                        new Label {Text = booktextthree, TranslationY = 520},
                        new Label {Text = booktexfour, TranslationY = 520},
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

    }


}
