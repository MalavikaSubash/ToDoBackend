using System;
using System.Collections.Generic;

namespace ToDoBackend.Entities
{
    public partial class Tasks
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime TaskDate { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }

        public virtual Status Status { get; set; }
        public virtual UserDefn User { get; set; }
    }
}
