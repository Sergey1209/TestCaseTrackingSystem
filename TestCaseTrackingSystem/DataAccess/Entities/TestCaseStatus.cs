using DataAccess.Initializers;

namespace DataAccess.Entities
{
    [Initializer(typeof(TestCaseStatusInitializer))]
    public class TestCaseStatus
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
    }
}
