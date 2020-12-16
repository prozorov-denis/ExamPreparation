using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.Models
{
    public class ResultModel
    {
        public int Task_Id { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
