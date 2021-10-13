using System;
using System.Collections.Generic;
using System.Text;

namespace Dice
{
    public class Die
    {      

        private int[] FaceTotal { get; }
        private int RollTally { get; set; }
        public int NumberOfSides { get; }

        public Die(int sides)
        {
            FaceTotal = new int[sides + 1];
            NumberOfSides = sides;
        }

        /// <summary>
        /// Adds one to the FaceTotal for the input die face
        /// </summary>
        /// <param name="face"></param>
        public void AddRoll(int face)
        {
            if (face > 0 && FaceTotal.Length >= face)
            {
                FaceTotal[face] = FaceTotal[face] + 1;
                RollTally = RollTally + 1;
            }
        }

        /// <summary>
        /// returns the total rolls for the input face 
        /// </summary>
        /// <param name="face"></param>
        /// <returns>total rolls for a face and -1 for an invalid input</returns>
        public int GetFaceTotal(int face)
        {
            int returnTotal = -1;
            if (face > 0 && FaceTotal.Length >= face)
            {
                returnTotal = FaceTotal[face];
            }
            return returnTotal;
        }

        public int GetRollTally()
        {
            return RollTally;
        }
        public int GetNumberOfSides()
        {
            return NumberOfSides;
        }

        public double ChiSquared(int side)
        {
            double faceChiSquared = -1;
            if (FaceTotal.Length >= side)
            {
                double expected = RollTally / NumberOfSides;
                faceChiSquared = Math.Pow((FaceTotal[side] - expected), 2) / expected;
            }
            return faceChiSquared;
        }

        public double TotalChiSquared()
        {
            double totalChi = 0;
            for (int i = 1; i <= NumberOfSides; i++)
            {
                totalChi = totalChi + ChiSquared(i);
            }
            return totalChi;
        }

        public double Average()
        {
            double total = 0;
            for (int i = 1; i <= NumberOfSides; i++)
            {
                total = total + FaceTotal[i] * i;
            }
            return total / RollTally;
        }

    }
}
