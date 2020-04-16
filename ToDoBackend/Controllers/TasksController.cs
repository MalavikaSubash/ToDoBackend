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
        // GET: api/Tasks
        [HttpGet]
        public IEnumerable<Tasks> Get(int userId, DateTime taskDate, string status)
        {
            return taskService.getTasks(userId, taskDate, status);
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
            taskService.editTask(taskId,taskModel);
        }

        [HttpPut]
        public void updateStatus(int taskId, string Status)
        {
            taskService.updateStatus(taskId,Status);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete(int taskId)
        {
            taskService.deleteTask(taskId);
        }
    }
}
