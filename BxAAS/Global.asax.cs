using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;


namespace BxAAS
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.Register(RouteTable.Routes); 
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
