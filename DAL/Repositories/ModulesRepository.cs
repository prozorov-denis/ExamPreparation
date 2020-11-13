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
    public class ModuleRepository : IRepository<Module>
    {
        ExamPreparationDb db;

        public ModuleRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public void Create(Module item)
        {
            db.Module.Add(item);
        }

        public void Delete(int id)
        {
            Module item = db.Module.Find(id);
            if (item != null)
                db.Module.Remove(item);
        }

        public Module GetItem(int id)
        {
            return db.Module.Find(id);
        }

        public List<Module> GetList()
        {
            return db.Module.ToList();
        }

        public void Update(Module item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
