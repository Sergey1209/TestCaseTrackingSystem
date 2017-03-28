using System;
using AutoMapper;
using Services.DTO;
using TestCaseStorage.Models.BacklogItems;

namespace TestCaseStorage.Models.AutoMapper
{
    public class BacklogItemProfile : Profile
    {
        public BacklogItemProfile()
        {
            CreateMap<BacklogItemDto, BacklogItemViewModel>();
            CreateMap<BacklogItemDto, BacklogItemEditModel>()
                .ForMember(t => t.Iterations, t => t.Ignore())
                .ForMember(t => t.Users, t => t.Ignore());
            CreateMap<BacklogItemEditModel, BacklogItemDto>()
                .ForMember(t => t.DateCreated, t => t.UseValue(DateTime.Now));
        }
    }
}