using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EventPlanning.Models.DB;

namespace EventPlanning
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            EventContext ePDBContext = new EventContext();
            ePDBContext.Database.Delete();
            ePDBContext.Database.Create();
            ePDBContext.Users.Add(new Models.DB.Tables.User(){
                UserId = "1",
                Email = "test@example.te",
                ConfirmedEmail = true,
                Password = " ",
                Name = "Pyotr"
            });
            ePDBContext.SaveChanges();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
