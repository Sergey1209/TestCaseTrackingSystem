﻿using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class BacklogItemType
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Type { get; set; }
    }
}