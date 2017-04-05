using System.ComponentModel;

namespace DataAccess.Entities
{
    public enum TestCaseStatus
    {
        [Description("Не начат")]
        NotStarted = 1,
        [Description("В процессе")]
        InProgress = 2,
        [Description("Провален")]
        Failed = 4,
        [Description("Пройден")]
        Pased = 8
    }
}
