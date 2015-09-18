using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Buget.WebUI.Models.BussinessModels;
using Buget.WebUI.Services.RepositoryServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Buget.WebUI.Tests.Services
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestMethod]
        public void CreateUserRepositoryObject()
        {
            var repository = new UserRepository();
        }

        [TestMethod]
        public void SaveNewUserToRepository()
        {
            UserModel userModel = new UserModel()
            {
                Login = "test" + Guid.NewGuid().ToString().Substring(0, 10),
                Password = Guid.NewGuid().ToString().Substring(0, 10),
                LastName = "Last Name",
                FirstName = "First Name",
                BirthDate = DateTime.UtcNow,
                Email = Guid.NewGuid().ToString().Substring(0, 10),
                Roles = new [] { "User" }
            };

            var repository = new UserRepository();
            
            Assert.IsNotNull(repository.AddUser(userModel));
        }

        [TestMethod]
        public void SaveExistingUserToRepository()
        {
            UserModel userModel = new UserModel()
            {
                Login = "Test",
                Password = "Test",
                LastName = "Test",
                FirstName = "Test",
                BirthDate = DateTime.UtcNow,
                Email = "Test"                
            };

            var repository = new UserRepository();
            Assert.IsNull(repository.AddUser(userModel));
        }
    }
}
