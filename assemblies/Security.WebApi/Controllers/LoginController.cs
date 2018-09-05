using System.Net.Http.Formatting;
using System.Web.Http;
using Security.BusinessLogic;

namespace Security.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUserProvider _userProvider;
        public LoginController(IUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        [AcceptVerbs("Post")]
        public IHttpActionResult Post([FromBody] FormDataCollection formData)
        {
            var email = formData.Get("email");
            var password = formData.Get("password");

            //TODO: authenticate user
            var isValidUser = new SecurityApi(_userProvider).IsValidUser(email, password);

            if (isValidUser)
                return Ok();
            return Unauthorized();
        }
    }
}