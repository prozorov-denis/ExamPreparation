using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ModulesRepository : IRepository<Modules>
    {
        ExamPreparationDb db;

        public ModulesRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Modules item)
        {
            db.Modules.Add(item);
        }

        public void Delete(int id)
        {
            Modules item = db.Modules.Find(id);
            if (item != null)
                db.Modules.Remove(item);
        }

        public Modules GetItem(int id)
        {
            return db.Modules.Find(id);
        }

        public List<Modules> GetList()
        {
            return db.Modules.ToList();
        }

        public void Update(Modules item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
