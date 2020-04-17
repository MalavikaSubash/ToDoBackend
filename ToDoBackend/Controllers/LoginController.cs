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
        public IloginService loginService;
        public LoginController(IloginService loginService)
        {
            this.loginService = loginService;
        }

        // PUT: api/Login
        [HttpPut]
        public UserDefn Put([FromBody] userDetails newUserDetails)
        {
            return loginService.userLogin(newUserDetails);
        }
    }
}
