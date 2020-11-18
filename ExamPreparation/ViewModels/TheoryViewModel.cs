using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPreparation.ViewModels
{
    public class TheoryViewModel
    {
        public string Title { get; set; }

        public string Theory { get; set; }

        public TheoryViewModel() : base()
        {
            Title = "Количественная оценка информации";

            for (int i = 0; i < 10; i++)
                Theory += "Оценка ";
            Theory += ".";
        }
    }
}
