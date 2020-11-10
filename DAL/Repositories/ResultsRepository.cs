using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ResultsRepository : IRepository<Results>
    {
        ExamPreparationDb db;

        public ResultsRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Results item)
        {
            db.Results.Add(item);
        }

        public void Delete(int id)
        {
            Results item = db.Results.Find(id);
            if (item != null)
                db.Results.Remove(item);
        }

        public Results GetItem(int id)
        {
            return db.Results.Find(id);
        }

        public List<Results> GetList()
        {
            return db.Results.ToList();
        }

        public void Update(Results item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
