using AutoMapper;

namespace MyAssessment.MapperProfiles
{
    /// <summary>
    /// Automapper configuration initializer
    /// </summary>
    public static class MappingProfile
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PersonMappingProfile());
                cfg.AddProfile(new BusinessMappingProfile());
                cfg.AddProfile(new AddressMappingProfile());    
            });

            return config;
        }
    }
}
