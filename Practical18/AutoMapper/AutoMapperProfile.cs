using AutoMapper;
using Practical18.Models;
using Practical18.RequestModel;

namespace Practical18.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() { 
            CreateMap<StudentModel,StudentRequestModel>().ReverseMap();
            CreateMap<StudentRequestModel,StudentModel>().ReverseMap();
        }
    }
}
