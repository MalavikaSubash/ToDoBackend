using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBackend.Entities;
using ToDoBackend.Models;

namespace ToDoBackend.Services
{
    public class TasksService: ITasksService
    {
        private readonly ToDoDBContext _context;
        
        public TasksService(ToDoDBContext _context)
        {
            this._context = _context;
        }

       public List<Tasks> GetTasks(GetTask getTasksModel)
        {
            List<Tasks> results = null;
            try
            {
                var statusId = (from s in _context.Status
                                where s.StatusName == getTasksModel.Status
                                select s.StatusId).FirstOrDefault();

                results = (from t in _context.Tasks
                           where t.UserId == getTasksModel.userId 
                           && t.TaskDate == getTasksModel.TaskDate 
                           && t.StatusId == statusId
                           select t).ToList();
                return results;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AddTask(TaskDetails taskModel)
        {
            try
            {
                var user = (from u in _context.UserDefn
                            where u.Email == taskModel.Email
                            select u).FirstOrDefault();
                if (user == null)
                {
                    UserDefn newUser = new UserDefn
                    {
                        Email = taskModel.Email
                    };
                    _context.UserDefn.Add(newUser);
                    _context.SaveChanges();
                }

                user = (from u in _context.UserDefn
                        where u.Email == taskModel.Email
                        select u).FirstOrDefault();

                Tasks newTask = new Tasks
                {
                    TaskName = taskModel.Name,
                    TaskDescription = taskModel.Description,
                    TaskDate = taskModel.Date,
                    StatusId = 1,
                    UserId = user.UserId
                };

                _context.Tasks.Add(newTask);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public void EditTask(int taskId, TaskDetails taskModel)
        {
            try
            {
                var user = (from u in _context.UserDefn
                            where u.Email == taskModel.Email
                            select u).FirstOrDefault();

                if (user == null)
                {
                    UserDefn newUser = new UserDefn
                    {
                        Email = taskModel.Email
                    };
                    _context.UserDefn.Add(newUser);
                    _context.SaveChanges();
                }

                user = (from u in _context.UserDefn
                        where u.Email == taskModel.Email
                        select u).FirstOrDefault();

                _context.Database.ExecuteSqlRaw("UPDATE Tasks SET TaskName = '" + taskModel.Name+"', TaskDescription='"+taskModel.Description+"', TaskDate='"+taskModel.Date+"', UserId='"+user.UserId+"' where TaskId='"+taskId+"'");
                _context.SaveChanges();
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void UpdateStatus(UpdateStatus statusModel)
        {
            try
            {
                var statusId = (from s in _context.Status
                                where s.StatusName == statusModel.status
                                select s.StatusId).FirstOrDefault();

                _context.Database.ExecuteSqlRaw("UPDATE Tasks SET StatusId = '"+statusId+"' where TaskId = '"+statusModel.taskId+"'");
                _context.SaveChanges();
            }
            catch(Exception ex)
            { 
                throw ex;
            }
        }

        public void DeleteTask(int taskId)
        {
            try
            {
                var statusId = (from s in _context.Status
                                where s.StatusName == "Deleted"
                                select s.StatusId).FirstOrDefault();

                _context.Database.ExecuteSqlRaw("UPDATE Tasks SET StatusId = '"+statusId+"' where TaskId = '"+taskId+"'");
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
