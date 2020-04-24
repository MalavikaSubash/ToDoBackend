using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoBackend.Entities;
using ToDoBackend.Models;
using ToDoBackend.Services;

namespace ToDoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }

        // PUT: api/Login
        [HttpPut]
        public UserDefn Put([FromBody] UserDetails newUserDetails)
        {
            return loginService.UserLogin(newUserDetails);
        }
    }
}
