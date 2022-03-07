using AutoMapper;
using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using VisualSecurity.Infrastructure.Csv.Interfaces.Services;

namespace VisualSecurity.Infrastructure.Csv.Services
{
    public class ReadDataService<T, T1, T2> : IReadDataService<T, T1, T2> where T2 : ClassMap
    {
        private readonly CsvConfiguration _configuration;
        private readonly IMapper _mapper;

        public ReadDataService(IMapper mapper)
        {
            _mapper = mapper;

            // Ideally get config from appsettings
            _configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ";"                
            };
        }

        public List<T1> ReadData(string path)
        {
            var processedList = new List<T>();

            using (var stream = new StreamReader(path))
            {
                using var csvReader = new CsvReader(stream, _configuration);
                {
                    csvReader.Context.RegisterClassMap<T2>();
                    while (csvReader.Read())
                    {
                        try
                        {
                            processedList.Add(csvReader.GetRecord<T>());
                        }
                        catch (Exception ex)
                        {
                            //Logger.LogError(ex)
                        }
                    }
                }
            }

            return _mapper.Map<List<T1>>(processedList);
        }
    }
}
