using System.Web.Mvc;
using System.Web.Security;

namespace TestCaseStorage.Models.Binders
{
    public abstract class ViewModelBinderBase : DefaultModelBinder
    {
        protected int GetCurrentUserId(Controller controller)
        {
            return (int) Membership.GetUser(controller.User.Identity.Name).ProviderUserKey;
        }
    }
}