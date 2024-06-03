using AutoMapper;
using System.Globalization;

namespace EscolaApi.Mapping.Convertions
{
    public class StringToDateTimeConverter : ITypeConverter<string, DateTime>
    {
        public DateTime Convert(string source, DateTime destination, ResolutionContext context)
        {
            if (DateTime.TryParseExact(source, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return DateTime.SpecifyKind(date, DateTimeKind.Utc);
            }
            throw new FormatException("Formato de data inválido. O formato deve ser dd/MM/yyyy");
        }
    }
}
