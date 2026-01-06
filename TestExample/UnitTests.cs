using EksamensSkabelon;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestExample
{
    [TestClass]
    public sealed class UnitTests
    {
        [TestMethod]
        public void TestClass1Properties()
        {
            // Arrange
            var classInstance = new Class1("TestName", "TestDescription");
            // Act
            var name = classInstance.Prop1;
            var description = classInstance.Prop2;
            // Assert
            Assert.AreEqual("TestName", name);
            Assert.AreEqual("TestDescription", description);
        }
    }
}
