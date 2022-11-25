class DataService {
  static fetchJson(path) {
    return fetch("/api/" + path).then((response) => {
      if (!response.ok) {
        throw response.statusText;
      }
      return response.json();
    });
  }
  getBooks() {
    // Get the books from the BookRepository using the web api and render them to the page
    return DataService.fetchJson("Books");
  }
  // Create a function that gets the books using getBooks() from data-service.js

  getTopWords(id) {
    return DataService.fetchJson("Books" + "/" + id);
  }

  getWordCount(id, word) {
    return DataService.fetchJson(
      "Books" + "/" + id + "/" + "count" + "/" + word
    );
  }

  getSearchForWord(id, query) {
    return DataService.fetchJson(
      "Books" + "/" + id + "/" + "search" + "/" + query
    );
  }
}
export default DataService;
