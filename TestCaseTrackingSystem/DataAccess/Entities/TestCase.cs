using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Initializers;

namespace DataAccess.Entities
{
    [Initializer(typeof(TestCaseInitializer))]
    public class TestCase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int StatusID { get; set; }

        public int? CreatedByID { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public int? RunByID { get; set; }

        [Required]
        public int BacklogItemID { get; set; }



        [ForeignKey(nameof(StatusID))]
        public TestCaseStatus Status { get; set; }

        [ForeignKey(nameof(CreatedByID))]
        public User CreatedBy { get; set; }

        [ForeignKey(nameof(RunByID))]
        public User RunBy { get; set; }

        [ForeignKey(nameof(BacklogItemID))]
        public BacklogItem BacklogItem { get; set; }
    }
}
