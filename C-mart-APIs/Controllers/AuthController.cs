using C_mart_APIs.Model;
using C_mart_APIs.Repository;
using Microsoft.AspNetCore.Mvc;

namespace C_mart_APIs.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository,ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }
        [HttpPost]
        [Route("login")]
        public async Task< IActionResult> LoginAsync(LoginRequest request)
        {
           var user= await userRepository.AuthenticateAsync(request.Username,request.Password);
            if (user!=null)
            {
               var token= await tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }
            return BadRequest("UserName or Password is incorrect");
        }
    }
}
