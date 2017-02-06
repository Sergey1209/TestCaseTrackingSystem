using System.Collections.Generic;

namespace TestCaseStorage.Models.Shared
{
    public class NavigationLink
    {
        public string Link { get; }
    }

    public class NavigationMenuModel
    {
        public IEnumerable<NavigationLink> NavigationLinks { get; }
    }
}