using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDD.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void AddPositiveNumbers()
        {
            //start first from unit test
            int firstNumber = 5;
            int seconfNumber = 6;
            Calculator calc = new Calculator();
            int sum = calc.Sum(firstNumber, seconfNumber);
            Assert.AreEqual(11, sum);
        }
        [TestMethod]
        public void AddNigativeNumbers()
        {
            //start first from unit test
            int firstNumber = -5;
            int seconfNumber = -6;
            Calculator calc = new Calculator();
            int sum = calc.Sum(firstNumber, seconfNumber);
            Assert.AreEqual(-11, sum);
        }
    }
}
