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
        private static int characterlengtth = 21;
        public BookCover bookCover { get; set; }

        public Book() {


        }

        public static explicit operator Book(FirebaseObject<Book> book)
        {
            
            return (Book)book;
        }

        public static string checkstringlength(string title)
        {
            if (title.Length <= characterlengtth)
            {
                return title;
            }
            else
            {
                title = title.Substring(0, characterlengtth) + ".....";
                return title;
            }

        }
    }

}
