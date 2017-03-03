using AutoMapper;
using Services.DTO;
using TestCaseStorage.Models.TestCases;

namespace TestCaseStorage.Models.AutoMapper
{
    public class TestCaseProfile : Profile
    {
        public TestCaseProfile()
        {
            CreateMap<TestCaseDto, TestCaseListViewModel>();
            CreateMap<TestCaseDto, TestCaseEditViewModel>()
                .ForMember(t => t.BacklogItems, t => t.Ignore())
                .ForMember(t => t.Users, t => t.Ignore());
            CreateMap<TestCaseEditViewModel, TestCaseDto>();
        }
    }
}