using AutoMapper;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.Dtos;

namespace RequestManagementSystem
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<Priority, PriorityDto>();
            CreateMap<PriorityDto, Priority>();
            CreateMap<Request, RequestDto>();
            CreateMap<RequestDto, Request>();
            CreateMap<RequestStatus, RequestStatusDto>();
            CreateMap<RequestStatusDto, RequestStatus>();
            CreateMap<RequestType, RequestTypeDto>();
            CreateMap<RequestTypeDto, RequestType>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}
