using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace VisualSecurity.Utilities.Converters
{
    public class CustomDecimalConverter : DecimalConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.GetCultureInfo("en-US"), out var result))
            {
                return result;
            }
            else
            {
                return decimal.Zero;
            }
        }
    }
}
