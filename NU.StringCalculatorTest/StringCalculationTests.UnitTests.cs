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
            //arrange
            string empty_string;
            //act

            empty_string = "";

            //assert
            Assert.AreEqual(_stringCalculator.Add(empty_string),0);
        }

        [TestMethod]
        public void When_A_String_Containing_A_Number_And_No_Delimiter_Is_Passed_Return_The_Number()
        {
            string no_delimiter;
            no_delimiter = "1";

            Assert.AreEqual(_stringCalculator.Add(no_delimiter), int.Parse(no_delimiter));
        }

        [DataTestMethod]
        [DataRow("Empty String: (\"\",0)", "", 0)]
        [DataRow("One number: ( \"1\", 1)", "1", 1)]
        [DataRow("Two numbers comma delimiter: (\"1,2\",3)", "1,2", 3)]
        [DataRow("Two numbers comma delimiter: (\"3,2\",5)", "3,2", 5)]
        [DataRow("Three numbers comma delimiter: (\"3,2,1\",6)", "3,2,1", 6)]
        [DataRow("Three numbers comma and newline delimiter: (\"3\n2,1\",6)", "3\n2,1", 6)]
        [DataRow("Four numbers comma delimiter: (\"3,2,1,4\",6)", "3,2,1,4", 10)]
        public void When_A_String_Is_Passed_Return_The_Sum_Of_The_Numbers(string parameters,string numbers,int sum)
        {
            Assert.AreEqual(_stringCalculator.Add(numbers),sum);
        }

        [TestMethod]
        public void When_A_String_Is_Passed_That_Contains_An_Invalid_Delimiter_Trow_An_Argument_Exception()
        {
            string numbers;
            numbers = "1,\n";
            var ex = Assert.ThrowsException<ArgumentException>(() => _stringCalculator.Add(numbers));
        }

        [TestMethod]
        public void When_Two_Integers_Are_Passed_Their_Sum_Is_Returned()
        {
            int number1;
            int number2;
            
            number1 = 2;
            number2 = 3;
            int total = 5;

            Assert.AreEqual(_stringCalculator.Add(number1,number2), total);
        }

    }
}
