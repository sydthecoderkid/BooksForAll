using System;
using Firebase.Database;
using Xamarin.Forms;

namespace BooksForAll
{
    public class Book
    {

        public string authorname;
        public string booktitle;
        public string imagesource;
        public string race { get; set; }
        public string isbn { get; set; }

        public static explicit operator Book(FirebaseObject<Book> book)
        {
            
            return (Book)book;
        }

        public static string checkstringlength(string title)
        {
            if (title.Length <= 21)
            {
                return title;
            }
            else
            {
                title = title.Substring(0, 21) + ".....";
                return title;
            }

        }
    }

}
