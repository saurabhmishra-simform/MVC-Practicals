using Microsoft.AspNetCore.Mvc;
using Practical9Task3.Controllers;

namespace TestTask3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            //
        }

        [Test]
        public void Test1()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ContentResult? result = controller.Index() as ContentResult;

            Assert.That(result, Is.Not.Null);

            Assert.That(result.Content, Is.EqualTo("Hello World"));
        }
    }
}