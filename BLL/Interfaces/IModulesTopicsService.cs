using BLL.ReportsDataDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IModulesTopicsService
    {
        List<ModulesTopicsDTO> ReportModulesTopics(int modules_ID);
    }
}
