using System;
using AutoMapper;
using DataAccess.Entities;
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
                .ForMember(t => t.BacklogItems, t => t.Ignore());
            CreateMap<TestCaseEditViewModel, TestCaseDto>()
                .ForMember(t => t.CreatedBy, t => t.Ignore())
                .ForMember(t => t.RunBy, t => t.Ignore())
                .ForMember(t => t.RunByID, t => t.Ignore());
            CreateMap<TestCaseAddViewModel, TestCaseDto>()
                .ForMember(t => t.Status, t => t.UseValue(TestCaseStatus.NotStarted))
                .ForMember(t => t.DateCreated, t => t.UseValue(DateTime.Now))
                .ForMember(t => t.ID, t => t.Ignore())
                .ForMember(t => t.CreatedBy, t => t.Ignore())
                .ForMember(t => t.CreatedByID, t => t.Ignore())
                .ForMember(t => t.RunBy, t => t.Ignore())
                .ForMember(t => t.RunByID, t => t.Ignore());
        }
    }
}