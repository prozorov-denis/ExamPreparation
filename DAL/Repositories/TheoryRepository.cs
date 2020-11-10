using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TheoryRepository : IRepository<Theory>
    {
        ExamPreparationDb db;

        public TheoryRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Theory item)
        {
            db.Theory.Add(item);
        }

        public void Delete(int id)
        {
            Theory item = db.Theory.Find(id);
            if (item != null)
                db.Theory.Remove(item);
        }

        public Theory GetItem(int id)
        {
            return db.Theory.Find(id);
        }

        public List<Theory> GetList()
        {
            return db.Theory.ToList();
        }

        public void Update(Theory item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
