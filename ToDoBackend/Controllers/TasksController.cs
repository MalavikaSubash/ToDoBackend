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
        public ItasksService taskService;

        public TasksController(ItasksService taskService)
        {
            this.taskService = taskService;
        }
        // POST: api/Tasks
        [HttpPost("Dashboard")]
        public List<Tasks> Get([FromBody] getTask taskModel)
        {
            var allTasks = taskService.getTasks(taskModel);
            return allTasks;
        }

        // POST: api/Tasks
        [HttpPost]
        public void Post(taskDetails taskModel)
        {
            taskService.addTask(taskModel);
        }

        // PUT: api/Tasks/5
        [HttpPut("{taskId}")]
        public void editTask(int taskId, [FromBody] taskDetails taskModel)
        {
            taskService.editTask(taskId, taskModel);
        }

        [HttpPut("update")]
        public void updateStatus([FromBody] updateStatus statusModel)
        {
            taskService.updateStatus(statusModel);
        }

        [HttpPut("delete/{taskId}")]
        public void deleteTask(int taskId)
        {
            taskService.deleteTask(taskId);
        }
    }
}
