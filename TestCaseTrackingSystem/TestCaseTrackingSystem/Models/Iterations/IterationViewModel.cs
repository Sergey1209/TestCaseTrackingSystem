using System;
using System.ComponentModel.DataAnnotations;

namespace TestCaseStorage.Models.Iterations
{
    public class IterationViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public bool IsNew => ID == 0;
    }
}