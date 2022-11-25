using System;
using System.Collections.Generic;
using System.Globalization;
using Library.Models ;


namespace Library.Models
{
    
    public class BookWordsRepository
    {
        public List<Book> Books { get; set; }


       

        public BookWordsRepository()
        {
            WordDictionary = new Dictionary<string, int>();
            List<WordCount> wordCount = new List<WordCount>();

        }
        // Create a dictionary to hold the words and their counts
        public Dictionary<string, int> WordDictionary { get; set; }

        // make Add a void dictionary
        


        public Dictionary<string, int> Add(string text){
            // Add words parsed from the given text into this repository
            // Take in a string of text and split it into a dictionary of words
            // The dictionary should be in the form of <string, int> where the string is the word and the int is the number of times it appears in the text

            // Split the text into words
            string[] words = text.Split(' ');
            
            // create a newDictionary to hold the words and their counts
            Dictionary<string, int> newDictionary = new Dictionary<string, int>();

            
            // Loop through the words
            foreach (string word in words)
            {

                // Trim the word of any punctuation
                string searchWord = new string(word.Where(c => !char.IsPunctuation(c)).ToArray()).Trim();

                // If the word is already in the dictionary, increment the value count
                if (newDictionary.ContainsKey(searchWord.ToLower()))
                {

                    var item = newDictionary.FirstOrDefault(x => x.Key == searchWord);
                    newDictionary[searchWord] = item.Value + 1;
                    
                }
                else
                {
                    // If the word is not in the dictionary, add it with a count of 1
                    newDictionary.Add(searchWord.ToLower(), 1);
                }
                
            }
            
           return newDictionary;
            
        }
        

        // Return the number of appearances of a specified word in this book
        public int GetCount(string word)
        {
           
            int totalCount = 0;
            
            // For words larger then 3, in a dictionary of words, return the count of the word chosen
            if (WordDictionary.ContainsKey(word.ToLower()) && word.Length >= 3)
            {
                // take the word and make it lowercase
                totalCount = WordDictionary[word.ToLower()];
            }
            return totalCount;
        }
            
            
            

        // Return a list of words which start with the specified prefix in this book
        public List<WordCount> Search(string query)
        {
            

            // Create a list to store the words
            List<WordCount> wordList = new List<WordCount>();

            // Use LINQ to search the dictionary for words that start with the query
        
            var queryResults =from word in WordDictionary
                               where word.Key.StartsWith(query.ToLower())
                               select word;

            // Loop through the words that start with the query
            
            foreach (var w in queryResults)
            {
                if (w.Key.Length >= 3)
                {
                    // Convert string to proper case in w.Key
                    string properCaseWord = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(w.Key);

                    // Add the words to the list, with Capital letter at the beginning
                    wordList.Add(new WordCount(properCaseWord, w.Value));
                // else if w.key is less than 3, do not add it to the list
                }else
                {
                    continue;
                }

                


            }
            // Return the list of words 
            
            return wordList;


            
        }

        // Return the top-10 most common words in this book, along with their counts, in descending order of appearance.
        
        public List<WordCount> MostCommonWords()
        {
            // Create a list to store the words
            var queryResults = from word in WordDictionary
                               where word.Key.Length >= 5
                               orderby word.Value descending
                               select word;
            
            
            // Take the top 10 words out of the sorted list 
            var top10 = queryResults.Take(10);
            

            // Create a list to store the words
            List<WordCount> tenList = new List<WordCount>();
            
            // Loop through the top 10 words
            foreach (var w in top10)
            {
                // Convert string to proper case in w.Key
                string properCaseWord = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(w.Key);

                // Add the words to the list, with Capital letter at the beginning
                tenList.Add(new WordCount(properCaseWord, w.Value));
            }
            
            // Return the list of words
            return tenList;
           

            

        }
        

    }
}