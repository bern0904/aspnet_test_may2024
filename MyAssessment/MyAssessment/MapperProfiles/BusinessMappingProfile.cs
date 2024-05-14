using AutoMapper;
using MyAssessment.Domain;

namespace MyAssessment.MapperProfiles
{
    /// <summary>
    /// Automapper Profile for Business
    /// </summary>
    public class BusinessMappingProfile: Profile
    {
        public BusinessMappingProfile() {

            CreateMap<Business, MyData.Data.Business>()                
                    .ReverseMap()
                    .ConstructUsing(source =>
                        new Business(source.Name ?? string.Empty,
                            new Address(source.Address!.Street ?? string.Empty, 
                                        source.Address!.CityOrSuburb ?? string.Empty, 
                                        source.Address!.State ?? string.Empty, 
                                        source.Address!.PostalCode ?? string.Empty)));
        }
    }
}
