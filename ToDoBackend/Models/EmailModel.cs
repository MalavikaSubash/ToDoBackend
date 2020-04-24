using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBackend.Models
{
    public class EmailModel
    {
        public string ToMailId { get; set; }
        public string Message { get; set; }
        public int SenderId { get; set; }
    }
}
