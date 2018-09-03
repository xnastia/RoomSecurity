using System.Web.Http;

namespace Security.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            RegisterRoutes(config);
            RegisterDependencies(config);
        }

        private static void RegisterDependencies(HttpConfiguration config)
        {
            config.DependencyResolver = DependencyInjection.UnityDependencyResolver.CreateDependencyResolver();
        }

        private static void RegisterRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                "Default2",
                "{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}