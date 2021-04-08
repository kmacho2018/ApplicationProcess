//require('bootstrap/dist/css/bootstrap.min.css');
//require('bootstrap');
//import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.css';

export class App {
  public message = 'Hello World!';

  async testRest() {
    debugger;
    const response = await fetch("https://localhost:44389/api/Assets", {
      method: 'POST',
      body: '{ "id": 0,        "assetName": "string",        "department": 1,        "countryOfDepartment": "string",        "eMailAdressOfDepartment": "string",        "purchaseDate": "2021-04-08T02:57:10.302Z",        "broken": true}',
      headers: {'Content-Type': 'application/json; charset=UTF-8'} });
    
    if (!response.ok) { /* Handle */ }
    
    // If you care about a response:
    if (response.body !== null) {
      // body is ReadableStream<Uint8Array>
      // parse as needed, e.g. reading directly, or
      //const asString = new TextDecoder("utf-8").decode(response.body);
      // and further:
      //const asJSON = JSON.parse(asString);  // implicitly 'any', make sure to verify type on runtime.
    }
    //$('[data-toggle="tooltip"]').tooltip();
  }
}
