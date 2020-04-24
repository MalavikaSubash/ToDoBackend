using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoBackend.Models;
using ToDoBackend.Services;

namespace ToDoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        public IEmailService emailService;
        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        // POST: api/Email
        [HttpPost]
        public bool SendMail([FromBody] EmailModel emailModel)
        {
            return emailService.SendMail(emailModel);
        }
    }
}
