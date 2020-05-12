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
            int index = 0;
            var books = await firebase.Child("Books")
            .OnceAsync<Book>();

            foreach (var book in books)
            {
                if (books.ElementAt(index).Object.race.Equals("Black")){
                    MainPage.thisbook.isbn = books.ElementAt(index).Object.isbn;
                    MainPage.thisbook.race = books.ElementAt(index).Object.race;
                    BookSearch.SearchISBN(MainPage.thisbook.isbn);
                    MainPage.books.Add(book);
                    return;
                }

                index++;

            }
            
        }

    }



}
