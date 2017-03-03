using System;

namespace TestCaseStorage.Models.Iterations
{
    public class IterationViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public bool IsNew => ID == 0;
    }
}