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
        public IEnumerable<Tasks> getTasks(int userId, DateTime taskDate, string status);
        public void addTask(taskDetails taskModel);
        public void editTask(int taskId, taskDetails taskModel);
        public void updateStatus(int taskId, string Status);
        public void deleteTask(int taskId);
    }
}
