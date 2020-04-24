using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBackend.Models
{
    public class UpdateStatus
    {
        public int taskId { get; set; }
        public string status { get; set; }
    }
}
