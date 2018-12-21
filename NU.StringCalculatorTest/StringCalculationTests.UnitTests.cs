using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NU.StringCalculatorExercise;

namespace NU.StringCalculatorTests
{
    [TestClass]
    public class StringCalculationUnitTests
    {
        private StringCalculator _stringCalculator;
        [TestInitialize]
        public void TestInitialize()
        {
            _stringCalculator = new StringCalculator();
        }
        [TestMethod]
        public void When_An_Empty_String_Is_Passed_Return_Zero()
        {
            string empty_string = "";

            Assert.AreEqual(_stringCalculator.Add(empty_string),0);
        }
    }
}
