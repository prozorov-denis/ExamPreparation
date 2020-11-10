using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ModulesModel
    {
        public int Modules_ID { get; set; }

        public int Plans_ID { get; set; }

        public int Number { get; set; }
       
        public DateTime Start_Date { get; set; }

        public DateTime End_Date { get; set; }

        public int Topics_ID { get; set; }

        public ModulesModel() { }

        public ModulesModel(Modules modules)
        {
            Modules_ID = modules.Modules_ID;
            Plans_ID = modules.Plans_ID;
            Number = modules.Number;
            Start_Date = modules.Start_Date;
            End_Date = modules.End_Date;
            Topics_ID = modules.Topics_ID;
        }
    }
}
