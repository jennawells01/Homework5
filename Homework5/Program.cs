using System;
using System.IO;

namespace Homework5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] customerNames = new string[1000]; //-1 because first line is title
            double[] accountBalances = new double[1000];

            string[] nameLines = File.ReadAllLines("CustomerNames.csv"); //reading in file
            string[] balanceLines = File.ReadAllLines("AccountBalances.csv");

            for (int i = 1; i < nameLines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(nameLines[i]) == true) //there is a blank at the end
                {
                    continue; //start over at for and re-read
                }

                customerNames[i - 1] = nameLines[i]; //why i-1 if i=1

                string balance = balanceLines[i];
                balance = balance.Replace("$", "");//how do u use trim? also this is getting rid of $
                accountBalances[i - 1] = Convert.ToDouble(balance);
            }
                Console.Write("Whose account do you want to look up?  ");
                foreach (string name in customerNames)
                {
                    Console.WriteLine(name);
                }
                string answer = Console.ReadLine();
                 Console.WriteLine();
                for (int i = 0; i < customerNames.Length; i++)
                {
                    if (answer.ToLower() == customerNames[i].ToLower())
                    {
                        Console.WriteLine($"{answer} has an account balance of {accountBalances[i].ToString("C")}.");
                    }
                }         
        }
    }
}
 