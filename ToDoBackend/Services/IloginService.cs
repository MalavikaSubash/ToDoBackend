﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBackend.Entities;
using ToDoBackend.Models;

namespace ToDoBackend.Services
{
    public interface ILoginService
    {
        public UserDefn UserLogin(UserDetails newUserDetails);
    }
}
