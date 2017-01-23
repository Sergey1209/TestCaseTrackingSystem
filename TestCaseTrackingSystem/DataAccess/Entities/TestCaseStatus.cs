using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class TestCaseStatus
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
