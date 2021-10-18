using System;
using System.Collections.Generic;

namespace Dice
{
    public class Program
    {
        static void Main()
        {
            ConsoleService cs = new ConsoleService();
            cs.ImportDataFile();

            System.IO.StreamReader file = new System.IO.StreamReader(cs.FilePath);
            string line;

            // create a Die bucket to hold each set of die results
            Die[] dice = new Die[cs.NumberOfDice];
            for (int i = 0; i < dice.Length; i++)
            {
                Die die = new Die(cs.NumberOfSides);
                dice[i] = die;
            }

            try
            {
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    string[] data = line.Split(' ');
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (int.TryParse(data[i], out int number))
                        {
                            dice[i].AddRoll(number);
                        }
                    }
                }
                file.Close();
            }
            catch (Exception e)
            {
                throw e;
            }

            cs.PrintResults(dice);

            //for (int i = 0; i < dice.Length; i++)
            //{
            //    int sides = dice[i].GetNumberOfSides();
            //    for (int j = 1; j <= sides; j++)
            //    {
            //        double chiSquared = dice[i].ChiSquared(j);
            //        int faceTotal = dice[i].GetFaceTotal(j);
            //        Console.WriteLine(j + " total: " + faceTotal + " chi squared: " + chiSquared);
            //    }
            //    Console.WriteLine("Total Chi Squared: " + dice[i].TotalChiSquared());
            //    Console.WriteLine("Average: " + dice[i].Average());
            //    Console.WriteLine();
            //}       

            // Suspend the screen  
            Console.ReadLine();

        }
    }
}
