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
            CreateMap<Request, RequestDto>()
                                 .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                                 .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.Level))
                                 .ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => src.RequestType.Name))
                                 .ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src => src.RequestStatus.Name)).ReverseMap();
            CreateMap<RequestDto, Request>()
                     .ForMember(dest => dest.Category, opt => opt.MapFrom(src => new Category { Name = src.Category }))
                     .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => new Priority { Type = src.Priority }))
                     .ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => new RequestType { Name = src.RequestType }))
                     .ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src => new RequestStatus { Name = src.RequestStatus }))
                     .ForMember(dest => dest.CreatorUser, opt => opt.MapFrom(src => new User { Name = src.CreatorUser }))
                     .ForMember(dest => dest.ExecutorUser, opt => opt.MapFrom(src => new User { Name = src.ExecutorUser }));
            CreateMap<RequestStatus, RequestStatusDto>();
            CreateMap<RequestStatusDto, RequestStatus>();
            CreateMap<RequestType, RequestTypeDto>();
            CreateMap<RequestTypeDto, RequestType>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}
