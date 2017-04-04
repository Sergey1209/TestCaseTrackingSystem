using System.ComponentModel;

namespace DataAccess.Entities
{
    public enum UserRole
    {
        [Description("Администратор")]
        Admin = 1,
        [Description("Разработчик")]
        Developer = 2,
        [Description("Тестировщик")]
        QA = 4
    }
}
