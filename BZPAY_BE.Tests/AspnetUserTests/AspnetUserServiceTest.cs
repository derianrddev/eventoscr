using AutoMapper;
using BZPAY_BE.Repositories.Interfaces;
using BZPAY_BE.Models;
using BZPAY_BE.DataAccess;
using BZPAY_BE.Common.Profiles;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using BZPAY_BE.BussinessLogic.auth.ServiceInterface;
using BZPAY_BE.BussinessLogic.auth.ServiceImplementation;

namespace BZPAY_BE.UnitTests.AspnetUserTests
{
    /// <summary>
    /// AspnetUser service unit tests
    /// </summary>
    public class AspnetUserServiceTest
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly Mock<IAspnetUserRepository> _repositoryMock;
        private readonly IAspnetUserService _service;
        #endregion

        #region Constructor
        public AspnetUserServiceTest()
        {
            //_mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile( new AspnetUserProfile())));
            _mapper = new Mapper(new MapperConfiguration(cfg => { 
                                                                   cfg.AddProfile(new AspnetUserProfile());
                                                                   cfg.AddProfile(new AspnetMembershipProfile());
                                                                }
                                                        )
                                );     
            _repositoryMock = new Mock<IAspnetUserRepository>();
            _service = new AspnetUserService(_repositoryMock.Object, _mapper);
        }
        #endregion

        #region Public Methods  
        
        [Fact]
        /// <summary>
        /// Start Session 
        /// </summary>
        public async Task Service_Should_StartSessionAsync()
        {
            // Arrange
            var fakeRequest = new LoginRequest() { Username = "PLK_TEST", Password = "RtEmMLgq" };
            _repositoryMock.Setup(repository => repository
                                            .GetUserByUserNameAsync(It.IsAny<string>()))
                                            .Returns(Task.FromResult(GetFakeAspnetUser()))
                                            .Verifiable();
            // Act
            AspnetUserDo? result = await _service.StartSessionAsync(fakeRequest);
            _repositoryMock.VerifyAll();

            // Assert
            Assert.NotNull(result);
            Assert.True(result.UserName.Equals(fakeRequest.Username));
    
        }

        #endregion       

        #region Private Methods
        /// <summary>
        /// Returns fake AspnetUser
        /// </summary>
        private static AspnetUser? GetFakeAspnetUser()
        {
            return
            new AspnetUser()
            {
                UserId = new Guid("B76C7D21-AC33-4CED-8B91-80FD3BB350DF"),
                UserName = "PLK_TEST",
                LoweredUserName = "plk_test",
                MobileAlias = "",
                IsAnonymous = false,
                LastActivityDate = DateTime.Now,
                AspnetMembership = new AspnetMembership()
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