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
        public static bool anyage;
        public static bool anyrace;

        public static async void calldatabase()
        {
            string race;
            string age;
            string gender;



            var books = await firebase.Child("Books")
            .OnceAsync<Book>();

            

            for (int i = 0; i < books.Count; i++)
            {
                race = books.ElementAt(i).Object.Race;
                age = books.ElementAt(i).Object.Age;


                if (age.Equals(Reccomendation.agepreference) || anyage)
                {
                    Console.WriteLine(age);

                    if (race.Equals(Reccomendation.racepreference) || anyrace)
                    {
                        Console.WriteLine(race);
                        Book thisbook = new Book();

                        thisbook.isbn = books.ElementAt(i).Object.isbn;
                        thisbook.Race = books.ElementAt(i).Object.Race;

                        BookSearch.SearchISBN(thisbook.isbn, thisbook);
                    }
                    
                }
                

            }
             
            Reccomendation.generatebooks.Text = "";
            return;


        }



    }
}
