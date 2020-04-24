using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBackend.Entities;
using ToDoBackend.Models;

namespace ToDoBackend.Services
{
    public class LoginService : ILoginService
    {
        ToDoDBContext _context;
        public LoginService(ToDoDBContext _context)
        {
            this._context = _context;
        }
        public UserDefn UserLogin(UserDetails userDetails)
        {
            try
            {                
                var results = (from u in _context.UserDefn
                           where u.UserName == userDetails.UserName
                           || u.Email == userDetails.Email
                           select u).FirstOrDefault();
                if(results == null)
                {
                    var newUser = new UserDefn
                    {
                        UserName = userDetails.UserName,
                        Email = userDetails.Email
                    };
                    _context.UserDefn.Add(newUser);
                    _context.SaveChanges();
                }

                results = (from u in _context.UserDefn
                           where u.UserName == null
                           && u.Email == userDetails.Email
                           select u).FirstOrDefault();
                if (results != null)
                {
                    _context.Database.ExecuteSqlRaw("UPDATE User_DEFN SET UserName = '" + userDetails.UserName+"' WHERE Email = '"+userDetails.Email+"'");
                    _context.SaveChanges();
                }

                var user = (from u in _context.UserDefn
                            where u.Email == userDetails.Email
                            select u).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
