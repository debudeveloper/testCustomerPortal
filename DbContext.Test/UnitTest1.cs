using System;
using DynamoDbContext.Controllers;
using DynamoDbContext.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbContext.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ITest _service = new DynamoDbContext.Models.Test();
            // Arrange
            var controller = new HomeController(_service);
            
            // Act
            var response = controller.Test2(2);

            // Assert     
            Assert.AreEqual(2,3);

        }
    }
}
