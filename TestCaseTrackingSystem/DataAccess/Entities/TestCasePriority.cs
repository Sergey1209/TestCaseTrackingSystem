using System.ComponentModel;

namespace DataAccess.Entities
{
    public enum TestCasePriority
    {
        [Description("Низкий")]
        Low = 1,
        [Description("Средний")]
        Medium = 2,
        [Description("Высокий")]
        High = 4
    }
}
