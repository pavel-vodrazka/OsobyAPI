using System.Net;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Routing;

namespace OsobyApi.Controllers
{
    public class HttpNotFoundAwareControllerActionSelector : ApiControllerActionSelector
    {
        public HttpNotFoundAwareControllerActionSelector()
        { }

        public override HttpActionDescriptor SelectAction(HttpControllerContext controllerContext)
        {
            HttpActionDescriptor descriptor;
            try
            {
                descriptor = base.SelectAction(controllerContext);
            }
            catch (HttpResponseException ex)
            {
                HttpStatusCode code = ex.Response.StatusCode;
                if (code != HttpStatusCode.NotFound && code != HttpStatusCode.MethodNotAllowed)
                    throw;
                IHttpRouteData routeData = controllerContext.RouteData;
                routeData.Values["action"] = "Handle404";
                IHttpController httpController = new ErrorController();
                controllerContext.Controller = httpController;
                controllerContext.ControllerDescriptor = new HttpControllerDescriptor(controllerContext.Configuration, "Error", httpController.GetType());
                descriptor = base.SelectAction(controllerContext);
            }
            return descriptor;
        }
    }
}