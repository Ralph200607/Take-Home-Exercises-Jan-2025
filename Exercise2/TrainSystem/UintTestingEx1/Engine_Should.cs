using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TrainSystem;

namespace UintTestingEx1
{
    public class Engine_Should
    {
        #region Successful tests

        [Fact]
        public void Create_A_Good_Engine()
        {
            //Given - Arrange
            string Model = "CP 8002"; 
            string SerialNumber = "12345"; 
            int Weight = 147000;
            int HorsePower = 4400;

            //When - Act
            Engine actual = new Engine("  CP 8002  ", "  12345  ", 147000, 4400); //added spaces to check for Trimming
            //Then - Assert
            actual.Model.Should().Be(Model);
            actual.SerialNumber.Should().Be(SerialNumber);
            actual.Weight.Should().Be(Weight);
            actual.HorsePower.Should().Be(HorsePower);
            actual.InService.Should().BeTrue();
        }

        [Fact]
        public void Display_Engine_Data_ToString()
        {
            //Given - Arrange
            string expectedEngineString = "CP 8002,12345,147000,4400,True";
            Engine actual = new Engine("CP 8002", "12345", 147000, 4400);
            //When - Act
            var actualEngineString = actual.ToString();
            //Then - Assert
            actualEngineString.Should().Be(expectedEngineString);
        }

        [Fact]
        public void Change_Engine_Weight()
        {
            //Given - Arrange
            int expectedEngineWeight = 148000;
            Engine actual = new Engine("CP 8002", "12345", 147000, 4400);
            actual.InService=false;

            //When - Act
            actual.Weight = 148000;

            //Then - Assert
            actual.Weight.Should().Be(expectedEngineWeight);
        }

        [Fact]
        public void Change_Engine_HorsePower()
        {
            //Given - Arrange
            int expectedEngineHorsePower = 4700;
            Engine actual = new Engine("CP 8002", "12345", 147000, 4400);
            actual.InService=false;

            //When - Act
            actual.HorsePower = 4700;

            //Then - Assert - using the FluentAssertions NuGet package
            actual.HorsePower.Should().Be(expectedEngineHorsePower);
        }
        #endregion

        #region Exception tests
        [Theory]
        [InlineData(null, "12345", 147000, 4400)]
        [InlineData("", "12345", 147000, 4400)]
        [InlineData("   ", "12345", 147000, 4400)]
        [InlineData("CP 8002", null, 147000, 4400)]
        [InlineData("CP 8002", "", 147000, 4400)]
        [InlineData("CP 8002", "  ", 147000, 4400)]
        public void Creating_Engine_Should_Throw_Missing_Data_Exception(string Model,
         string SerialNumber, int Weight, int HorsePower)
        {
            //Given - Arrange
            //When - Act
            Action action = () => new Engine(Model, SerialNumber, Weight, HorsePower);
            //Then - Assert
            action.Should().Throw<ArgumentNullException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-148000)]
        [InlineData(148110)]
        public void Change_OutofService_Engine_Weight_Should_Throw_Invalid_Data_Exception(int ChangeWeight)
        {
            //Given - Arrange
            Engine actual = new Engine("CP 8002", "12345", 147000, 4400);
            actual.InService = false;

            //When - Act

            Action action = () => actual.Weight = ChangeWeight;
            //Then - Assert

            action.Should().Throw<ArgumentException>();

        }
        [Fact]
        public void Change_InService_Engine_Weight_Should_Throw_Exception()
        {
            //Given - Arrange
            Engine actual = new Engine("CP 8002", "12345", 147000, 4400);
            int ChangeWeight = 148000;
            //When - Act

            Action action = () => actual.Weight = ChangeWeight;
            //Then - Assert

            action.Should().Throw<Exception>();

        }

        [Theory]
        [InlineData(0)]
        [InlineData(-4500)]
        [InlineData(4410)]
        [InlineData(2400)]
        [InlineData(6400)]
        public void Change_OutOfService_Engine_HorsePower_Should_Throw_Invalid_Data_Exception(int ChangeHorsePower)
        {
            //Given - Arrange
            Engine actual = new Engine("CP 8002", "12345", 147000, 4400);
            actual.InService = false;

            //When - Act

            Action action = () => actual.HorsePower = ChangeHorsePower;
            //Then - Assert
            action.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void Change_InService_Engine_HorsePower_Should_Throw_Exception()
        {
            //Given - Arrange
            int ChangeHorsePower = 4500;
            Engine actual = new Engine("CP 8002", "12345", 147000, 4400);

            //When - Act

            Action action = () => actual.HorsePower = ChangeHorsePower;
            //Then - Assert
            action.Should().Throw<Exception>();
        }
        #endregion
    }
}
