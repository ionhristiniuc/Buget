using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Buget.WebUI.Interfaces.UserAccount;
using Buget.WebUI.Security;
using Buget.WebUI.Services.RepositoryServices;
using Buget.WebUI.Services.UserAccountServices;

namespace Buget.WebUI
{
    public class MvcApplication : HttpApplication
    {               
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            if (FormsAuthentication.CookiesSupported)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        IUserAccountService accountService = new UserAccountService(new UserRepository());
                        string login = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;                        
                        var userModel = accountService.GetUser(login);
                        
                        //HttpContext.Current.User = new GenericPrincipal(new GenericIdentity(username, "Forms"), roles.Split(';'));
                        HttpContext.Current.User = new CustomPrincipal(userModel);
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }
    }
}
