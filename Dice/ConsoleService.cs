using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dice
{
    public class ConsoleService
    {

        public string FilePath { get; set; }
        public int NumberOfDice { get; set;  }
        public int NumberOfSides { get; set; }

        public void ImportDataFile()
        {
            GetFilePath();
            GetNumberOfDice();
            GetNumberOfSides();
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

        private void GetNumberOfDice()
        {           
            string input;
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
                        isValidNumber = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number from 1 to 10.");
                }
            }            
        }

        private void GetNumberOfSides()
        {

            string input;
            bool isValidNumber = false;

            while (!isValidNumber)
            {
                Console.WriteLine("How many sides to each die?");
                input = Console.ReadLine();
                if (int.TryParse(input, out int number))
                {
                    if (number > 0)
                    {
                        NumberOfSides = number;
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
}
