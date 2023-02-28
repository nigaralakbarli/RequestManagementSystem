using AutoMapper;
using RequestManagementSystem.Data.Models;
using RequestManagementSystem.Dtos.Request;
using RequestManagementSystem.Dtos.Response;

namespace RequestManagementSystem
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<CategoryRequestDto, Category>();

            CreateMap<Department, DepartmentResponseDto>();
            CreateMap<DepartmentRequestDto, Department>();

            CreateMap<Priority, PriorityResponseDto>();
            CreateMap<PriorityRequestDto, Priority>();

            CreateMap<Request, RequestResponseDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.Level))
            .ForMember(dest => dest.RequestType, opt => opt.MapFrom(src => src.RequestType.Name))
            .ForMember(dest => dest.RequestStatus, opt => opt.MapFrom(src => src.RequestStatus.Name))
            .ForMember(dest => dest.CreateUser, opt => opt.MapFrom(src => src.CreateUser.Name))
            .ForMember(dest => dest.ExecutorUser, opt => opt.MapFrom(src => src.ExecutorUser.Name));
            CreateMap<RequestRequestDto, Request>();

            CreateMap<RequestStatus, RequestStatusResponseDto>();
            CreateMap<RequestStatusRequestDto, RequestStatus>();

            CreateMap<RequestType, RequestTypeResponseDto>();
            CreateMap<RequestTypeRequestDto, RequestType>();

            CreateMap<User, UserResponseDto>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<UserRequestDto, User>();
        }
    }
}
