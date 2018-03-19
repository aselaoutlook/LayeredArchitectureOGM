using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Routing;

namespace FCL.Cockerham.Ogsm.ClientSite.App_Start
{
    public static class WebApiConfig
    {
        public class SessionRouteHandler : System.Web.Routing.IRouteHandler
        {
            System.Web.IHttpHandler System.Web.Routing.IRouteHandler.GetHttpHandler(System.Web.Routing.RequestContext requestContext)
            {
                return new SessionControllerHandler(requestContext.RouteData);
            }
        }

        public class SessionControllerHandler : System.Web.Http.WebHost.HttpControllerHandler, System.Web.SessionState.IRequiresSessionState
        {
            public SessionControllerHandler(System.Web.Routing.RouteData routeData)
                : base(routeData)
            { }
        }

        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            RouteTable.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            ).RouteHandler = new SessionRouteHandler();

            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Include;
            config.MessageHandlers.Add(new PreflightRequestsHandler()); 
        }

        public class PreflightRequestsHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request.Headers.Contains("Origin") && request.Method.Method.Equals("OPTIONS"))
                {
                    var response = new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
                    // Define and add values to variables: origins, headers, methods (can be global)               
                    response.Headers.Add("Access-Control-Allow-Headers", "accept, content-type");

                    var tsc = new TaskCompletionSource<HttpResponseMessage>();
                    tsc.SetResult(response);
                    return tsc.Task;
                }
                return base.SendAsync(request, cancellationToken);
            }

        }
    }
}