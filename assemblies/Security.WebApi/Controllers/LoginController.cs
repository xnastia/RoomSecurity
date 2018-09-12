using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json;
using Security.BusinessLogic;

namespace Security.WebApi.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IUserProvider _userProvider;
        private readonly IAuthenticationProvider _authenticationProvider;

        public LoginController(IUserProvider userProvider, IAuthenticationProvider authenticationProvider)
        {
            _userProvider = userProvider;
            _authenticationProvider = authenticationProvider;
        }

        [System.Web.Http.AcceptVerbs("Post")]
        public IHttpActionResult Post([FromBody] FormDataCollection formData)
        {
            var email = formData.Get("email");
            var password = formData.Get("password");

            //TODO: authenticate user
            var isValidUser = new SecurityApi(_userProvider).IsValidUser(email, password);

            if (isValidUser)
            {
                var token = _authenticationProvider.GetNewUserToken(email);
                return Json(token, new JsonSerializerSettings());
            }
                
            return Unauthorized();
        }
    }
}