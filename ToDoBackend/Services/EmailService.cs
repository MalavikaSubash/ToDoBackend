using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using ToDoBackend.Entities;
using ToDoBackend.Models;

namespace ToDoBackend.Services
{
    public class EmailService: IEmailService
    {
        ToDoDBContext _context;
        private readonly IConfiguration _iConfiguration;
        public EmailService(IConfiguration iConfiguration, ToDoDBContext _context)
        {
            _iConfiguration = iConfiguration;
            this._context = _context;
        }
        public bool SendMail(EmailModel emailModel)
        {
            try
            {
                var toUserId = (from u in _context.UserDefn
                                where u.Email == emailModel.ToMailId
                                select u.UserId).FirstOrDefault();

                if (toUserId == emailModel.SenderId)
                {
                    return false;
                }
                else
                {
                    var sender = (from u in _context.UserDefn
                                  where u.UserId == emailModel.SenderId
                                  select u.UserName).FirstOrDefault();

                    MailMessage mail = new MailMessage("todoapp.experion@gmail.com", emailModel.ToMailId);
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com", 587);
                    mail.Subject = "You got a new Task !";
                    mail.Body = "<p>Hi</p><p> A new task is waiting for you.</p><span style = 'display: inline-block;margin-left: 20px;' > Task: " + " " + emailModel.Message + " </span><br><span style = 'display: inline-block;margin-left: 20px;'> Assinged by: " + " " + sender + " </span><br><p> Log on to ToDo for more details.</p><span> Thanks & regards </span><br><span> Team ToDo </span> ";

                    mail.IsBodyHtml = true;
                    SmtpServer.Credentials = new System.Net.NetworkCredential()
                    {
                        UserName = "todoapp.experion@gmail.com",
                        Password = "todo@exp97"
                    };

                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    SmtpServer.Dispose();

                    return true;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }
    }
}
