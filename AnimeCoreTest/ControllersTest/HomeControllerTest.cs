using AnimeCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace AnimeCoreTest.ControllersTest
{
    public class HomeControllerTest
    {
        [Fact]
        public void Error()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Error() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index()
        {
            //Arrange
            var homeController = new HomeController();

            //Act
            var result = homeController.Index() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }
    }
}