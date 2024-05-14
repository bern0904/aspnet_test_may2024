using AutoMapper;
using MyAssessment.Domain;

namespace MyAssessment.MapperProfiles
{
    /// <summary>
    /// Automapper profile for Address
    /// </summary>
    public class AddressMappingProfile : Profile
    {
        public AddressMappingProfile() {

            CreateMap<Address, MyData.Data.Address>()
                .ReverseMap()
                .ConstructUsing(source => 
                        new Address(source.Street ?? string.Empty, 
                                    source.CityOrSuburb ?? string.Empty, 
                                    source.State ?? string.Empty, 
                                    source.PostalCode ?? string.Empty));
        }
    }
}
