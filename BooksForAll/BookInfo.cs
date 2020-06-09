using System;
using Xamarin.Forms;

namespace BooksForAll
{
    public class BookInfo: ContentPage
    {
        public BookInfo(BookCover bookcover)
        {


            Label booksummary = new Label
            {
                Text = bookcover.thisbook.summary,
                TranslationY = 300,
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Center,
                
            };

            Image bookimage = new Image
            {
                Source = bookcover.imagesource,
                Scale = 3.8,
               TranslationY = 150,
                HorizontalOptions = LayoutOptions.Center,
            };

            var stack = new StackLayout()
            {
                Children =
                {
                    bookimage,
                    booksummary,
                    
                }
            };
            this.Content = new ScrollView
            {
                Content = stack, 


            };


        }

        

    }

    
}
