using System;
using System.Collections.Generic;

namespace Dice
{
    public class Program
    {
        static void Main()
        {
            
            // display console prompts to initialize dice data input from txt file
            ConsoleService cs = new ConsoleService();
            cs.ImportDataFile();
            
            // create a Die array to hold each set of die results
            Die[] diceData = cs.PopulateDiceData();

            // calculate and display dice stats
            cs.PrintResults(diceData);   

            // Suspend the screen  
            Console.ReadLine();

        }
    }
}
