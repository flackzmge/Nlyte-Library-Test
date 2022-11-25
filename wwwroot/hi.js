import DataService from "./data-service.js";

class ListRenderer {
  constructor() {}
  // List the Books in file using BookRepository.cs
  listBooks() {
    // create a function that gets the books using getBooks() from data-service.js
    var dataservice = new DataService();

    // create a global variable to hold book id
    var BookId = 0;
    var currentRowItem = null;

    // Create a function that gets the books using getBooks() from data-service.js
    dataservice.getBooks().then((books) => {
      if (!books) {
        return;
      } else {
        var bookList = document.getElementById("book-list");
        bookList.innerHTML = "";
        books.forEach((book) => {
          var bookItem = document.createElement("li");
          bookItem.innerHTML = book.title;

          bookList.appendChild(bookItem);
          // add an event listener to Display top 10 books
          bookItem.addEventListener("click", GetTop10(bookItem.BookId));
          // add an event listener to change the title
          //bookItem.addEventListener("click", ChangeTitle);

          // clear search text when a new book is selected using ClearSearch function and call GetTop10 function
          bookItem.addEventListener("click", ClearSearch);

          //var searchButton = document.getElementById("searchTxt");
          bookItem.addEventListener("click", ClearSearch);
          bookItem.addEventListener("click", ChangeTitle(bookItem.title));

          var button = document.getElementById("searchBtn");
          button.addEventListener("click", ChangeTitle(bookItem.title));

          var searchField = document.getElementById("searchTxt");

          searchField.addEventListener("keyup", SearchForWord(bookItem.BookId));
          searchField.addEventListener("keyup", ChangeTitle(bookItem.title));

          // add an event listener to search for a word
          //bookItem.addEventListener("click", SearchForWord);

          //currentRowItem = bookItem;

          //bookItem.addEventListener("click", SearchForWord);

          function GetTop10() {
            // call the function to list the top words
            dataservice.getTopWords(book.id).then((words) => {
              if (!words) {
                return;
              } else {
                var topWords = document.getElementById("word-list");
                //var count = 0;
                topWords.innerHTML = "";
                words.forEach((word) => {
                  var topWordsItem = document.createElement("tr");
                  // create a td element for word.word and word.count and append to topWordsItem
                  var wordItem = document.createElement("td");
                  wordItem.innerHTML = word.word;
                  topWordsItem.appendChild(wordItem);
                  var countItem = document.createElement("td");
                  countItem.innerHTML = word.count;
                  topWordsItem.appendChild(countItem);
                  topWords.appendChild(topWordsItem);

                  return topWords;
                });
              }
            });
          }

          // function to clear the search text when a new book is selected in book list
          function ClearSearch() {
            var searchTxt = document.getElementById("searchTxt");
            searchTxt.value = "";
          }

          // create a function to change the title of the book when clicked
          function ChangeTitle() {
            var title = document.getElementById("word-title");
            // if searchTxt >= 3 then word-title = words in book.title starting with searchTxt else word-title = Most common words in: book.title
            var searchTxt = document.getElementById("searchTxt").value;
            if (searchTxt.length >= 3) {
              title.innerHTML =
                "Words in: " + book.title + " starting with: " + searchTxt;
              //appendChild(title);
              //appendChild(searchTxt);
            } else if (searchTxt.length < 3) {
              //currentRowItem.click();
              title.innerHTML = "Most common words in: " + book.title;
              //appendChild(title);
            }

            return title;
          }

          //var searchField = document.getElementById("searchTxt");

          //searchField.addEventListener("keyup", SearchForWord(book.id));
          //searchField.addEventListener("keyup", ChangeTitle(book.title));

          // create a function that searches a query in the book, takes the book id and the query as parameters and returns the word and the count if the query if the query is >= 3
          function SearchForWord() {
            var searchTxt = document.getElementById("searchTxt").value;
            if (searchTxt.length >= 2) {
              dataservice.getSearchForWord(book.id, searchTxt).then((words) => {
                if (!words) {
                  return;
                } else {
                  var topWords = document.getElementById("word-list");
                  topWords.innerHTML = "";
                  words.forEach((word) => {
                    var topWordsItem = document.createElement("tr");
                    // create a td element for word.word and word.count and append to topWordsItem
                    var wordItem = document.createElement("td");
                    wordItem.innerHTML = word.word;
                    topWordsItem.appendChild(wordItem);
                    var countItem = document.createElement("td");
                    countItem.innerHTML = word.count;
                    topWordsItem.appendChild(countItem);
                    topWords.appendChild(topWordsItem);

                    return topWords;
                  });
                }
              });
            }
          }

          return bookList;
        });
      }
    });

    /*
    function SearchQuery() {
            var searchTxt = document.getElementById("searchTxt").value;
            if (searchTxt.length >= 3) {
              dataservice.getSearchForWord(book.id, searchTxt).then((count) => {
                if (!count) {
                  return;
                } else {
                  var searchCount = document.getElementById("searchCount");
                  searchCount.innerHTML = count;
                }
              });
            }
          }

          dataservice.getWordCount().then((id, word) => {
            if ((!id, word)) {
              return;
            } else {
              var wordCount = document.getElementById("word-count");
              wordCount.innerHTML = "";
              id.forEach((id) => {
                var wordCountItem = document.createElement("td");
                wordCountItem.innerHTML = id;
                wordCount.appendChild(wordCountItem);

                return wordCount;
              });
            }
          });

          // Create a function that gets the search for word using getSearchForWord() from data-service.js
          dataservice.getSearchForWord().then((id, query) => {
            if ((!id, query)) {
              return;
            } else {
              var searchForWord = document.getElementById("search-for-word");
              searchForWord.innerHTML = "";
              id.forEach((id) => {
                var searchForWordItem = document.createElement("li");
                searchForWordItem.innerHTML = id;
                searchForWord.appendChild(searchForWordItem);

                return searchForWord;
              });
            }
          });
    */
  }
}

export default ListRenderer;
