using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBackend.Entities;
using ToDoBackend.Models;

namespace ToDoBackend.Services
{
    public interface ITasksService
    {
        public List<Tasks> GetTasks(GetTask getTasksModel);
        public void AddTask(TaskDetails taskModel);
        public void EditTask(int taskId, TaskDetails taskModel);
        public void UpdateStatus(UpdateStatus statusModel);
        public void DeleteTask(int taskId);
    }
}
