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
        [DataRow(2)]
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

    }
}
