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
    public class UserRepository : IRepository<User>
    {
        ExamPreparationDb db;

        public UserRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(User item)
        {
            db.User.Add(item);
        }

        public void Delete(int id)
        {
            User item = db.User.Find(id);
            if (item != null)
                db.User.Remove(item);
        }

        public User GetItem(int id)
        {
            return db.User.Find(id);
        }

        public List<User> GetList()
        {
            return db.User.ToList();
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
