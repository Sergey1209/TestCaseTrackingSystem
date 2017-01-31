using DataAccess.Initializers;

namespace DataAccess.Entities
{
    [Initializer(typeof(BacklogItemTypeInitializer))]
    public class BacklogItemType
    {
        public int ID { get; set; }
        
        public string Type { get; set; }
    }
}
