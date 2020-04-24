using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoBackend.Entities;
using ToDoBackend.Models;
using ToDoBackend.Services;

namespace ToDoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        public ITasksService taskService;

        public TasksController(ITasksService taskService)
        {
            this.taskService = taskService;
        }
        // POST: api/Tasks
        [HttpPost("Dashboard")]
        public List<Tasks> GetTasks([FromBody] GetTask getTasksModel)
        {
            var allTasks = taskService.GetTasks(getTasksModel);
            return allTasks;
        }

        // POST: api/Tasks
        [HttpPost]
        public void AddTask([FromBody] TaskDetails taskModel)
        {
            taskService.AddTask(taskModel);
        }

        // PUT: api/Tasks/5
        [HttpPut("{taskId}")]
        public void EditTask(int taskId, [FromBody] TaskDetails taskModel)
        {
            taskService.EditTask(taskId, taskModel);
        }

        [HttpPut("update")]
        public void UpdateStatus([FromBody] UpdateStatus statusModel)
        {
            taskService.UpdateStatus(statusModel);
        }

        [HttpPut("delete/{taskId}")]
        public void DeleteTask(int taskId)
        {
            taskService.DeleteTask(taskId);
        }
    }
}
