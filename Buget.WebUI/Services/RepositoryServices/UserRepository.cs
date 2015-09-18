using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using Buget.WebUI.Interfaces;
using Buget.WebUI.Interfaces.Repository;
using Buget.WebUI.Models.BussinessModels;
using Buget.WebUI.Models.DbModels;
using Microsoft.Ajax.Utilities;

namespace Buget.WebUI.Services.RepositoryServices
{
    public class UserRepository : IUserRepository
    {        
        public UserModel GetUser(string login)
        {
            using (var dbModel = new BugetEntities())
            {
                var user = dbModel.Users
                    .Include("Roles")
                    .Include("Duties")
                    .FirstOrDefault(u => u.Login == login);

                if (user != null)
                    return Convert(user);

                return null;
            }            
        }

        public int? AddUser(UserModel userModel)
        {
            using (var dbModel = new BugetEntities())
            {
                var user = Convert(userModel);
                var userRoles = dbModel.Roles.Where(r => userModel.Roles.Contains(r.Name)).ToList();

                foreach (var role in userRoles)
                    user.Roles.Add(role);

                dbModel.Entry(user).State = EntityState.Added;  
                dbModel.Users.Add(user);                              

                if (dbModel.SaveChanges() > 0)
                    return user.Id;
                    
                    return null;
            }
        }

        private UserModel Convert(User user)
        {
            var userModel = new UserModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,                
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Email = user.Email,                
                Login = user.Login,
                Password = user.Password,
                Roles = user.Roles.Select(r => r.Name)
            };

            return userModel;
        }

        private User Convert(UserModel userModel)
        {
            var user = new User()
            {
                Id = userModel.Id,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                BirthDate = userModel.BirthDate,
                Email = userModel.Email,
                Login = userModel.Login,
                Password = userModel.Password,                
            };            

            return user;
        }            
    }
}