using System.Collections.Generic;

namespace VisualSecurity.Infrastructure.Csv.Interfaces.Services
{
    public interface IReadDataService<T, T1, T2>
    {
        List<T1> ReadData(string path);
    }
}
