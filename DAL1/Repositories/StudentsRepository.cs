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
    public class StudentRepository : IRepository<Student>
    {
        ExamPreparationDb db;

        public StudentRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Student item)
        {
            db.Student.Add(item);
        }

        public void Delete(int id)
        {
            Student item = db.Student.Find(id);
            if (item != null)
                db.Student.Remove(item);
        }

        public Student GetItem(int id)
        {
            return db.Student.Find(id);
        }

        public List<Student> GetList()
        {
            return db.Student.ToList();
        }

        public void Update(Student item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
