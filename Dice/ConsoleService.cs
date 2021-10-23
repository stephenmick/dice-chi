using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dice
{
    public class ConsoleService
    {

        public string FilePath { get; set; }
        public int NumberOfDice { get; set; }
        public int[] NumberOfSides { get; set; }

        public void ImportDataFile()
        {
            GetFilePath();
            int num = GetNumberOfDice();
            GetNumberOfSides(num);
        }

        public void GetFilePath()
        {
            string filePath = "";
            bool isValidFile = false;
            // loop until a valid file is given
            while (!isValidFile)
            {
                Console.WriteLine("Please enter the file path for dice rolls: ");
                filePath = Console.ReadLine();
                isValidFile = File.Exists(filePath);
                if (!isValidFile)
                {
                    Console.WriteLine("Sorry that file path does not exist.");
                }
            }
            FilePath = filePath;
        }

        private int GetNumberOfDice()
        {
            string input;
            int returnNumber = 0;
            bool isValidNumber = false;

            while (!isValidNumber)
            {
                Console.WriteLine("How many dice rolls on each line?");
                input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    if (number > 0 && number <= 10)
                    {
                        NumberOfDice = number;
                        returnNumber = number;
                        isValidNumber = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number from 1 to 10.");
                }
            }

            return returnNumber;
        }

        private void GetNumberOfSides(int numDice)
        {

            string input;
            NumberOfSides = new int[numDice];

            for (int i = 0; i < numDice; i++)
            {
                bool isValidNumber = false;
                while (!isValidNumber)
                {
                    Console.WriteLine("How many sides does die #" + i + " have?");
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int number))
                    {
                        if (number > 0)
                        {
                            NumberOfSides[i] = number;
                            isValidNumber = true;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Please enter an integer greater than 0.");
                    }
                }
            }
        }

        public void PrintResults(Die[] inputDice)
        {
            Die[] dice = inputDice;
            for (int i = 0; i < dice.Length; i++)
            {
                int sides = dice[i].GetNumberOfSides();
                for (int j = 1; j <= sides; j++)
                {
                    double chiSquared = dice[i].ChiSquared(j);
                    int faceTotal = dice[i].GetFaceTotal(j);
                    Console.WriteLine(j + " total: " + faceTotal + " chi squared: " + chiSquared);
                }
                Console.WriteLine("Total Chi Squared: " + dice[i].TotalChiSquared());
                Console.WriteLine("Average of all rolls: " + dice[i].Average());
                Console.WriteLine();
            }
        }

        public Die[] PopulateDiceData()
        {
            // create a Die bucket to hold each set of die results
            Die[] dice = new Die[NumberOfDice];

            StreamReader file = new StreamReader(FilePath);
            string line;

            for (int i = 0; i < dice.Length; i++)
            {
                Die die = new Die(NumberOfSides[i]);
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
            return dice;
        }

        public void PrintResults(Die[] inputDice)
        {
            Die[] dice = inputDice;
            for (int i = 0; i < dice.Length; i++)
            {
                int sides = dice[i].GetNumberOfSides();
                for (int j = 1; j <= sides; j++)
                {
                    double chiSquared = dice[i].ChiSquared(j);
                    int faceTotal = dice[i].GetFaceTotal(j);
                    Console.WriteLine(j + " total: " + faceTotal + " chi squared: " + chiSquared);
                }
                Console.WriteLine("Total Chi Squared: " + dice[i].TotalChiSquared());
                Console.WriteLine("Average of all rolls: " + dice[i].Average());
                Console.WriteLine();
            }
        }

        public Die[] PopulateDiceData()
        {
            // create a Die bucket to hold each set of die results
            Die[] dice = new Die[NumberOfDice];

            StreamReader file = new System.IO.StreamReader(FilePath);
            string line;

            for (int i = 0; i < dice.Length; i++)
            {
                Die die = new Die(NumberOfSides);
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
            return dice;
        }
    }
}
