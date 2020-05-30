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
        public static bool grabbedbooks;

        public static async void calldatabase()
        {
            var books = await firebase.Child("Books")
            .OnceAsync<Book>();

            for(int i = 0; i < books.Count; i++)
            {
                Book thisbook = new Book();
                thisbook.isbn = books.ElementAt(i).Object.isbn;
                thisbook.race = books.ElementAt(i).Object.race;
                BookSearch.SearchISBN(thisbook.isbn, thisbook);

            }
            Reccomendation.generatebooks.Text = "";
            return;
        }

        
    }



}
