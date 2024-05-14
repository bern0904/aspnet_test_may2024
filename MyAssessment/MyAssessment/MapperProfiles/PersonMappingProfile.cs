using AutoMapper;
using MyAssessment.Domain;

namespace MyAssessment.MapperProfiles
{
    /// <summary>
    /// Automapper Profile for Person
    /// </summary>
    public class PersonMappingProfile: Profile
    {
        public PersonMappingProfile() {

            CreateMap<Person, MyData.Data.Person>()
                .ReverseMap()
                .ConstructUsing(source => 
                        new Person(source.FirstName ?? string.Empty, 
                                   source.LastName  ?? string.Empty,
                                 new Address(source.Address!.Street ?? string.Empty, 
                                             source.Address!.CityOrSuburb ?? string.Empty, 
                                             source.Address!.State ?? string.Empty, 
                                             source.Address!.PostalCode ?? string.Empty )));
        }
    }
}
