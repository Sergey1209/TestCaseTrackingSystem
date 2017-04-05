using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAccess.Entities;
using TestCaseStorage.Infrastructure.Extensions;

namespace TestCaseStorage.Models.BacklogItems
{
    public class BacklogItemViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Range(1, 2)]
        public BacklogItemType Type { get; set; }
        [Range(1, 4)]
        public BacklogItemPriority Priority { get; set; }
        [Range(1, 4)]
        public BacklogItemSeverity Severity { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
        [Required]
        public string AssignedTo { get; set; }
    }

    public class BacklogItemEditModel : BacklogItemViewModel
    {
        public IEnumerable<SelectListItem> Users { get; set; }
        public int AssignedToUserId { get; set; }
        public int UserCreatedId { get; set; }
    }
}