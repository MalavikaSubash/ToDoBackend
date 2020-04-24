using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBackend.Models;

namespace ToDoBackend.Services
{
    public interface IEmailService
    {
        bool SendMail(EmailModel emailModel);
    }
}
