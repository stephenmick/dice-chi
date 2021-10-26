using Dice;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DieTests
    {
        [TestMethod]
        public void AddRollTestSimple()
        {
            // arrange
            int numSides = 20;
            Die testDie = new Die(numSides);

            // act
            testDie.AddRoll(1);

            //assert
            Assert.AreEqual(1, testDie.GetFaceTotal(1));
        }

        [DataTestMethod]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(3)]
        public void GetFaceTotalOutOfRange(int inputFace)
        {
            // arrange
            int face = inputFace;
            Die die = new Die(2);  // create a die with an input # faces, 2 would be a coin

            // act
            int faceTotal = die.GetFaceTotal(face);

            // assert
            Assert.AreEqual(-1, faceTotal);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(3)]
        public void GetFaceTotalInRangeEdgeCases(int inputFace)
        {
            // arrange
            int face = inputFace;
            Die die = new Die(3);

            // act
            int faceTotal = die.GetFaceTotal(face);

            // assert
            Assert.AreEqual(0, faceTotal);
        }

        [DataTestMethod]
        [DataRow(4, 1)]
        [DataRow(12, 11)]
        [DataRow(20, 10)]
        // when the # sides is greater than the # rolls then ChiSquared should return 0
        public void ChiSquaredSampleSizeTooSmall(int inputSides, int numRolls)
        {
            // arrange
            Die die = new Die(inputSides);
            for (int i = 0; i < numRolls; i++)
            {
                die.AddRoll(inputSides - 0);
            }

            // act
            double chiSquared = die.ChiSquared(inputSides);

            // assert
            Assert.AreEqual(-1, chiSquared);
        }

        [DataTestMethod]
        [DataRow(4, 10)]
        [DataRow(12, 5)]
        [DataRow(20, 100)]
        [DataRow(100, 3000)]
        public void ChiSquaredMaximumExpected(int inputSides, int expected)
        {
            // arrange
            Die die = new Die(inputSides);
            int totalRolls = inputSides * expected;
            for (int i=0; i < totalRolls; i++)
            {
                die.AddRoll(inputSides);
            }

            // act
            double chiSquared = die.ChiSquared(1);

            // assert
            Assert.AreEqual(expected, chiSquared);
        }

        [DataTestMethod]
        [DataRow(4, 5, 20, 0)]
        [DataRow(12, 2, 60, 1.8 )]
        [DataRow(20, 4, 100, 0.2)]
        [DataRow(20, 6, 100, 0.2)]
        [DataRow(20, 15, 100, 20)]

        public void ChiSquaredHappyCalculations(int inputSides, int rollCount, int rollTotal, double expected)
        {
            // arrange
            Die die = new Die(inputSides);
            for (int i = 0; i < rollCount; i++)
            {
                die.AddRoll(inputSides);
            }
            for (int i = 0; i < (rollTotal - rollCount); i++)
            {
                die.AddRoll(1);
            }

            // act
            double chiSquared = die.ChiSquared(inputSides);

            // assert
            Assert.AreEqual(expected, chiSquared);
        }

        [DataTestMethod]
        [DataRow(6)]
        [DataRow(12)]
        [DataRow(20)]
        public void TotalChiSquaredHappiestPath(int inputFace)
        {
            // arrange
            Die die = new Die(inputFace);  // create a dice with the input number of faces
            for (int i = 1; i <= inputFace; i++)
            {
                // add 5 rolls for each side
                for (int j = 0; j < 5; j++)
                {
                    die.AddRoll(i); 
                }
            }
            // act
            double totalChiSquared = die.TotalChiSquared();

            // assert
            Assert.AreEqual(0, totalChiSquared);
        }

        [TestMethod]
        public void TotalChiSquaredSampleSizeTooSmall()
        {

            // arrange
            Die die = new Die(20);

            // act
            double totalChiSquared = die.TotalChiSquared();

            // assert
            Assert.AreEqual(-1, totalChiSquared);
        }

    }
}
