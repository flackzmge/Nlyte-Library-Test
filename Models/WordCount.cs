using System.Runtime.Serialization;

namespace Library.Models
{

    public class WordCount
    {
        // Return lists of these objects, containing the Word searched for, and the count within the current book.
        public WordCount(string inWord, int inCount)
        {
            
            // Constructor 
            Word = inWord;
            Count = inCount;
        }
        public string Word { get; set; }
        public int Count { get; set; }

         //public Dictionary<string, int> WordDictionary { get; set; } 

        

    }
}