using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Buget.WebUI.Models.BussinessModels;

namespace Buget.WebUI.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private UserModel user;

        public CustomPrincipal(UserModel user)
        {
            this.user = user;
            Identity = new GenericIdentity(user.FirstName);
        }

        public bool IsInRole(string role)
        {
            return user.Roles.Contains(role);
        }

        public IIdentity Identity { get; private set; }
    }
}