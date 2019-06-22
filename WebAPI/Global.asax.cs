using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebAPI.Models;
using WebAPI.Initial;
using System.Xml;
using System.Text;
using System.Data.Entity.Infrastructure;

namespace WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Generate Database
            BookStoreDbContext db = new BookStoreDbContext();
            if (db.Database.CreateIfNotExists())
            {
                initial i = new initial();
                i.InitialData();
            }

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
