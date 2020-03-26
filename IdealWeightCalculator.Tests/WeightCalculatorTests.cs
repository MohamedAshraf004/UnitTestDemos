using IdealWeight;
using IdealWeight.Tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IdealWeightCalculator.Tests
{
    [TestClass]
    public class WeightCalculatorTests
    {
        [TestMethod]
        public void GetIdealBodyWeight_Gender_M_And_Height_180_return_72_5()
        {
            //Arrange
            WeightCalculator sut = new WeightCalculator { Gender = 'm', Height = 180 };

            //Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 72.5;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetIdealBodyWeight_Gender_W_And_Height_180_return_72_5()
        {
            //Arrange
            WeightCalculator sut = new WeightCalculator { Gender = 'm', Height = 180 };

            //Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 65;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetIdealBodyWeight_Gender_B_And_Height_180_return_0()
        {
            //Arrange
            WeightCalculator sut = new WeightCalculator { Gender = 'b', Height = 180 };

            //Act
            double actual = sut.GetIdealBodyWeight();
            double expected = 0;
            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetIdealBodyWeightFromDataSource_WithGoodinputs_Returns_Correct_Results()
        {
            WeightCalculator weightCalculator = new WeightCalculator(new FakeWeightRepository());
            List<double> actual = weightCalculator.GetIdealBodyWeightFromDataSource();
            double[] expected = { 62.5, 62.75, 74 };
            CollectionAssertion.AreEqual(expected, actual);
        }
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void GetIdealBodyWeightFromDataSource_Using_Moq()
        {
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
                 new WeightCalculator(){Height=175,Gender='m'},
                new WeightCalculator(){Height=172,Gender='m'},
                new WeightCalculator(){Height=175,Gender='w'}
            };
            mock<IDataRepository> repo = new mock<IDataRepository>();
            repo.Setup(w => w.GetWeights()).Returns(weights);
            WeightCalculator weightCalculator = new WeightCalculator(repo.Object);
            var actual = weightCalculator.GetIdealBodyWeightFromDataSource();
            double[] expected = { 62.5, 62.75 };
            actual.Should().Equal(expected);
        }
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
        public void GetIdealBodyWeightFromDataSource_Using_FakeItEasy()
        {
            List<WeightCalculator> weights = new List<WeightCalculator>()
            {
                 new WeightCalculator(){Height=175,Gender='m'},
                new WeightCalculator(){Height=172,Gender='m'},
                new WeightCalculator(){Height=175,Gender='w'}
            };
            var repo = new A.fake<IDataRepository>();
            //repo.Setup(w => w.GetWeights()).Returns(weights);
            A.CallTo(() => repo.getWeight()).returns(weights);
            WeightCalculator weightCalculator = new WeightCalculator(repo);
            var actual = weightCalculator.GetIdealBodyWeightFromDataSource();
            double[] expected = { 62.5, 62.75 };
            actual.Should().Equal(expected);
        }
    }
}
