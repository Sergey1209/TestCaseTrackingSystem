using System;
using System.Collections.Generic;
using DataAccess.Initializers;

namespace DataAccess.Entities
{
    [Initializer(typeof(BacklogItemInitializer))]
    public class BacklogItem
    {
        public int ID { get; set; }
        
        public int TypeID { get; set; }
        
        public string Title { get; set; }

        public string Description { get; set; }

        public int? IterationID { get; set; }
        
        public int CreatedByID { get; set; }
        
        public DateTime DateCreated { get; set; }

        public int? AssignedToID { get; set; }

        
        public BacklogItemType Type { get; set; }
        
        public Iteration Iteration { get; set; }
        
        public User CreatedBy { get; set; }
        
        public User AssignedTo { get; set; }

        public ICollection<TestCase> TestCases { get; set; }

        public BacklogItem()
        {
            TestCases = new List<TestCase>();
        }
    }
}
