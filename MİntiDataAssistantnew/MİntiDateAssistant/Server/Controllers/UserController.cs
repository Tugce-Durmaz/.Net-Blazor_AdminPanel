using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MİntiDateAssistant.Server.Services.Infastruce;
using MİntiDateAssistant.Shared.DTO;
using MİntiDateAssistant.Shared.ResponseModels;

namespace MİntiDateAssistant.Server.Controllers
{
    [Route("api/[controller]")]
   [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

       public UserController(IUserService UserService)

        {

           userService = UserService;  

       }

        [HttpGet("Users")]
        public async Task<ServiceResponse<List<UserDTO>>>GetUsers()
        {
            return new ServiceResponse<List<UserDTO>>()
           {
                Value = await userService.GetUsers()
           };
       }


    }
}
