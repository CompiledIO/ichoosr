using MediatR;
using System.Collections.Generic;
using VisualSecurity.Domain.Models.Dto;

namespace SearchCLI.Application.Queries
{
    public class NameQuery : IRequest<string>
    {
        public string Name { get; set; }

        public NameQuery(string name)
        {
            Name = name;
        }
    }
}
