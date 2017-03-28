using System;
using AutoMapper;
using Services.DTO;
using TestCaseStorage.Models.Login;
using TestCaseStorage.Models.Users;

namespace TestCaseStorage.Models.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserViewModel>()
                .ForMember(t => t.ErrorMessages, t => t.Ignore());
            CreateMap<UserViewModel, UserDto>()
                .ForMember(t => t.CreatedDate, t => t.UseValue(DateTime.Now));
            CreateMap<RegisterViewModel, UserDto>()
                .ForMember(t => t.CreatedDate, t => t.UseValue(DateTime.Now))
                .ForMember(t => t.ID, t => t.Ignore())
                .ForMember(t => t.LastLogin, t => t.Ignore());
        }
    }
}