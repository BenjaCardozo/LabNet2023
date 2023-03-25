using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Northwind.Data;
using Northwind.Data.Command;
using Northwind.Data.Command.Interface;
using Northwind.Data.Query.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Northwind.Logic.Application.Tests
{
    [TestClass()]
    public class CategoriesLogicTests
    {
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

            var mockCommand  = new Mock<ABMGeneric<Categories>>();
            var mockQuery = new Mock<CategoriesQuery>();

            var service = new CategoriesLogic(mockCommand.Object, mockQuery.Object);
            var blogs = service.GetAll();

            Assert.AreEqual(3, blogs.Count);
            Assert.AreEqual("AAA", blogs[0].CategoryName);
            Assert.AreEqual("BBB", blogs[1].CategoryName);
            Assert.AreEqual("ZZZ", blogs[2].CategoryName);
        }
    }
}