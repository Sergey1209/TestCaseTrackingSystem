using System;
using System.Collections.Generic;
using DataAccess.Initializers;

namespace DataAccess.Entities
{
    [Initializer(typeof(IterationInitializer))]
    public class Iteration
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
        
        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set; }

        public ICollection<BacklogItem> BacklogItems { get; set; }

        public Iteration()
        {
            BacklogItems = new List<BacklogItem>();
        }
    }
}
