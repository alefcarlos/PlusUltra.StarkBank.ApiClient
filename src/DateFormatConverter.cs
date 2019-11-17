using Newtonsoft.Json.Converters;

namespace PlusUltra.StarkBank.ApiClient
{
    public class DateFormatConverter : IsoDateTimeConverter
    {
        public DateFormatConverter(string format)
        {
            DateTimeFormat = format;
        }
    }
}
