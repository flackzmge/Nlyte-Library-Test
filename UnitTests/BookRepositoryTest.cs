using Library.Models;
using Library.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Library.UnitTests
{
    [TestClass]
    public class BooksRepositoryTest
    {
        
        
        [TestMethod]
        public void Loading_Book_From_File_Should_Return_The_Right_Book_Related_To_The_BookId()
        {
            // New instance of the BookRepository
            BookRepository bookRepository = new BookRepository();
            // Load the books from the files
            var books = bookRepository.LoadBooksFromFiles();

            // Test if they match
            Assert.AreEqual(books[0].Id, 1);
            Assert.AreEqual(books[0].Title, "A Tale of Two Cities");

            Assert.AreEqual(books[1].Id, 2);
            Assert.AreEqual(books[1].Title, "The Hound of the Baskervilles");

            Assert.AreEqual(books[2].Id, 3);
            Assert.AreEqual(books[2].Title, "Moby Dick; or The Whale");
        } 


        [TestMethod]
        public void Test_On_Book1()
        {
            // New instance of the BookRepository
            BookRepository bookRepository = new BookRepository();
            // Load the books from the files
            var books = bookRepository.LoadBooksFromFiles();

            // Assert
            Assert.AreEqual(books[0].Id, 1);
            Assert.AreEqual(books[0].Title, "A Tale of Two Cities");
            Assert.AreEqual(books[0].Author, "Charles Dickens");
            Assert.AreEqual(books[0].Release_Date, "January, 1994 [EBook #98]");
            Assert.AreEqual(books[0].Last_Updated, "");
            Assert.AreEqual(books[0].Language, "English");
            Assert.AreEqual(books[0].Character_set_encoding, "UTF-8");

        }
        

        




        
    }
}
