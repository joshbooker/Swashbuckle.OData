using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using SwashbuckleODataSample.Models;

using Microsoft.Restier.EntityFramework;
using Microsoft.Restier.WebApi;
using Microsoft.Restier.WebApi.Batch;

namespace SwashbuckleODataSample
{
    public static class WebApiConfig
    {
        public const string ODataRoutePrefix = "odata";

        public async static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            /*
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Order>("Orders");
            var edmModel = builder.GetEdmModel();
            config.MapODataServiceRoute("odata", ODataRoutePrefix, edmModel);
            */
            await config.MapRestierRoute<DbApi<SwashbuckleODataContext>>(
                "odata",
                "odata/v4",
                new RestierBatchHandler(GlobalConfiguration.DefaultServer));
        }
    }
}
