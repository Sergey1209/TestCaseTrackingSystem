using System.ComponentModel;

namespace DataAccess.Entities
{
    public enum Position
    {
        [Description("Младший")]
        Junior = 1,
        [Description("Средний")]
        Middle = 2,
        [Description("Старший")]
        Seniour = 4,
        [Description("Ведущий")]
        Lead = 8,
        [Description("Главный")]
        Cheaf = 16
    }
}
