using Microsoft.VisualStudio.TestTools.UnitTesting;
using Division.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Division.Excepciones;

namespace Division.Service.Tests
{
    [TestClass()]
    public class LogicTests
    {
        [TestMethod()]
        [ExpectedException(typeof(InvalidProgramException))]
        public void MetodoConExcepcionElejida()
        {
            // Act
            Logic.MetodoConExcepcion(true);
        }

        [TestMethod()]
        [ExpectedException(typeof(BenjaExcepcion))]
        public void MetodoConExcepcionPersonalizada()
        {
            // Act
            Logic.MetodoConExcepcion(false);
        }
    }
}