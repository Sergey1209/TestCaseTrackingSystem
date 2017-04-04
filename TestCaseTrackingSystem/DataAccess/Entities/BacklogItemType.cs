using System.ComponentModel;

namespace DataAccess.Entities
{
    public enum BacklogItemType
    {
        [Description("Ошибка")]
        Bug = 1,
        [Description("Задача")]
        Story = 2
    }
}