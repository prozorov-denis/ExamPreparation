using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class User_TypesRepository : IRepository<User_Types>
    {
        ExamPreparationDb db;

        public User_TypesRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(User_Types item)
        {
            db.User_Types.Add(item);
        }

        public void Delete(int id)
        {
            User_Types item = db.User_Types.Find(id);
            if (item != null)
                db.User_Types.Remove(item);
        }

        public User_Types GetItem(int id)
        {
            return db.User_Types.Find(id);
        }

        public List<User_Types> GetList()
        {
            return db.User_Types.ToList();
        }

        public void Update(User_Types item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
