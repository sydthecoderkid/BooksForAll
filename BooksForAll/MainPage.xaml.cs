using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;


namespace BooksForAll
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public static Book thisbook;

        public MainPage()
        {

            thisbook = new Book();


            BookSearch.SearchISBN(thisbook.isbn);
<<<<<<< HEAD
        



            InitializeComponent();

=======


            Test.calldatabase();

            InitializeComponent();
            //Note: nothing is displaying being the isbn has been removed! 
>>>>>>> 815c59a... Initial check-in of module BooksForAll

        }

        async void OnButtonClicked(object sender, EventArgs args)

        {
            await Navigation.PushModalAsync(new MyTabbedPage());
        }
    }

}