namespace MyAssessment.Domain
{
    /// <summary>
    /// Domain model for Person
    /// </summary>
    public class Person: DomainModel, IEquatable<Person>
    {
        public string? FirstName { get;  }
        public string? LastName { get;  }
        public Address? Address { get;  }

        /// <summary>
        /// Constructor for creating empty Person
        /// </summary>
        public Person() { }

        public Person(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public static Person? Find(int? id)
        {
            var person = new Person();
            return person.Find<Person>(id ?? 0, person);
        }

        public bool Equals(Person? other)
        {
            return (other != null &&
                    this.FirstName == other.FirstName &&
                    this.LastName == other.LastName &&
                    this.Address == other.Address);
        }
    }
}
