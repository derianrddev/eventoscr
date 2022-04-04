using BZPAY_BE.BussinessLogic.auth.ServiceInterface;
using BZPAY_BE.Controllers;
using BZPAY_BE.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BZPAY_BE.UnitTests.AspnetUserTests
{
    /// <summary>
    /// AspnetUser controller unit tests
    /// </summary>
    public class AspnetUserControllerTest
    {
        #region Fields
        private readonly Mock<IAspnetUserService> _serviceMock;
        private readonly AspnetUserController _controller;
        #endregion

        #region Constructor
        public AspnetUserControllerTest()
        {
            _serviceMock = new Mock<IAspnetUserService>();
            _controller = new AspnetUserController(_serviceMock.Object);
        }
        #endregion

        #region Public Methods    


        [Fact]
        /// <summary>
        /// StartSession Success
        /// </summary>
        public async Task Controller_ShouldReturnSuccess_WhenStartSession()
        {
            // Arrange
            var fakeRequest = new LoginRequest() { Username = "PLK_TEST", Password = "RtEmMLgq" };
            AspnetUserDo fakeResponse = GetFakeAspnetUserDo();
            _serviceMock.Setup(x => x.StartSessionAsync(It.IsAny<LoginRequest>()))
                               .Returns(Task.FromResult(fakeResponse))
                               .Verifiable();
            // Act
            var actionResult = await _controller.StartSessionAsync(fakeRequest);

            // Assert
            _serviceMock.Verify();
            Assert.Equal((actionResult.Result as OkObjectResult).StatusCode, StatusCodes.Status200OK);
            Assert.Equal(fakeRequest.Username, (((ObjectResult)actionResult.Result).Value as AspnetUserDo).UserName);
        }

        [Fact]
        /// <summary>
        /// StartSession Not Found
        /// </summary>
        public async Task Controller_ShouldReturnNotFound_WhenStartSession()
        {
            // Arrange
            var fakeRequest = new LoginRequest() { Username = "PLK_TEST", Password = "RtEmMLgq" };
            AspnetUserDo fakeResponse = null;
            _serviceMock.Setup(x => x.StartSessionAsync(It.IsAny<LoginRequest>()))
                               .Returns(Task.FromResult(fakeResponse))
                               .Verifiable();
            // Act
            var actionResult = await _controller.StartSessionAsync(fakeRequest);

            // Assert
            _serviceMock.Verify();
            Assert.Equal((actionResult.Result as NotFoundResult).StatusCode, StatusCodes.Status404NotFound);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns fake CompanyOrder
        /// </summary>
        private static AspnetUserDo GetFakeAspnetUserDo()
        {
            return
            new AspnetUserDo()
            {
                UserId = new Guid("B76C7D21-AC33-4CED-8B91-80FD3BB350DF"),
                UserName = "PLK_TEST",
                LoweredUserName = "plk_test",
                MobileAlias = "",
                IsAnonymous = false,
                LastActivityDate = DateTime.Now,
                Membership = new AspnetMembershipDo()
                {
                    UserId = new Guid("B76C7D21-AC33-4CED-8B91-80FD3BB350DF"),
                    Password = "6PnZ8LY6wCBnrCNnRs+EzuWb2A8=",
                    PasswordFormat = 1,
                    PasswordSalt = "amCREOsrZDLI/9yu8TbkUw==",
                    MobilePin = "",
                    Email = "alguien@correo.com",
                    LoweredEmail = "alguien@correo.com",
                    PasswordQuestion = "Algo por ahí",
                    PasswordAnswer = "Algo por allá",
                    IsApproved = true,
                    IsLockedOut = false,
                    CreateDate = DateTime.Now,
                    LastLoginDate = DateTime.Now,
                    LastPasswordChangedDate = DateTime.Now,
                    LastLockoutDate = new DateTime(2011, 6, 10),
                    FailedPasswordAttemptCount = 1,
                    FailedPasswordAttemptWindowStart = new DateTime(2011, 6, 10),
                    FailedPasswordAnswerAttemptCount = 1,
                    FailedPasswordAnswerAttemptWindowStart = new DateTime(2011, 6, 10),
                    Comment = ""
                }
            };
        }

        #endregion
    }
}