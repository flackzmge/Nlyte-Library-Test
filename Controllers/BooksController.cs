using Library.Models;
using Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    /*
    * 
        BE – Simple command line app that reads in a text file, counts the number of words and returns the most common ten.

        UI – Very simple HTML app which shows how to retrieve some data and display it on the page. 
        i.e. a HTML page including a <script> tag which loads a JS ‘app’ file via ES6 type=”module”.
                        
    */
    

    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly BookRepository repository = new BookRepository();
        private static readonly BookWordsRepository bookWordsRepository = new BookWordsRepository();

        // Method to get books
 

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            // Return the list of book ids and titles

            // Or Author and other fields can be used to search for Books in an added feature 
            // Get the list of books from the repository and return it
            // Return the list of book ids and titles
            //return repository.Books;
           
            if (repository.Books == null)
            {
                repository.Books = repository.LoadBooksFromFiles();
            }
            else if (repository.Books.Count == 0)
            {
                repository.Books = repository.LoadBooksFromFiles();
            }
            else
            {
                return repository.Books;
            }

           return repository.Books;
           
        }

        
        

        [HttpGet("{id:int}")]
        public IActionResult GetTopWords(int id)
        {
            // Return a list of the 10 most common words (>=5 letters) 
            // and the number of times they occur in the book

            Book book = repository.GetBook(id);
            bookWordsRepository.WordDictionary = book.WordDictionary;


            var words = bookWordsRepository.MostCommonWords();
            if (words == null)
            {
                return NotFound();
            }
            return Ok(words);
            
          
            
            
        }

        [HttpGet("{id:int}/count/{word}")]
        public IActionResult WordCount(int id, string word)
        {
            // Return the number of times a word occurs in the book

            Book book = repository.GetBook(id);
            bookWordsRepository.WordDictionary = book.WordDictionary;

            var count = bookWordsRepository.GetCount(word);
            if (count == null)
            {
                return NotFound();
            }
            // if word length is less than 3 return not found ekse return ok
            if (word.Length < 3)
            {
                return NotFound();
            }
            else
            {
                return Ok(count);
            }
            
           
            
            
        }

        [HttpGet("{id:int}/search/{query}")]
        public IActionResult SearchForWord(int id, string query)
        {
            // Return a list of words (>=3 letters) relatiiing to the query
            // and the number of times they occur in the book
            Book book = repository.GetBook(id);
            bookWordsRepository.WordDictionary = book.WordDictionary;

            var words = bookWordsRepository.Search(query);
            if (words == null)
            {
                return NotFound();
            }
            // if word length is less than 3 return not found ekse return ok
            if (query.Length >= 3)
            {
               return Ok(words);
            }
            else
            {
                return NotFound();
                
            }

           

           
            
        }

    }
}

