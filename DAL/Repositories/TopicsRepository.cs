using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TopicsRepository : IRepository<Topics>
    {
        ExamPreparationDb db;

        public TopicsRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Topics item)
        {
            db.Topics.Add(item);
        }

        public void Delete(int id)
        {
            Topics item = db.Topics.Find(id);
            if (item != null)
                db.Topics.Remove(item);
        }

        public Topics GetItem(int id)
        {
            return db.Topics.Find(id);
        }

        public List<Topics> GetList()
        {
            return db.Topics.ToList();
        }

        public void Update(Topics item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
