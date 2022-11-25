using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Library.Models
{
   
    public class Book
    {

        public Book()
        {
            Id = 0;
            Title = "";
            Author = "";
            Release_Date = "";
            Last_Updated = "";
            Character_set_encoding = "";
            Forward = "";
            Language = "";
            BookBody = "";
            WordDictionary  = new Dictionary<string, int>();
            

        }
        // Expose properties for the Id and Title
        public int Id { get; set; } 

        public string Title { get; set; }

        public string  Author { get; set; }

        public string Release_Date { get; set; } 


        public string Last_Updated { get; set; }

        public string? Language { get; set; } 

        public string Character_set_encoding{ get; set; } 

        public string? Forward { get; set; } 

        public string? BookBody { get; set; }

   
        public Dictionary<string, int> WordDictionary { get; set; } 

    }
    
}
