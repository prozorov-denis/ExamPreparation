using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExamPreparation.Models
{
    public class StatisticsModel
    {
        public string Title { get; set; }

        public List<StatisticsModel> Statistics { get; set; }

        public StatisticsModel(string TopicStatistics)
        {
            this.Title = TopicStatistics;
            Statistics = new List<StatisticsModel>();
        }
    }
}
