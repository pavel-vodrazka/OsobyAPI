using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OsobyApi.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ApiController
    {
        [HttpGet, HttpPost, HttpPut, HttpDelete, HttpHead, HttpOptions, AcceptVerbs("PATCH")]
        public HttpResponseMessage Handle404()
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.NotFound);
            //responseMessage.ReasonPhrase = "The requested resource is not found.";
            return responseMessage;
        }
    }
}