using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBackend.Models
{
    public class getTask
    {
        public int userId { get; set; }
        public DateTime TaskDate { get; set; }
        public string Status { get; set; }
    }
}
