using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradingBot.Models
{
   
        public class TopScoringIntent
        {
            public string intent { get; set; }
            public double score { get; set; }
        }

        public class Intent
        {
            public string intent { get; set; }
            public double score { get; set; }
        }

        public class Resolution
        {
            public string value { get; set; }
        }

        public class Entity
        {
            public string entity { get; set; }
            public string type { get; set; }
            public int startIndex { get; set; }
            public int endIndex { get; set; }
            public double score { get; set; }
            public Resolution resolution { get; set; }
        }

        public class Example
        {
            public string query { get; set; }
            public TopScoringIntent topScoringIntent { get; set; }
            public IList<Intent> intents { get; set; }
            public IList<Entity> entities { get; set; }
        }

    
}
