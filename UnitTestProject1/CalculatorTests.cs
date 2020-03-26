using System;
using Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class CalculatorTests 
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        [Priority(1)]
        public void Divide_PositiveNumbers_ReturnPositiveQuotient()
        {
            //Arrange
            int numerator = 10;
            double denominator = 2;
            double actual=Calculator.Calculator.Divide(numerator, denominator);
            //Act
            int expected = 5;
            //Assert 
            Assert.AreEqual(expected, actual);
            TestContext.WriteLine(TestContext.FullyQualifiedTestClassName.ToString());
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }
        [TestCleanup]
        public void CleanUp()
        {
            TestContext.WriteLine(TestContext.CurrentTestOutcome.ToString());
        }
        [TestMethod]
        [Priority(1)]
        public void IsPositive_positiveNumber_ReturnTrue()
        {
            
            PrivateType p = new PrivateType(typeof(Calculator.Calculator));
            bool actual = (bool)p.InvokeStatic("IsPositive", 15);
            Assert.IsTrue(actual);

        }
        [TestMethod]
        [Priority(2)]
        public void IsNigative_NigativeNumber_ReturnTrue()
        {
            
            PrivateObject p = new PrivateObject(typeof(Calculator.Calculator));
            bool actual = (bool)p.Invoke("IsNigative", -15);
            Assert.IsTrue(actual);

        }
    }
}
