using DAL.Entities;
using DAL.Interfaces;
using DAL.ReportsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ReportsRepository : IReportsRepository
    {
        ExamPreparationDb db;

        public ReportsRepository(ExamPreparationDb context)
        {
            this.db = context;
        }

        public List<ModulesTopics> ReportModulesTopics(int module_ID)
        {
            var request = db.Module
                .Where(i => i.Modules_ID == module_ID)
                .Join(db.Topic, m => m.Topics_ID, t => t.Topics_ID, (m, t) => new ModulesTopics() { ModuleNumber = m.Number, TopicTitle = t.Title })
                .ToList();

            return request;
        }
    }
}
