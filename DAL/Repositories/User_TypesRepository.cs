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
    public class User_TypeRepository : IRepository<User_Type>
    {
        ExamPreparationDb db;

        public User_TypeRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(User_Type item)
        {
            db.User_Type.Add(item);
        }

        public void Delete(int id)
        {
            User_Type item = db.User_Type.Find(id);
            if (item != null)
                db.User_Type.Remove(item);
        }

        public User_Type GetItem(int id)
        {
            return db.User_Type.Find(id);
        }

        public List<User_Type> GetList()
        {
            return db.User_Type.ToList();
        }

        public void Update(User_Type item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
