using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
                            new Image {
                                Source = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRSyKVTjLq0GPFdi7h9if0qeTa4K1uDvA72FO6eoVLJJ__rNuXRtw"
                                     WidthRequest = 250,
                                     HeightRequest = 250
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
