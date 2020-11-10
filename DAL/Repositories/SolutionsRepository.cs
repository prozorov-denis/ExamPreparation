using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class SolutionsRepository : IRepository<Solutions>
    {
        ExamPreparationDb db;

        public SolutionsRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Solutions item)
        {
            db.Solutions.Add(item);
        }

        public void Delete(int id)
        {
            Solutions item = db.Solutions.Find(id);
            if (item != null)
                db.Solutions.Remove(item);
        }

        public Solutions GetItem(int id)
        {
            return db.Solutions.Find(id);
        }

        public List<Solutions> GetList()
        {
            return db.Solutions.ToList();
        }

        public void Update(Solutions item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
