using AutoMapper;
using C_mart_APIs.Model;
using C_mart_APIs.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Xamarin.Essentials;

namespace C_mart_APIs.Controllers
{
    [ApiController]
    [Route("controller")]
    public class AuthController : Controller
    {
        public static User user = new User();
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;
        private readonly IMapper mapper;

        public AuthController(IUserRepository userRepository,ITokenHandler tokenHandler,IMapper mapper)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetUserAsync")]
        public async Task<IActionResult> GetUserAsync(Guid id) 
        {
           var user= await userRepository.GetuserAsync(id);
            if (user == null) 
            { 
                return NotFound();
            }
           var request = mapper.Map<UserRequest>(user);
            return Ok(request);
        }
        [HttpGet]
        [Route("GetAllUsersorCustomers")]
        public IActionResult GetAllUsers() 
        {
            var user = userRepository.GetAll();
            var requests = new List<UserRequest>();
            user.ToList().ForEach(user =>
            {
                var request = new UserRequest()
                {
                    Id = user.Id,
                    Username = user.Username,
                    Firstname = user.Firstname,
                    lastname = user.lastname,
                    Email = user.Email,

                };
                requests.Add(request);
            });
            return Ok(requests);
        }
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(UserRequest request)
        {
            var register = new User()
            {
                Email = request.Email,
                Username = request.Username,
                Password = request.Password,
                Firstname = request.Firstname,
                lastname = request.lastname,
            };
             register = await userRepository.AddAsync(register);
            var user = new UserRequest()
            {   
                Id = register.Id,
                Username = register.Username,
                Email = register.Email,
                Password = register.Password,
                Firstname = register.Firstname,
                lastname = register.lastname,

            };
            return CreatedAtAction(nameof(GetUserAsync), new {id = user.Id},user);
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
