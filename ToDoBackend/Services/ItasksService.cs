using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBackend.Entities;
using ToDoBackend.Models;

namespace ToDoBackend.Services
{
    public interface ItasksService
    {
        public List<Tasks> GetTasks(getTask taskModel);
        public void AddTask(taskDetails taskModel);
        public void EditTask(int taskId, taskDetails taskModel);
        public void UpdateStatus(updateStatus statusModel);
        public void DeleteTask(int taskId);
    }
}
