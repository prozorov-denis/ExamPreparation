using BLL.Interfaces;
using BLL.ReportsDataDTO;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ModulesTopicsService : IModulesTopicsService
    {
        IUnitOfWork db;

        public ModulesTopicsService(IUnitOfWork unitOfWork)
        {
            this.db = unitOfWork;
        }

        public List<ModulesTopicsDTO> ReportModulesTopics(int modules_ID)
        {
            var request = db.IReportsRepository.ReportModulesTopics(modules_ID)
                .Select(i => new ModulesTopicsDTO() { ModuleNumber = i.ModuleNumber, TopicTitle = i.TopicTitle })
                .ToList();

            return request;
        }
    }
}
