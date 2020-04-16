using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoBackend.Entities;
using ToDoBackend.Models;

namespace ToDoBackend.Services
{
    public class tasksService: ItasksService
    {
        private readonly ToDoDBContext _context;
        
        public tasksService(ToDoDBContext _context)
        {
            this._context = _context;
        }

        public IEnumerable<Tasks> getTasks(int userId, DateTime taskDate, string status)
        {
            IList<Tasks> results = null;
            try
            {
                var statusId = (from s in _context.Status
                                where s.StatusName == status
                                select s.StatusId).FirstOrDefault();

                results = (from t in _context.Tasks
                           where t.UserId == userId 
                           && t.TaskDate == taskDate 
                           && t.StatusId == statusId
                           select t).ToList();
                return results;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void addTask(taskDetails taskModel)
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
                    TaskName = taskModel.TaskName,
                    TaskDescription = taskModel.TaskDescription,
                    TaskDate = taskModel.TaskDate,
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

        public void editTask(int taskId, taskDetails taskModel)
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

                _context.Database.ExecuteSqlRaw("UPDATE Tasks SET TaskName = '" + taskModel.TaskName+"', TaskDescription='"+taskModel.TaskDescription+"', TaskDate='"+taskModel.TaskDate+"', UserId='"+user.UserId+"' where TaskId='"+taskId+"'");
                _context.SaveChanges();
            } 
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public void updateStatus(int taskId, string Status)
        {
            try
            {
                var statusId = (from s in _context.Status
                                where s.StatusName == Status
                                select s.StatusId).FirstOrDefault();

                _context.Database.ExecuteSqlRaw("UPDATE Tasks SET StatusId = '"+statusId+"' where TaskId = '"+taskId+"'");
                _context.SaveChanges();
            }
            catch(Exception ex)
            { 
                throw ex;
            }
        }

        public void deleteTask(int taskId)
        {
            try
            {
                var task = (from t in _context.Tasks
                            where t.TaskId == taskId
                            select t).FirstOrDefault();
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
