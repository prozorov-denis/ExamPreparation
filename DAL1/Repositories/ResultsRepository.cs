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
    public class ResultRepository : IRepository<Result>
    {
        ExamPreparationDb db;

        public ResultRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Result item)
        {
            db.Result.Add(item);
        }

        public void Delete(int id)
        {
            Result item = db.Result.Find(id);
            if (item != null)
                db.Result.Remove(item);
        }

        public Result GetItem(int id)
        {
            return db.Result.Find(id);
        }

        public List<Result> GetList()
        {
            return db.Result.ToList();
        }

        public void Update(Result item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
