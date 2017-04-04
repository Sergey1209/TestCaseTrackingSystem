using System;
using DataAccess.Entities;
using Services.Interfaces;

namespace Services.DTO
{
    public class BacklogItemDto : IDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BacklogItemType Type { get; set; }
        public int? AssignedToUserID { get; set; }
        public string AssignedTo { get; set; }
        public int UserCreatedID { get; set; }
        public string UserCreated { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
