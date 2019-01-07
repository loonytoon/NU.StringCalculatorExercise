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

        [TestMethod]
        public void When_A_String_Containing_A_Number_And_No_Delimiter_Is_Passed_Return_The_Number()
        {
            string no_delimiter = "1";

            Assert.AreEqual(_stringCalculator.Add(no_delimiter), int.Parse(no_delimiter));
        }

        [TestMethod]
        public void When_Two_Integers_Are_Passed_Their_Sum_Is_Return()
        {
            int number1 = 2;
            int number2 = 3;
            int total = 5;
            Assert.AreEqual(_stringCalculator.Add(number1,number2), total);
        }
    }
}
