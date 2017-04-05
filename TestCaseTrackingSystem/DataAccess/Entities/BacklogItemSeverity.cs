using System.ComponentModel;

namespace DataAccess.Entities
{
    public enum BacklogItemSeverity
    {
        [Description("Низкий")]
        Low = 1,
        [Description("Средний")]
        Medium = 2,
        [Description("Высокий")]
        High = 4
    }
}
