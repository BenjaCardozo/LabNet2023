using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Northwind.Data;
using Northwind.Data.Command;
using Northwind.Data.Query.Interface;
using Northwind.Util.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Northwind.Logic.Application.Tests
{
    [TestClass()]
    public class CategoriesLogicTests
    {
        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Add_Category_With_Error()
        {
            // Arrange
            var mockQuery = new Mock<CategoriesQuery>();
            mockQuery.Setup(x => x.LastID()).Throws(new Exception("Database error"));
            mockQuery.Setup(x => x.ExistID(It.IsAny<int>())).Returns(false);

            var mockCommand = new Mock<ABMGeneric<Categories>>();

            var category = new Categories() { CategoryName = "Category 1" };
            var service = new CategoriesLogic(mockCommand.Object, mockQuery.Object);

            // Act
            service.Add(category);

            // Assert
            // Expects an exception of type MyException to be thrown
        }

        [TestMethod]
        [ExpectedException(typeof(MyException))]
        public void Add_Category_With_Existing_ID()
        {
            // Arrange
            var mockQuery = new Mock<CategoriesQuery>();
            mockQuery.Setup(x => x.LastID()).Returns(2);
            mockQuery.Setup(x => x.ExistID(2)).Returns(true);

            var mockCommand = new Mock<ABMGeneric<Categories>>();

            var category = new Categories() { CategoryID = 2, CategoryName = "Category 1" };
            var service = new CategoriesLogic(mockCommand.Object, mockQuery.Object);

            // Act
            service.Add(category);

            // Assert
            // Expects an exception of type MyException to be thrown
        }


        [TestMethod]
        public void GetAllDevuelveMasdeunElemento()
        {
            var data = new List<Categories>
            {
                new Categories { CategoryName = "AAA" },
                new Categories { CategoryName = "BBB" },
                new Categories { CategoryName = "ZZZ" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Categories>>();
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Categories>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<NorthwindContext>();
            mockContext.Setup(c => c.Categories).Returns(mockSet.Object);

            var mockCommand = new Mock<ABMGeneric<Categories>>(mockContext.Object);
            var mockQuery = new Mock<CategoriesQuery>(mockContext.Object);

            var service = new CategoriesLogic(mockCommand.Object, mockQuery.Object);
            var blogs = service.GetAll();

            Assert.AreEqual(3, blogs.Count);
            Assert.AreEqual("AAA", blogs[0].CategoryName);
            Assert.AreEqual("BBB", blogs[1].CategoryName);
            Assert.AreEqual("ZZZ", blogs[2].CategoryName);
        }

    }
}