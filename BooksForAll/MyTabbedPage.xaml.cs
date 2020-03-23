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

            var layout = new StackLayout();
            var button = new Button
            {
                Text = "StackLayout",
                FontSize = 24,
                VerticalOptions = LayoutOptions.Center,
                Margin = 50,
                HorizontalOptions = LayoutOptions.Center
            };
            Image bookholder = new Image()
            {
                // IsVisible = true,
                //Aspect = Aspect.AspectFit,
                Source = ImageSource.FromFile("/Users/sydneykeating/Projects/BooksForAll/BooksForAll/BooksForAll.iOS/Resources/BookCover.jpg"),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,

            };


            layout.Children.Add(button);
            layout.Children.Add(bookholder);
            layout.Spacing = 0;
            InitializeComponent();
        }
    }
}
