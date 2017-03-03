using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess.Entities;

namespace TestCaseStorage.Models.TestCases
{
    public class TestCaseListViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TestCaseStatus Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string RunBy { get; set; }
        public int BacklogItemID { get; set; }
    }

    public class TestCaseEditViewModel : TestCaseAddViewModel
    {
        public int CreatedByID { get; set; }
        public int? RunByID { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }

    public class TestCaseAddViewModel : TestCaseListViewModel
    {
        public IEnumerable<SelectListItem> BacklogItems { get; set; }

        public bool IsNew => ID == 0;
    }
}