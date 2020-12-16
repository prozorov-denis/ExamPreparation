﻿using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    public class TaskRepository : IRepository<Task>
    {
        ExamDbContext db;

        public TaskRepository(ExamDbContext context)
        {
            this.db = context;
        }

        public void Create(Task item)
        {
            db.Task.Add(item);
        }

        public void Delete(int id)
        {
            Task item = db.Task.Find(id);
            if (item != null)
                db.Task.Remove(item);
        }

        public Task GetItem(int id)
        {
            return db.Task.Find(id);
        }

        public List<Task> GetList()
        {
            return db.Task.ToList();
        }

        public void Update(Task item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
