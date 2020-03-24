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
                                VerticalOptions = LayoutOptions.CenterAndExpand
                            },


                            new Image
                            {
                                WidthRequest = 683,
                                HeightRequest = 347,
                                Aspect = Aspect.AspectFit,
                                Source = ImageSource.FromFile("BookCover.jpg"),
                            }
                        }
                },

            }
       ); ;
            ;

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

            }
           );

           //  InitializeComponent();
        }
    }
}
