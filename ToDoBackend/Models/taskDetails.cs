using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBackend.Models
{
    public class taskDetails
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string Email { get; set; }
        public DateTime TaskDate { get; set; }
        public string Status { get; set; }
    }
}
