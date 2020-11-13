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
    public class MessageRepository : IRepository<Message>
    {
        ExamPreparationDb db;

        public MessageRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Message item)
        {
            db.Message.Add(item);
        }

        public void Delete(int id)
        {
            Message item = db.Message.Find(id);
            if (item != null)
                db.Message.Remove(item);
        }

        public Message GetItem(int id)
        {
            return db.Message.Find(id);
        }

        public List<Message> GetList()
        {
            return db.Message.ToList();
        }

        public void Update(Message item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
