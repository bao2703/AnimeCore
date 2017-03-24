using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AnimeCore.Common;
using AnimeCore.Controllers;
using Entities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.AccountViewModels;
using Moq;
using Services;
using Xunit;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace AnimeCoreTest.ControllersTest
{
    public class AccountControllerTest
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData("/Home", "/Home")]
        public void Register_ReturnUrl(string expectedUrl, string returnUrl)
        {
            //Arrange
            var accountController = new AccountController(null);

            //Act
            var result = accountController.Register(returnUrl) as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedUrl, result.ViewData[Constant.ReturnUrl]);
        }

        [Fact]
        public void Login_IsSignedIn_False()
        {
            //Arrange
            var mockUserService = new Mock<IAccountService>();
            mockUserService.Setup(m => m.IsSignedIn(It.IsAny<ClaimsPrincipal>())).Returns(false);
            var accountController = new AccountController(mockUserService.Object);

            //Act
            var result = accountController.Login() as ViewResult;

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Login_IsSignedIn_True()
        {
            //Arrange
            var mockUrlHelper = new Mock<IUrlHelper>();
            mockUrlHelper.Setup(m => m.IsLocalUrl(It.IsAny<string>())).Returns(false);

            var mockUserService = new Mock<IAccountService>();
            mockUserService.Setup(m => m.IsSignedIn(It.IsAny<ClaimsPrincipal>())).Returns(true);

            var accountController = new AccountController(mockUserService.Object) {Url = mockUrlHelper.Object};

            //Act
            var result = accountController.Login() as RedirectToActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public async Task Login_ModelState_NotValid()
        {
            //Arrange
            var accountController = new AccountController(null);
            accountController.ModelState.AddModelError(string.Empty, "ErrorMessage");

            //Act
            var result = await accountController.Login(new LoginViewModel()) as ViewResult;

            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.IsType(typeof(LoginViewModel), result.Model);
            Assert.True(
                result.ViewData.ModelState[string.Empty].Errors.Any(
                    modelError => modelError.ErrorMessage == "ErrorMessage"));
        }

        [Fact]
        public async Task Login_PasswordSignInAsync_Failed()
        {
            //Arrange
            var mockUserService = new Mock<IAccountService>();
            mockUserService.Setup(
                    m =>
                        m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(SignInResult.Failed));

            var accountController = new AccountController(mockUserService.Object);

            //Act
            var result = await accountController.Login(new LoginViewModel()) as ViewResult;

            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.IsType(typeof(LoginViewModel), result.Model);
            Assert.True(
                result.ViewData.ModelState[string.Empty].Errors.Any(
                    modelError => modelError.ErrorMessage == "Invalid login attempt."));
        }

        [Fact]
        public async Task Login_PasswordSignInAsync_Succeeded()
        {
            //Arrange
            var mockUrlHelper = new Mock<IUrlHelper>();
            mockUrlHelper.Setup(m => m.IsLocalUrl(It.IsAny<string>())).Returns(false);

            var mockUserService = new Mock<IAccountService>();
            mockUserService.Setup(m =>
                    m.PasswordSignInAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<bool>(), It.IsAny<bool>()))
                .Returns(Task.FromResult(SignInResult.Success));

            var accountController = new AccountController(mockUserService.Object) {Url = mockUrlHelper.Object};

            //Act
            var result = await accountController.Login(new LoginViewModel()) as RedirectToActionResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public async Task LogOff()
        {
            //Arrange
            var mockUserService = new Mock<IAccountService>();
            var accountController = new AccountController(mockUserService.Object);

            //Act
            var result = await accountController.LogOff() as RedirectToActionResult;

            //Assert
            mockUserService.Verify(m => m.SignOutAsync(), Times.Once);
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public async Task Register_CreateAsync_Failed()
        {
            //Arrange
            var mockUserService = new Mock<IAccountService>();
            mockUserService.Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Failed(new IdentityError {Description = "ErrorMessage"})));

            var accountController = new AccountController(mockUserService.Object);

            //Act
            var result = await accountController.Register(new RegisterViewModel()) as ViewResult;


            //Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.IsType(typeof(RegisterViewModel), result.Model);
            Assert.True(
                result.ViewData.ModelState[string.Empty].Errors.Any(
                    modelError => modelError.ErrorMessage == "ErrorMessage"));
        }

        [Fact]
        public async Task Register_CreateAsync_Succeeded()
        {
            //Arrange
            var mockUrlHelper = new Mock<IUrlHelper>();
            mockUrlHelper.Setup(m => m.IsLocalUrl(It.IsAny<string>())).Returns(false);

            var mockUserService = new Mock<IAccountService>();
            mockUserService.Setup(m => m.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            var accountController = new AccountController(mockUserService.Object) {Url = mockUrlHelper.Object};

            //Act
            var result = await accountController.Register(new RegisterViewModel()) as RedirectToActionResult;

            //Assert
            mockUserService.Verify(
                m => m.SignInAsync(It.IsAny<User>(), It.IsAny<bool>(), It.IsAny<string>()), Times.Once);
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal("Home", result.ControllerName);
        }

        [Fact]
        public async Task Register_ModelState_NotValid()
        {
            //Arrange
            var accountController = new AccountController(null);
            accountController.ModelState.AddModelError(string.Empty, "ErrorMessage");

            //Act
            var result = await accountController.Register(new RegisterViewModel()) as ViewResult;

            Assert.NotNull(result);
            Assert.NotNull(result.Model);
            Assert.IsType(typeof(RegisterViewModel), result.Model);
            Assert.True(
                result.ViewData.ModelState[string.Empty].Errors.Any(
                    modelError => modelError.ErrorMessage == "ErrorMessage"));
        }
    }
}