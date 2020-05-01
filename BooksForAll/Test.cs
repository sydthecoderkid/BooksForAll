using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Firebase.Database;
using Firebase.Database.Query;

namespace BooksForAll
{
    public class Test
    {

        public static FirebaseClient firebase = new FirebaseClient("https://booksforall.firebaseio.com/");
        public static ChildQuery bookholder;

        public static async void calldatabase()
        {
            var books = await firebase.Child("Books")
            .OnceAsync<Book>();

            foreach (var book in books)
            {
                Console.WriteLine($"{ book.Key} is { book.Object.isbn } ");
                MainPage.thisbook.isbn = book.Object.isbn;
                BookSearch.SearchISBN(MainPage.thisbook.isbn);
            }
        }

    }


    
}
