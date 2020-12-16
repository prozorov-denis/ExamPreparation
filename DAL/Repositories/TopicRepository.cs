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
    public class TopicRepository : IRepository<Topic>
    {
        ExamDbContext db;

        public TopicRepository(ExamDbContext context)
        {
            this.db = context;
        }

        public void Create(Topic item)
        {
            db.Topic.Add(item);
        }

        public void Delete(int id)
        {
            Topic item = db.Topic.Find(id);
            if (item != null)
                db.Topic.Remove(item);
        }

        public Topic GetItem(int id)
        {
            return db.Topic.Find(id);
        }

        public List<Topic> GetList()
        {
            return db.Topic.ToList();
        }

        public void Update(Topic item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
