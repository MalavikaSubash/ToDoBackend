using System;
using System.Collections.Generic;

namespace ToDoBackend.Entities
{
    public partial class UserDefn
    {
        public UserDefn()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
