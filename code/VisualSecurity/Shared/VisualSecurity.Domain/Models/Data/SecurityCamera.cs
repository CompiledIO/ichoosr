using CsvHelper.Configuration.Attributes;
using System;
using VisualSecurity.Utilities.Converters;

namespace VisualSecurity.Domain.Models.Data
{
    [Serializable]
    public class SecurityCamera
    {
        public string Camera { get; set; }

        [TypeConverter(typeof(CustomDecimalConverter))]
        public decimal Longitude { get; set; }

        [TypeConverter(typeof(CustomDecimalConverter))]
        public decimal Latitude { get; set; }
    }
}
