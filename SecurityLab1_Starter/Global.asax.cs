using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SecurityLab1_Starter.Models;

namespace SecurityLab1_Starter
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyResolver.SetResolver(new Infrastructure.NinjectDependencyResolver());
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            Logger log = new Logger();
            log.LogToEventViewer(System.Diagnostics.EventLogEntryType.Error, ex.Message);
            Response.Redirect("/Error/ServerError");
        } 

        }
    }
