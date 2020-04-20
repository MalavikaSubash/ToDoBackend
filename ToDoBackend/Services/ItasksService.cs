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
        public List<Tasks> getTasks(getTask taskModel);
        public void addTask(taskDetails taskModel);
        public void editTask(int taskId, taskDetails taskModel);
        public void updateStatus(updateStatus statusModel);
        public void deleteTask(int taskId);
    }
}
