using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TopicsModel
    {
        public int Topics_ID { get; set; }

        public string Title { get; set; }

        public TopicsModel() { }

        public TopicsModel(Topics topics)
        {
            Topics_ID = topics.Topics_ID;
            Title = topics.Title;
        }
    }
}
