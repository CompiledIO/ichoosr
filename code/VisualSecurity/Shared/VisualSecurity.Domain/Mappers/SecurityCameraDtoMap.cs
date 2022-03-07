using CsvHelper.Configuration;
using VisualSecurity.Domain.Models.Dto;

namespace VisualSecurity.Domain.Mappers
{
    public class SecurityCameraDtoMap : ClassMap<SecurityCameraDto>
    {
        public SecurityCameraDtoMap()
        {
            Map(m => m.Camera);
            Map(m => m.Longitude);
            Map(m => m.Latitude);
        }
    }
}
