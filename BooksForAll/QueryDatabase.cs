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
        private static int booksgotten;


        public static async void calldatabase()
        {
            int index = 0;
            var books = await firebase.Child("Books")
            .OnceAsync<Book>();

            foreach (var book in books)
            {
                Book thisbook = new Book();
                        thisbook.isbn = books.ElementAt(index).Object.isbn;
                        thisbook.race = books.ElementAt(index).Object.race;
                        BookSearch.SearchISBN(thisbook.isbn, thisbook);
                

                index++;
       


            }
          
            
        }

    }



}
