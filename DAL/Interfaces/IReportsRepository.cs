using DAL.ReportsData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReportsRepository
    {
        List<ModulesTopics> ReportModulesTopics(int modules_ID);
    }
}
