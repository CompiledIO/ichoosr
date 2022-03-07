using MediatR;
using SearchCLI.Application.Queries;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VisualSecurity.Domain.Mappers;
using VisualSecurity.Domain.Models.Data;
using VisualSecurity.Domain.Models.Dto;
using VisualSecurity.Infrastructure.Csv.Interfaces.Services;

namespace SearchCLI.Application.Handlers
{
    public class SearchCameraByNameHandler : IRequestHandler<NameQuery, string>
    {
        private readonly IReadDataService<SecurityCamera, SecurityCameraDto, SecurityCameraDtoMap> _readDataService;

        public SearchCameraByNameHandler(IReadDataService<SecurityCamera, SecurityCameraDto, SecurityCameraDtoMap> readDataService)
        {
            _readDataService = readDataService;
        }

        public Task<string> Handle(NameQuery request, CancellationToken cancellationToken)
        {
            //This path should be passed in by using the options pattern for IConfiguration
            var dataList = _readDataService.ReadData("../../../../../../../data/cameras-defb.csv");

            //list.Sort();
            var results = dataList.Where(model => model.Camera.Contains(request.Name)).ToList();

            var stringBuilder = new StringBuilder();
            foreach (var result in results)
            {
                stringBuilder.AppendLine($"{result.Id} | {result.Camera} | {result.Latitude} | {result.Longitude}");
            }

            return Task.FromResult(stringBuilder.ToString());
        }
    }
}
