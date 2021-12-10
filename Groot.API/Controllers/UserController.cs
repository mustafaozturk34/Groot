using AutoMapper;
using Groot.API.Infrastructer;
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

        [LoginFilter]
        [HttpPost("login")]
        public bool Login(string userName, string password)
        {
            return userService.Login(userName, password);
        }

        [HttpGet]
        public General<Model.User.User> GetUsers()
        {
            return userService.GetUsers();
        }

        [HttpPut("{id}")]
        public General<Model.User.User> Update(int id, [FromBody] Model.User.User user)
        {
            return userService.Update(id, user);
        }

        [HttpDelete]
        public General<Model.User.User> Delete(int id)
        {
            return userService.Delete(id);
        }
    }
}
