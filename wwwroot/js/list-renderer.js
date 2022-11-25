import DataService from "./data-service.js";

class ListRenderer {
  constructor() {
    // TODO - I've included some examples of how classes work in ES6. Feel free to change the architecture as needed.
    this.dataService = new DataService();
  }
  // List the Books in file using BookRepository.cs
  listBooks() {
    // create a function that gets the books using getBooks() from data-service.js
    var dataservice = new DataService();

    var currentBookId = null;
    var currentTitle = null;
    var savedList = null;

    // create a global variable to hold book id
    var BookId = 0;
    // Create a function that gets the books using getBooks() from data-service.js
    dataservice.getBooks().then((books) => {
      if (!books) {
        return;
      } else {
        // create a variable to hold the list of books
        var bookList = document.getElementById("book-list");
        bookList.innerHTML = "";
        // loop through the books and create a list item for each book
        books.forEach((book) => {
          var bookItem = document.createElement("li");
          bookItem.innerHTML = book.title;
          bookList.appendChild(bookItem);

          // add an event listener to Display top 10 books
          bookItem.addEventListener("click", GetTop10);

          // add an event listener to search for a word
          var searchField = document.getElementById("searchTxt");
          searchField.addEventListener("keyup", SearchForWord);
          searchField.addEventListener("keyup", ChangeTitle);

          // add an event listener for search button
          var button = document.getElementById("searchBtn");
          button.addEventListener("click", ChangeTitle);

          function GetTop10() {
            // call the function to list the top words

            dataservice.getTopWords(book.id).then((words) => {
              if (!words) {
                return;
              } else {
                // get current book id
                currentBookId = book.id;
                // get current book title
                currentTitle = book.title;
                // set savedList to null
                savedList = null;
                var topWords = document.getElementById("word-list");
                //var count = 0;
                topWords.innerHTML = "";
                // loop through the words and create a list item for each word
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

                  // change the title of the page to the current book title
                  ChangeTitle();

                  return topWords;
                });
              }
            });
          }

          // create a function to change the title of the book when clicked
          function ChangeTitle() {
            var title = document.getElementById("word-title");
            // if searchTxt >= 3 then word-title = words in book.title starting with searchTxt else word-title = Most common words in: book.title
            searchTxt = document.getElementById("searchTxt").value;
            // create a variable that stores the current book title relating to the book id
            var Title = "";
            Title = currentTitle;
            // while typing keep the title constant

            if (searchTxt.length < 3) {
              title.innerHTML = "Most common words in: " + Title;
            } else {
              title.innerHTML =
                "Words in " + Title + " starting with: " + searchTxt;
            }
            //title.appendChild(titleItem);
            return Title;
          }

          dataservice.getWordCount().then((id, word) => {
            if ((!id, word)) {
              return;
            } else {
              var wordCount = document.getElementById("word-count");
              wordCount.innerHTML = "";
              id.forEach((id) => {
                // create a td element for word.word and word.count and append to topWordsItem
                var wordCountItem = document.createElement("td");
                wordCountItem.innerHTML = id;
                wordCount.appendChild(wordCountItem);

                // return wordCount;
                return wordCount;
              });
            }
          });

          // Create a function that gets the search for word using getSearchForWord() from data-service.js

          function SearchForWord() {
            // variable queryString to store the searchTxt value
            var queryString = document.getElementById("searchTxt").value;
            // if length of the query is less than 3 and SavedList is not null then display the saved list
            if (queryString.length < 3) {
              if (savedList != null) {
                var list = document.getElementById("word-list");
                list.innerHTML = savedList;
              }
              return;
            }

            dataservice
              .getSearchForWord(currentBookId, queryString)
              .then((words) => {
                if (!words) {
                  return;
                } else {
                  var wordList = document.getElementById("word-list");
                  //var count = 0;

                  if (savedList == null) savedList = wordList.innerHTML;

                  wordList.innerHTML = "";
                  words.forEach((word) => {
                    // Create a table row for each word
                    var wordsItem = document.createElement("tr");
                    // create a td element for word.word and word.count and append to topWordsItem

                    // Create a td element for the word
                    var wordItem = document.createElement("td");

                    // Set the innerHTML of the td element to the word
                    wordItem.innerHTML = word.word;

                    // Append the td element to the tr element
                    wordsItem.appendChild(wordItem);

                    // Create a td element for the count
                    var countItem = document.createElement("td");

                    // Set the innerHTML of the td element to the count
                    countItem.innerHTML = word.count;

                    // Append the td element to the tr element
                    wordsItem.appendChild(countItem);
                    wordList.appendChild(wordsItem);

                    // Change the Title of the book
                    ChangeTitle();
                    // return wordList for the search for word
                    return wordList;
                  });
                }
              });
          }
          // return the list of books
          return bookList;
        });
      }
    });
  }
}

export default ListRenderer;
