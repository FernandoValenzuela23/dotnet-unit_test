/* 
        Install-Package Moq  
 */


using BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;

namespace UnitTests
{
    [TestClass]
    public class MathTesting
    {
        private readonly MathCalculation _mathCalculation;

        public MathTesting()
        {
            _mathCalculation = new MathCalculation();

        }

        [TestMethod]
        public void Substracting_12_8()
        {
            int expected = 4;
            var result = _mathCalculation.Substract(12, 8);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Multipling_3_2()
        {
            int expected = 6;
            var result = _mathCalculation.Multiply(3, 2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Dividing_by_cero()
        {
            
            Assert.ThrowsException<Exception>(() => _mathCalculation.Divide(34, 0));

        }

        [TestMethod]
        public void Dividing_100_20()
        {
            int expected = 5;
            var result = _mathCalculation.Divide(100, 20);

            Assert.AreEqual(expected, result);
        }
    }
}