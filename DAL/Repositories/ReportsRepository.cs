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

        public List<ModulesTopics> ReportModulesTopics(int modules_ID)
        {
            var request = db.Modules
                .Where(i => i.Modules_ID == modules_ID)
                .Join(db.Topics, m => m.Topics_ID, t => t.Topics_ID, (m, t) => new ModulesTopics() { ModuleNumber = m.Number, TopicTitle = t.Title })
                .ToList();

            return request;
        }
    }
}
