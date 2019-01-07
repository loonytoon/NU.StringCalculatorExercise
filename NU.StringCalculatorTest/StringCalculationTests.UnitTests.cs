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
        [DataRow("Four numbers comma delimiter: (\"3,2,1,4\",10)", "3,2,1,4", 10)]
        [DataRow("Four numbers comma delimiter one greater the 1000: (\"3,2,1001,4\",9)", "3,2,1001,4", 9)]
        public void When_A_String_Is_Passed_Return_The_Sum_Of_The_Numbers(string parameters,string numbers,int sum)
        {
            Assert.AreEqual(_stringCalculator.Add(numbers),sum);
        }

        [DataTestMethod]
        [DataRow("Four numbers comma delimiter one greater the 1000: (\"3,2,1001,4\",9)", "3,2,1001,4", 9)]
        [DataRow("Four numbers comma delimiter Two greater the 1000: (\"3,2002,1001,4\",7)", "3,2002,1001,4", 7)]
        public void When_A_String_Is_Passed_That_Contains_Number_Greater_Than_One_Thousand_Ignore_Numbers_Greater_Than_One_Thousand(string parameters, string numbers, int sum)
        {
            Assert.AreEqual(_stringCalculator.Add(numbers), sum);
        }

        [TestMethod]
        public void When_A_String_Is_Passed_That_Contains_A_New_Delimiter_Use_That_Delimiter()
        {
            string numbers;
            numbers = "//;\n1;2";
            Assert.AreEqual(_stringCalculator.Add(numbers), 3);
        }

        [TestMethod]
        public void When_A_String_Is_Passed_That_Contains_An_Invalid_Delimiter_Trow_An_Argument_Exception()
        {
            string numbers;
            numbers = "1,\n";
            var ex = Assert.ThrowsException<ArgumentException>(() => _stringCalculator.Add(numbers));
        }

        [DataTestMethod]
        [DataRow("Two numbers comma delimiter: (\"1,-2\")", "1,-2", "-2")]
        [DataRow("Three numbers comma delimiter two negatives: (\"1,-2,-4\")", "1,-2,-4", "-2,-4")]
        public void When_A_String_Is_Passed_That_Contains_A_Negative_Number_Throw_An_Exception(string parameters,
            string numbers, string expectedError)
        {
            String msg =$"negatives not allowed: {expectedError}";

            var ex = Assert.ThrowsException<Exception>(() => _stringCalculator.Add(numbers));
            Assert.AreEqual(ex.Message,msg);
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
