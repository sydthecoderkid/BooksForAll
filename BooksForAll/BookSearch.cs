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

namespace BooksForAll
{
    public class BookSearch
    {


        private static string API_KEY = "AIzaSyCzAEOcV1P3U_ky3c5LuB4tUYPGlNk8B6g";






        public static BooksService service = new BooksService(new BaseClientService.Initializer
        {
            ApplicationName = "booksforall",
            ApiKey = API_KEY,
        });

        public static async Task<Volume> SearchISBN(string isbn)
        {
            Console.WriteLine("Executing a book search request for ISBN: {0} ...", isbn);
            var result = await service.Volumes.List(isbn).ExecuteAsync();
            if (result != null && result.Items != null)
            {
                var book = result.Items.First();
                MainPage.authorname = book.VolumeInfo.Authors.FirstOrDefault();
                return book;
            }

            return null;
        }

    }
}
