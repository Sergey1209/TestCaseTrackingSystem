﻿using System;
using DataAccess.Initializers;

namespace DataAccess.Entities
{
    [Initializer(typeof(TestCaseInitializer))]
    public class TestCase
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public TestCaseStatus Status { get; set; }
        public TestCasePriority Priority { get; set; }
        public int CreatedByID { get; set; }
        public DateTime DateCreated { get; set; }
        public int AssignedToID { get; set; }
        public int BacklogItemID { get; set; }

        
        public User CreatedBy { get; set; }
        public User AssignedTo { get; set; }
        public BacklogItem BacklogItem { get; set; }
    }
}
