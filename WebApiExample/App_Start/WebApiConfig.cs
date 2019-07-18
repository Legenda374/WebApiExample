using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;
using WebApiExample.Dependencies;
using WebApiExample.Dependencies.Interface;

namespace WebApiExample
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Unity configuration
            var unity = new UnityContainer();
           unity.RegisterType<IGreeter, Greeter>("HelloGreeter", new InjectionConstructor("Hi there!"));
           unity.RegisterType<IGreeter, Greeter>("HiGreeter", new InjectionConstructor("Hi everyone!"));

            config.DependencyResolver = new UnityDependencyResolver(unity);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
