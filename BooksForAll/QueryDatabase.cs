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

                if (books.ElementAt(i).Object.Race.Equals(Reccomendation.racepreference))
                {



                    Book thisbook = new Book();

                    thisbook.isbn = books.ElementAt(i).Object.isbn;
                    thisbook.Race = books.ElementAt(i).Object.Race;

                    BookSearch.SearchISBN(thisbook.isbn, thisbook);
                }

            }
            Reccomendation.generatebooks.Text = "";
            return;
        }

        
    }



}
