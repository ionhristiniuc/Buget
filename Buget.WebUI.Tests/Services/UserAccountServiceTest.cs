using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buget.WebUI.Interfaces;
using Buget.WebUI.Interfaces.Repository;
using Buget.WebUI.Interfaces.UserAccount;
using Buget.WebUI.Models.BussinessModels;
using Buget.WebUI.Services.UserAccountServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Buget.WebUI.Tests.Services
{
    [TestClass]
    public class UserAccountServiceTest
    {
        [TestMethod]
        public void CreateUserAccountServiceObject()
        {
            var mock = new Mock<IUserRepository>();                       
            var service = new UserAccountService(mock.Object);
        }

        [TestMethod]
        public void LogOnWithCorrectLoginAndPasswordReturnsNotNullUser()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(r => r.GetUser("12345678"))
                .Returns(new UserModel()
                {
                    Id = 1,
                    Login = "12345678",
                    Password = "87654321",                                  
                });

            var service = new UserAccountService(mock.Object);            
            Assert.IsNotNull(service.LogOn("12345678", "87654321"));            
        }

        [TestMethod]
        public void LogOnWithInvalidLoginReturnsNull()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(r => r.GetUser("12345678"))
                .Returns(new UserModel()
                {
                    Id = 1,
                    Login = "12345678",
                    Password = "87654321",
                });

            var service = new UserAccountService(mock.Object);
            Assert.IsNull(service.LogOn("invalidPass", "87654321"));            
        }

        [TestMethod]
        public void LogOnWithCorrectLoginInvalidPasswordReturnsNull()
        {
            var mock = new Mock<IUserRepository>();
            mock.Setup(r => r.GetUser("12345678"))
                .Returns(new UserModel()
                {
                    Id = 1,
                    Login = "12345678",
                    Password = "87654321",
                });

            var service = new UserAccountService(mock.Object);
            Assert.IsNull(service.LogOn("12345678", "invalidPass"));
        }

        [TestMethod]
        public void RegisterNewUser()
        {
            var mock = new Mock<IUserRepository>();
            var service = new UserAccountService(mock.Object);

            Assert.IsNotNull(service.Register("newLogin123", "Password123"));
        }

        [TestMethod]
        public void RegisterExistingUser()
        {
            var mock = new Mock<IUserRepository>();
            //mock.Setup(r => r.)
            var service = new UserAccountService(mock.Object);

            Assert.IsNotNull(service.Register("newLogin123", "Password123"));
        }
    }
}
