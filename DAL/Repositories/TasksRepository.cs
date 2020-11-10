using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TasksRepository : IRepository<Tasks>
    {
        ExamPreparationDb db;

        public TasksRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Tasks item)
        {
            db.Tasks.Add(item);
        }

        public void Delete(int id)
        {
            Tasks item = db.Tasks.Find(id);
            if (item != null)
                db.Tasks.Remove(item);
        }

        public Tasks GetItem(int id)
        {
            return db.Tasks.Find(id);
        }

        public List<Tasks> GetList()
        {
            return db.Tasks.ToList();
        }

        public void Update(Tasks item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
