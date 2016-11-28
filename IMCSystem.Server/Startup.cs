using IMCSystem.Server.Models;
using Owin;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;

namespace IMCSystem.Server
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();

            // Support only JSON
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapODataServiceRoute("odata", "odata", model: GetModel());

            appBuilder.UseWebApi(config);
        }

        public Microsoft.OData.Edm.IEdmModel GetModel()
        {
            ODataModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Drug>("Drug");

 

            return builder.GetEdmModel();
        }
    }
}
