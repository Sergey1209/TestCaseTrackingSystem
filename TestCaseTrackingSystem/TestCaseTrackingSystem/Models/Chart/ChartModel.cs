using System.Collections.Generic;

namespace TestCaseStorage.Models.Chart
{
    public class ChartModel
    {
        public string YLabel { get; set; }
        public string Guid { get; set; }
        public ChartType Type { get; set; }
        public string Labels { get; set; }
        public string Values { get; set; }
    }
}