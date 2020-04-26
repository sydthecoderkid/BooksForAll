using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FFImageLoading;
using FFImageLoading.Cache;
using FFImageLoading.Forms;
using System.Reflection;



namespace BooksForAll
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTabbedPage : TabbedPage
    {
        public MyTabbedPage()
        {

            this.Children.Add(new ContentPage
            {
                Title = "BOOKS",
                Content = new StackLayout
                {

                    Children =
                        {
                            new Label
                            {
                                FontSize = 20,
                                Text = "Books",
                                TextColor = Color.Black,
                                FontAttributes = FontAttributes.Bold,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                VerticalOptions = LayoutOptions.Start

                            },

                             new Label //Author Name
                             {
                                FontSize = 19,
                                Text = MainPage.thisbook.authorname,
                                TextColor = Color.Black,
                                FontAttributes = FontAttributes.Bold,
                               TranslationX = 90,
                               TranslationY = 750
                             },

                              new Label //Book title
                             {
                                FontSize = 25,
                                Text = MainPage.thisbook.bookname,
                                TextColor = Color.Black,
                                FontAttributes = FontAttributes.Bold,
                               TranslationX = 90,
                               TranslationY = 650
                              },

                             new CachedImage
                             {
                                 TranslationX = 0,
                                 TranslationY = 15,
                                 VerticalOptions = LayoutOptions.Center,
                                 WidthRequest = 500,
                                 HeightRequest = 500,
                                 Source = MainPage.thisbook.imagesource
                             }

                    }
                },

            }
       ) ;
            

            this.Children.Add(new ContentPage
            {
                Title = "Movies",
                Content = new Label
                {
                    FontSize = 24,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Text = "Movies" 
                },


            }
            ) ;

            this.Children.Add(new ContentPage
            {

                Title = "Podcasts",
                Content = new Label
                {
                    FontSize = 24,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Text = "Podcasts"
                },

            }
           );
        }
    }
}
