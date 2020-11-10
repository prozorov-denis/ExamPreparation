using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class MessagesRepository : IRepository<Messages>
    {
        ExamPreparationDb db;

        public MessagesRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Messages item)
        {
            db.Messages.Add(item);
        }

        public void Delete(int id)
        {
            Messages item = db.Messages.Find(id);
            if (item != null)
                db.Messages.Remove(item);
        }

        public Messages GetItem(int id)
        {
            return db.Messages.Find(id);
        }

        public List<Messages> GetList()
        {
            return db.Messages.ToList();
        }

        public void Update(Messages item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
