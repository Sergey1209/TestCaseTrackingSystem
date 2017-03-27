using System;
using AutoMapper;
using Services.DTO;
using TestCaseStorage.Models.Users;

namespace TestCaseStorage.Models.AutoMapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, UserViewModel>();
            CreateMap<UserViewModel, UserDto>().ForMember(t => t.CreatedDate, t => t.UseValue(DateTime.Now));
        }
    }
}