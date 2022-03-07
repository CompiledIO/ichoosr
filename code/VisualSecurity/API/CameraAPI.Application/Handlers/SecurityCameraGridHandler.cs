using MediatR;
using SecurityCameraAPI.Application.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VisualSecurity.Domain.Mappers;
using VisualSecurity.Domain.Models.Data;
using VisualSecurity.Domain.Models.Dto;
using VisualSecurity.Infrastructure.Csv.Interfaces.Services;

namespace SecurityCameraAPI.Application.Handlers
{
    public class SecurityCameraGridHandler : IRequestHandler<SecurityGridRequest, List<SecurityCameraGridDto>>
    {
        private readonly IReadDataService<SecurityCamera, SecurityCameraDto, SecurityCameraDtoMap> _readDataService;

        public SecurityCameraGridHandler(IReadDataService<SecurityCamera, SecurityCameraDto, SecurityCameraDtoMap> readDataService)
        {
            _readDataService = readDataService;
        }

        public Task<List<SecurityCameraGridDto>> Handle(SecurityGridRequest request, CancellationToken cancellationToken)
        {
            //This path should be passed in by using the options pattern for IConfiguration
            var dataList = _readDataService.ReadData("../../../../data/cameras-defb.csv");
            var results = new List<SecurityCameraGridDto>();

            foreach (var model in dataList)
            {
                results.Add(new SecurityCameraGridDto
                {
                    GridNumber = DeterimineGridNumber(model.Id),
                    SecurityCamera = model
                });
            }

            return Task.FromResult(results);
        }

        private int DeterimineGridNumber(int id)
        {
            if(id % 3 == 0 && id % 5 == 0)
                return 3;

            if (id % 3 == 0)
                return 1;

            if (id % 5 == 0)
                return 2;

            return 4;
        }
    }
}
