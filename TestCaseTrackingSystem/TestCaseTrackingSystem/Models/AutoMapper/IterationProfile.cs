using AutoMapper;
using Services.DTO;
using TestCaseStorage.Models.Iterations;

namespace TestCaseStorage.Models.AutoMapper
{
    public class IterationProfile : Profile
    {
        public IterationProfile()
        {
            CreateMap<IterationDto, IterationViewModel>();
            CreateMap<IterationViewModel, IterationDto>();
        }
    }
}