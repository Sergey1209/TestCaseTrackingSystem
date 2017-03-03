using System.Web.Mvc;
using TestCaseStorage.Models.Binders;
using TestCaseStorage.Models.TestCases;
using WebGrease.Css.Extensions;

namespace TestCaseStorage.App_Start
{
    public static class ModelBindersConfiguration
    {
        private static readonly ModelBinderDictionary ModelBindersCollection = new ModelBinderDictionary();

        static ModelBindersConfiguration()
        {
        }

        public static void Initialize()
        {
            ModelBindersCollection.ForEach(t => ModelBinders.Binders.Add(t));
        }
    }
}