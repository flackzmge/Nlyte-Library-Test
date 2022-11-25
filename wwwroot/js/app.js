import ListRenderer from "./list-renderer.js";
import DataService from "./data-service.js";

class App {
  constructor() {
    // TODO - I've included some examples of how classes work in ES6. Feel free to change the architecture as needed.
    var renderer = new ListRenderer();
  }

  go() {
    var dataservice = new DataService();

    // TODO

    // TODO - call the render method on the renderer, and pass it the data
    var renderer = new ListRenderer();
    // TODO - call listBooks on the data service, and pass it a callback function that will be called when the data is returned
    renderer.listBooks();
  }
}
new App().go();
