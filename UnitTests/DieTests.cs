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
            Assert.AreEqual(testDie.GetFaceTotal(1), 1);
        }
    }
}
