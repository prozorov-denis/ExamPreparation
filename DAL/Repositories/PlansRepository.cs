using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PlansRepository : IRepository<Plans>
    {
        ExamPreparationDb db;

        public PlansRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Plans item)
        {
            db.Plans.Add(item);
        }

        public void Delete(int id)
        {
            Plans item = db.Plans.Find(id);
            if (item != null)
                db.Plans.Remove(item);
        }

        public Plans GetItem(int id)
        {
            return db.Plans.Find(id);
        }

        public List<Plans> GetList()
        {
            return db.Plans.ToList();
        }

        public void Update(Plans item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
