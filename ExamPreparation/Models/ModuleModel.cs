using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.Models
{
    public class ModuleModel
    {
        public string Title { get; set; }
        public string Theme { get; set; }
        public bool IsTheoryAvailable { get; set; }
        public bool AreProblemsAvailable { get; set; }
        public bool IsTestAvailable { get; set; }
    }
}
