using AutoMapper;

namespace MyAssessment.Services
{
    /// <summary>
    /// Service class to explicitly map Domain models to Data models and vice versa
    /// </summary>
    public static class MapperService
    {
        public static object Map(IMapper mapper, object source)
        {
            if (source.GetType() == typeof(Domain.Person))
                return mapper.Map<MyData.Data.Person>(source);

            else if (source.GetType() == typeof(MyData.Data.Person))
                return mapper.Map<Domain.Person>(source);

            else if (source.GetType() == typeof(Domain.Business))
                return mapper.Map<MyData.Data.Business>(source);

            else if (source.GetType() == typeof(MyData.Data.Business))
                return mapper.Map<Domain.Business>(source);

            else
                return source;
        }
    }
}
