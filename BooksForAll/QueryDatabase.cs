using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Firebase.Database;
using Firebase.Database.Query;

namespace BooksForAll
{
    public class QueryDatabase
    {

        public static FirebaseClient firebase = new FirebaseClient("https://booksforall.firebaseio.com/");
        public static ChildQuery bookholder;

        public static async void calldatabase()
        {
            var books = await firebase.Child("Books")
            .OnceAsync<Book>();

            foreach (var book in books)
            {
               
                    MainPage.thisbook.isbn = books.ElementAt(1).Object.isbn;
                    MainPage.thisbook.race = books.ElementAt(1).Object.race;
                    BookSearch.SearchISBN(MainPage.thisbook.isbn);

            }
         //   MainPage.thisbook.isbn = books.ElementAtOrDefault(0).Object.isbn;
          //  MainPage.thisbook.race = books.ElementAtOrDefault(0).Object.race;

            
        }

    }



}
