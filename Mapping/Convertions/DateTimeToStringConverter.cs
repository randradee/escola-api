using AutoMapper;

namespace EscolaApi.Mapping.Convertions
{
    public class DateTimeToStringConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return source.ToString("dd/MM/yyyy");
        }
    }
}
