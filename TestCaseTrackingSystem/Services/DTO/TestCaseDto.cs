using System;
using DataAccess.Entities;
using Services.Interfaces;

namespace Services.DTO
{
    public class TestCaseDto : IDto
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Tag { get; set; }

        public TestCaseStatus Status { get; set; }

        public int CreatedByID { get; set; }

        public string CreatedBy { get; set; }

        public DateTime DateCreated { get; set; }

        public int AssignedToID { get; set; }

        public string AssignedTo { get; set; }

        public int BacklogItemID { get; set; }
    }
}
