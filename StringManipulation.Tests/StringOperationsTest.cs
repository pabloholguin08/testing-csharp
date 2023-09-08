using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace StringManipulation.Tests
{
    public class StringOperationsTest
    {
        //[Fact(Skip = "Esta prueba no es valida en estos momentos, TICKET-001")]
        [Fact]
        public void ConcatenateStrings()
        {
            //Arrange
            //datos de prueba, variables, etc
            var strOperations = new StringOperations();

            //Act
            //ejecución de la prueba y variable para guardar resultado
            var result = strOperations.ConcatenateStrings("Hello", "Platzi");

            //Assert
            //Comprobación del resultado
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("Hello Platzi", result);
        }

        [Fact]
        public void IsPalindrome_True()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.IsPalindrome("ama");

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPalindrome_False()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.IsPalindrome("hello");

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void RemoveWhitespace()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.RemoveWhitespace("Miguel Teheran  .");

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("MiguelTeheran.", result);
        }

        [Fact]
        public void QuantintyInWords()
        {
            //Arrange
            var strOperations = new StringOperations();

            //Act
            var result = strOperations.QuantintyInWords("cat",10);

            //Assert
            Assert.StartsWith("diez", result);
            Assert.Contains("cat", result);
        }

        [Fact]
        public void GetStringLength()
        {
            var strOperations = new StringOperations();

            var result = strOperations.GetStringLength("Platzi");

            Assert.True(result > 0);
        }

        [Fact]
        public void GetStringLength_Exeption()
        {
            //Arrange
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentNullException>(() => strOperations.GetStringLength(null));
        }

        [Fact]
        public void TruncateString_Exception()
        {
            var strOperations = new StringOperations();

            Assert.ThrowsAny<ArgumentOutOfRangeException>(() => strOperations.TruncateString("Platzi", -2));
        }

        [Theory]
        [InlineData("V",5)]
        [InlineData("III",3)]
        [InlineData("X",10)]
        public void FromRomanToNumber(string romanNumber, int expected)
        {
            var strOperations = new StringOperations();

            var result = strOperations.FromRomanToNumber(romanNumber);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void CountOccurrences()
        {
            var mockLogger = new Mock<ILogger<StringOperations>>();
            var strOperations = new StringOperations(mockLogger.Object);
            
            var result = strOperations.CountOccurrences("Hello Platzi", 'l');

            Assert.Equal(3, result);
        }

        [Fact]
        public void ReadFile()
        {
            var strOperations = new StringOperations();
            var mockFileReader = new Mock<IFileReaderConector>();
            mockFileReader.Setup(p => p.ReadString(It.IsAny<string>())).Returns("Reading File");

            var result = strOperations.ReadFile(mockFileReader.Object, "file.txt");

            Assert.Equal("Reading File", result);
        }

        [Fact]
        public void ReverseString()
        {
            var strOperations = new StringOperations();

            var result = strOperations.ReverseString("Hello").ToLower();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Equal("olleh", result);
        }

        [Fact]
        public void Pluralize()
        {
            var strOperations = new StringOperations();

            var result = strOperations.Pluralize("carro");

            Assert.Equal("carros", result);
        }
    }
}
