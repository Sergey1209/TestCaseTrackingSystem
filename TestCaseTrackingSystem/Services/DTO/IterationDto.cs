using System;
using Services.Interfaces;

namespace Services.DTO
{
    public class IterationDto : IDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
