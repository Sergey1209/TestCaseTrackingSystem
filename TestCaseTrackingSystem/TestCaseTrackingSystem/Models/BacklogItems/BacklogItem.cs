using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAccess.Entities;

namespace TestCaseStorage.Models.BacklogItems
{
    public class BacklogItemViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Range(1, int.MaxValue)]
        public BacklogItemType Type { get; set; }
        public string Iteration { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
        public string AssignedTo { get; set; }
    }

    public class BacklogItemEditModel : BacklogItemViewModel
    {
        public IEnumerable<SelectListItem> Iterations { get; set; }
        public int IterationId { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public int AssignedToUserId { get; set; }
        public int UserCreatedId { get; set; }

        public bool IsNew => ID == 0;
    }
}