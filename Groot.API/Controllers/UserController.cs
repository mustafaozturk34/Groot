using AutoMapper;
using Groot.Model;
using Groot.Service.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Groot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(IUserService _userService, IMapper _mapper)
        {
            userService = _userService;
            mapper = _mapper;
        }
        [HttpPost]
        public General<Model.User.User> Insert([FromBody] Groot.Model.User.User newUser)
        {
            var result = false;
            return userService.Insert(newUser);            
        }
    }
}
