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
        public static bool anygender;
        public static int booksindexed;


        public static async void calldatabase()
        {
            string race;
            string age;
            string gender;




            var books = await firebase.Child("Books")
            .OnceAsync<Book>();



            for (int i = booksindexed; i < books.Count; i++)
            {
                
                race = books.ElementAt(i).Object.Race;
                age = books.ElementAt(i).Object.Age;
                gender = books.ElementAt(i).Object.Gender;
                if (age.Equals(Reccomendation.agepreference) || anyage)
                {

                    if (race.Equals(Reccomendation.racepreference) || anyrace)
                    {
                        if (gender.Equals(Reccomendation.genderpreference) || anygender )
                        {
                            Book thisbook = new Book();

                            thisbook.isbn = books.ElementAt(i).Object.isbn;
                            thisbook.Race = books.ElementAt(i).Object.Race;

                            BookSearch.SearchISBN(thisbook.isbn, thisbook); //Adding an await causes issues. 
                            booksindexed++;

                        }

                    }
                    if (booksindexed % 5 == 0 && booksindexed > 0)
                    {
                        
                       // Reccomendation.generatebooks.Text = "";
                        return;
                    }
                }


               
            }

            
            

        }
    }
}
