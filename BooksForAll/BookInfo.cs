using System;
using Xamarin.Forms;

namespace BooksForAll
{
    public class BookInfo: ContentPage
    {
        public BookInfo(BookCover bookcover)
        {
            string booktextone = bookcover.thisbook.summary;

            string booktextwo = "";

            string booktextthree = "";

           
            if(booktextone.Length >= 1200)
            {
                booktextthree = booktextone;

                int maxlength = (booktextone.Length / 2) ;
                booktextone = booktextone.Substring(0, maxlength ) + ".......";
                booktextwo = "";
            }

            Label booksummary = new Label
            {
                 
                Text = booktextone,
                TranslationY = 300,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                
            };

            Label whitepsace = new Label
            {

                Text = booktextwo,
                TranslationY = 300,
                FontSize = 60,
                HorizontalOptions = LayoutOptions.Center,

            };

            Label booksumaryparttwo = new Label
            {
                Text = booktextthree,
                TranslationY = 300,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
            };

            Button seemore = new Button
            {
                Text = "See more",
                BackgroundColor = Color.LightBlue,
                TranslationY = 300,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
            };


            Image bookimage = new Image
            {
                Source = bookcover.imagesource,
                Scale = 3.8,
               TranslationY = 150,
                HorizontalOptions = LayoutOptions.Center,
            };

            var stack = new StackLayout();

            stack.Children.Add(bookimage);
            stack.Children.Add(booksummary);
            stack.Children.Add(whitepsace);
            stack.Children.Add(seemore);

            Content = new ScrollView { Content = stack };
            


        }

        

    }

    
}
