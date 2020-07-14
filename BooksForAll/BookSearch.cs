using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Xamarin.Forms;


namespace BooksForAll
{
    public class BookSearch
    {


        private static string API_KEY = "AIzaSyDg-1oFOWXLWfqx25LYGkcpDU12XJWk9mo";





        public static BooksService service = new BooksService(new BaseClientService.Initializer
        {
            ApplicationName = "booksforall",
            ApiKey = API_KEY,
        });

        public static async Task<Volume> SearchISBN(string isbn, Book bookcalled)
        {

            var result = await service.Volumes.List(isbn).ExecuteAsync();
            if (result != null && result.Items != null)
            {
               
                var book = result.Items.First();
                bookcalled.authorname = book.VolumeInfo.Authors.First();
                bookcalled.booktitle = book.VolumeInfo.Title;
                bookcalled.imagesource = book.VolumeInfo.ImageLinks.Thumbnail;
                bookcalled.bookCover = new BookCover(bookcalled.imagesource, bookcalled);
                bookcalled.summary = book.VolumeInfo.Description;
                 
                Reccomendation.bookcovers.Add(bookcalled.bookCover);



            }

            return null;
        }

    }
}
