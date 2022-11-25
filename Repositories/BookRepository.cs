using System;
using System.IO;
using System.Runtime.InteropServices;
using Library.Models;

namespace Library.Repositories
{

    public class BookRepository
    {
        // Read the list of book files in the Resources folder and allow  to retrieve a repository of the words for each book
        // NOTE: Avoid re-reading files on each request.

        private static readonly BookWordsRepository bookWordsRepository = new BookWordsRepository();

        public BookRepository()
        {
            // Constructor
            Books = LoadBooksFromFiles();
        }

        public List<Book> Books { get; set; }

        public  List<Book>  LoadBooksFromFiles()
        {


            
            //string filepath = @"/Users/nathangilbert/Projects/LibrarySample-master/Resources/";
            string filepath = @"Resources/";
            
            string[] files = Directory.GetFiles(filepath, "*.txt", SearchOption.AllDirectories);

            //string[] files = System.IO.Directory.GetFiles(filepath, "*.txt");

            int Id = 0;

             List<Book> books = new List<Book>();
             

            foreach (string filename in files)
            {
               

                // create a variable called file, make it a streamreader and open the file
            
                StreamReader file = new StreamReader(filename);
                //Read first line of text
                string line = file.ReadLine();
                bool titleLabelFound = false;


                // create a new book object
                Book book = new Book();

            
                while (line != null)
                {
                

                if (line.Contains(":"))
                {

                    // Split the title and the other properties into Label/Property and Value
                    string[] lineparts = line.Split(':');
                    // Convert the label to lowercase in order to prevent case issues
                    string label = lineparts[0].ToLower().Trim();
                    string value = lineparts[1].Trim();
        
                    switch(label) 
                    {
                        case "title":
                            // if title found then set Title Value to the book and then repeat with other values 
                            titleLabelFound = true;
                            book.Title = value;
                            break;
                        case "author":
                            book.Author = value;
                            break;
                        case "release date":
                            book.Release_Date = value;
                            break;
                        case "last updated":
                            book.Last_Updated = value;
                            break;
                        case "language":
                            book.Language = value;
                            break;
                        case "character set encoding":
                            book.Character_set_encoding = value;
                            break;
                    }
                }
                else
                {
                    if (titleLabelFound)
                    {
                        // if the title is found and the other properties are checked  then the rest of the text is the book body
                       book.BookBody += line;
                    }
                }
                
                    
                
 
               
               // continue to read each line of text until the end of the file
                line = file.ReadLine();
                
            }

            if (titleLabelFound)
            {
                // add the book to the list of books

                book.WordDictionary = bookWordsRepository.Add(book.BookBody);

                books.Add(book);
                // increment the book id
                Id++;
                // set the book id to the book
                book.Id = Id;
            }

            // close the file
            file.Close();

               
                
            
            }
             // Return the list of books and bookBody
            return books;
 
 
        }


        public List<Book> GetBooks()
        {
            // Return the list of books
            return Books;
        }

        public Book GetBook(int id)
        {
            // Return the book with the given id
            return Books.FirstOrDefault(b => b.Id == id);
        }
           
    }
}
          
            
        
 

 

