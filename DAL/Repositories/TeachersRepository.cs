using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TeachersRepository : IRepository<Teachers>
    {
        ExamPreparationDb db;

        public TeachersRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Teachers item)
        {
            db.Teachers.Add(item);
        }

        public void Delete(int id)
        {
            Teachers item = db.Teachers.Find(id);
            if (item != null)
                db.Teachers.Remove(item);
        }

        public Teachers GetItem(int id)
        {
            return db.Teachers.Find(id);
        }

        public List<Teachers> GetList()
        {
            return db.Teachers.ToList();
        }

        public void Update(Teachers item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
