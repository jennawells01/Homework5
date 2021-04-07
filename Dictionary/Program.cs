using System;
using System.Collections.Generic;
using System.IO;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sentences = File.ReadAllLines("Jane Eyre.txt");

            Dictionary <string, int> wordCount = new Dictionary <string, int>();
            bool foundBegOfBook = false;

            foreach (string line in sentences)
            {
                if (foundBegOfBook == false && 
                   string.IsNullOrWhiteSpace(line) == true)
                {
                    continue; //ignore it
                }                 
               if (line.Contains("CHAPTER I") == true)
                {
                    foundBegOfBook = true;
                }
                if (line.Contains("***END OF THE PROJECT GUTENBERG EBOOK JANE EYRE***") == true)
                {
                    break; //we are done "get outta here"
                }
                string[] words = line.Split(" ");//on spaces
                foreach (string word in words)
                {
                    char[] punctuation = { ',' , '\'' , ',', '.', '!', '?',':',';','"'}; //getting rid of all these at end of line
                    string current = word.ToLower().Trim(punctuation);
                    if (wordCount.ContainsKey(current) == false)
                    {
                        wordCount.Add(current, 0); //first time coming across word
                    }
                    wordCount[current] = wordCount[current] + 1; //changing 0 to 1
                }
            }
            Console.WriteLine("\n\t\tJane Eyre Dictionary");
            Console.WriteLine($"{"Word".PadRight(25,' ')}\tCount");//take string and make it 25 characters. if not 25 add as many characters until at 25
            foreach (string word in wordCount.Keys)
            {
                Console.WriteLine($"{word.PadRight(25, ' ')}\t{wordCount[word].ToString("N0")}.");
            }
            Console.WriteLine("Do you want to search for a sepcific word? Yes or no?  ");
            string answer = Console.ReadLine();
            if (answer.ToLower()[0] == 'y')
            {
                Console.WriteLine("What word do you want to see the count of? ");
                answer = Console.ReadLine().ToLower();
                if (wordCount.ContainsKey(answer) == true)
                {
                    Console.WriteLine($"{answer} was found {wordCount[answer].ToString("N0")} times!");
                }
                else
                {
                    Console.WriteLine($"Sorry, '{answer}' is not in book. Goodbye!");
                }
            }

        }
    }
}
