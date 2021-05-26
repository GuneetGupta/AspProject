using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookEvent.Data.Model;
using BookEvent.Console.Controllers;
using BookEvent.Data.Services;

namespace BookEvent.UnitTest
{
    [TestClass]
    public class HomeControllerTest
    {
        private readonly IBookData db;
        [TestMethod]
        public void Contact()
        {
            //Arrange
            HomeController controller = new HomeController(db);

            //Act
            ViewResult result = controller.Contact() as ViewResult;

            //Assert
            //Assert.AreEqual("Your contact page.", result.ViewBag.Message);
        }

    }
}
