using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataAccess.Entities;

namespace TestCaseStorage.Models.BacklogItems
{
    public class BacklogItemViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BacklogItemTypeEnum Type { get; set; }
        public string BelongsToIteration { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
        public string AssignedToUser { get; set; }
    }

    public class BacklogItemEditModel : BacklogItemViewModel
    {
        public IEnumerable<SelectListItem> Iterations { get; set; }
        public int BelongsToIterationId { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public int AssignedToUserId { get; set; }
    }

    public class BacklogItem
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BacklogItemTypeEnum Type { get; set; }
        public IEnumerable<SelectListItem> Iterations { get; set; }
        public string BelongsToIteration { get; set; }
        public int BelongsToIterationId { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public string AssignedToUser { get; set; }
        public int AssignedToUserId { get; set; }
    }
}