using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAccess.Entities;

namespace TestCaseStorage.Models.TestCases
{
    public class TestCaseListViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        public TestCaseStatus Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string AssignedTo { get; set; }
        public int BacklogItemID { get; set; }
    }

    public class TestCaseEditViewModel : TestCaseAddViewModel
    {
        public int ID { get; set; }
        public TestCaseStatus Status { get; set; }
        public DateTime DateCreated { get; set; }
        public int CreatedById { get; set; }
    }

    public class TestCaseAddViewModel
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
        [Range(1, Int32.MaxValue)]
        public int AssignedToID { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public int BacklogItemID { get; set; }
        public IEnumerable<SelectListItem> BacklogItems { get; set; }
    }
}