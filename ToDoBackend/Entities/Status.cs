using System;
using System.Collections.Generic;

namespace ToDoBackend.Entities
{
    public partial class Status
    {
        public Status()
        {
            Tasks = new HashSet<Tasks>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Tasks> Tasks { get; set; }
    }
}
