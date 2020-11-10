using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class StudentsRepository : IRepository<Students>
    {
        ExamPreparationDb db;

        public StudentsRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Students item)
        {
            db.Students.Add(item);
        }

        public void Delete(int id)
        {
            Students item = db.Students.Find(id);
            if (item != null)
                db.Students.Remove(item);
        }

        public Students GetItem(int id)
        {
            return db.Students.Find(id);
        }

        public List<Students> GetList()
        {
            return db.Students.ToList();
        }

        public void Update(Students item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
