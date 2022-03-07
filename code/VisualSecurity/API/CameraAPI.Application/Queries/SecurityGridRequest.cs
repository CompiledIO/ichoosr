using MediatR;
using System.Collections.Generic;
using VisualSecurity.Domain.Models.Dto;

namespace SecurityCameraAPI.Application.Queries
{
    public class SecurityGridRequest : IRequest<List<SecurityCameraGridDto>>
    {
    }
}
