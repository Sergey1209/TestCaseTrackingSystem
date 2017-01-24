using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class BacklogItem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int TypeID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public int? IterationID { get; set; }

        [Required]
        public int CreatedByID { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public int? AssignedToID { get; set; }


        [ForeignKey(nameof(TypeID))]
        public BacklogItemType Type { get; set; }

        [ForeignKey(nameof(IterationID))]
        public Iteration Iteration { get; set; }

        [ForeignKey(nameof(CreatedByID))]
        public User CreatedBy { get; set; }

        [ForeignKey(nameof(AssignedToID))]
        public User AssignedTo { get; set; }

        public ICollection<TestCase> TestCases { get; set; }

        public BacklogItem()
        {
            TestCases = new List<TestCase>();
        }
    }
}
