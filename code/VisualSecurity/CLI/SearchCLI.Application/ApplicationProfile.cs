using AutoMapper;
using VisualSecurity.Domain.Models.Data;
using VisualSecurity.Domain.Models.Dto;

namespace SearchCLI.Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<SecurityCamera, SecurityCameraDto>();
            CreateMap<SecurityCameraDto, SecurityCamera>();
        }
    }
}
