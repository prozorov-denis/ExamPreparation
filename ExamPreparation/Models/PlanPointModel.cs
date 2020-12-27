using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.Models
{
    public class PlanPointModel
    {
        public string TopicTitle { get; set; }
        
        public string Date { get; set; }

        public PlanPointModel(string TopicTitle, DateTime Date)
        {
            this.TopicTitle = TopicTitle;
            this.Date = "до " + Date.Day + "." + Date.Month + "." + Date.Year;
        }
        
    }
}
