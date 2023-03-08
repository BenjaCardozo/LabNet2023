using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Division.Service.Tests
{
    [TestClass()]
    public class OperarTests
    {
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DividirPorCero()
        {
            // Arranger
            double divisor = 0;

            // Act
            Operar.DividirPor(divisor);

        }
        [TestMethod()]
        public void DividirPorPositivo()
        {
            // Arrange
            double divisor = 2;
            double ResultadoEsperado = 500;

            // Act
            double resultadoObtenido = Operar.DividirPor(divisor);

            // Assert
            Assert.AreEqual(ResultadoEsperado, resultadoObtenido);
        }

        [TestMethod()]
        public void DividirPorNegativo()
        {
            // Arrange
            double divisor = -2;
            double ResultadoEsperado = -500;

            // Act
            double resultadoObtenido = Operar.DividirPor(divisor);

            // Assert
            Assert.AreEqual(ResultadoEsperado, resultadoObtenido);
        }

        [TestMethod()]
        public void DividirPorDecimal()
        {
            // Arrange
            double divisor = 0.5;
            double ResultadoEsperado = 2000;

            // Act
            double resultadoObtenido = Operar.DividirPor(divisor);

            // Assert
            Assert.AreEqual(ResultadoEsperado, resultadoObtenido);
        }


        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionPorCero()
        {
            // Arranger
            double dividendo = 10;
            double divisor = 0;

            // Act
            Operar.Division(dividendo, divisor);

        }
        [TestMethod()]
        public void DivisionPositiva()
        {
            // Arrange
            double dividendo = 10;
            double divisor = 2;
            double ResultadoEsperado = 5;

            // Act
            double resultadoObtenido = Operar.Division(dividendo, divisor);

            // Assert
            Assert.AreEqual(ResultadoEsperado, resultadoObtenido);
        }

        [TestMethod()]
        public void DivisionNegativa()
        {
            // Arrange
            double dividendo = 10;
            double divisor = -2;
            double ResultadoEsperado = -5;

            // Act
            double resultadoObtenido = Operar.Division(dividendo, divisor);

            // Assert
            Assert.AreEqual(ResultadoEsperado, resultadoObtenido);
        }

        [TestMethod()]
        public void DivisionPorDecimal()
        {
            // Arrange
            double dividendo = 10;
            double divisor = 0.5;
            double ResultadoEsperado = 20;

            // Act
            double resultadoObtenido = Operar.Division(dividendo, divisor);

            // Assert
            Assert.AreEqual(ResultadoEsperado, resultadoObtenido);
        }

    }
}