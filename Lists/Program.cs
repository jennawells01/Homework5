using System;
using System.Collections.Generic;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> FavoriteItems = new List<string>();
            string answer;
            do
            {
                Console.WriteLine("What is your favorite thing you want to add to the list?");
                answer = Console.ReadLine();
                FavoriteItems.Add(answer);

                Console.WriteLine("Do you have another favorite item you want to add?");
                answer = Console.ReadLine();

            } while (answer.ToLower()[0] == 'y');

            Console.WriteLine("\n1) from the top to the bottom.");
            foreach (string item in FavoriteItems)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n1)in reverse order.");
            for (int i = FavoriteItems.Count - 1; i >= 0; i--) 
            {
                Console.WriteLine(FavoriteItems[i]);
            }

            Console.WriteLine("\n1) every other entry in list.");
            for (int i = 0; i < FavoriteItems.Count; i+=2)
            {
                Console.WriteLine(FavoriteItems[i]);
            }
        }
    }
}
