using System.Net.Http.Formatting;
using System.Web.Http;
using Security.BusinessLogic;

namespace Security.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        [AcceptVerbs("Post")]
        public IHttpActionResult Post([FromBody]FormDataCollection formData)
        {
            var email = formData.Get("email");
            var password = formData.Get("password");

            //TODO: authenticate user
            var isValidUser = new SecurityApi().IsValidtUser(email, password);

            if (isValidUser)
                return Ok();
            return Unauthorized();
        }
    }
}