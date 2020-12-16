using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TeacherRepository : IRepository<Teacher>
    {
        ExamPreparationDb db;

        public TeacherRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Teacher item)
        {
            db.Teacher.Add(item);
        }

        public void Delete(int id)
        {
            Teacher item = db.Teacher.Find(id);
            if (item != null)
                db.Teacher.Remove(item);
        }

        public Teacher GetItem(int id)
        {
            return db.Teacher.Find(id);
        }

        public List<Teacher> GetList()
        {
            return db.Teacher.ToList();
        }

        public void Update(Teacher item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
