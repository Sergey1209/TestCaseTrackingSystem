using AutoMapper;
using TestCaseStorage.Models.AutoMapper;

namespace TestCaseStorage.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<BacklogItemProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<TestCaseProfile>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}