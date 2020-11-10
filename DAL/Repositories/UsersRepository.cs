using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UsersRepository : IRepository<Users>
    {
        ExamPreparationDb db;

        public UsersRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Users item)
        {
            db.Users.Add(item);
        }

        public void Delete(int id)
        {
            Users item = db.Users.Find(id);
            if (item != null)
                db.Users.Remove(item);
        }

        public Users GetItem(int id)
        {
            return db.Users.Find(id);
        }

        public List<Users> GetList()
        {
            return db.Users.ToList();
        }

        public void Update(Users item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
