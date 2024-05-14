using System.Xml.Serialization;

namespace MyAssessment.Domain
{
    /// <summary>
    /// Domain model for Address
    /// </summary>
    public class Address: IEquatable<Address>
    {
        public string Street { get;  }
        public string CityOrSuburb { get;  }
        public string State { get;  }
        public string PostalCode { get;  }

        public Address(string street, string cityOrSuburb, string state, string postalCode)
        {
            Street = street;
            CityOrSuburb = cityOrSuburb;
            State = state;
            PostalCode = postalCode;
        }

        public bool Equals(Address? other)
        {
            return (other != null &&
                    this.Street == other.Street &&
                    this.CityOrSuburb == other.CityOrSuburb &&
                    this.State == other.State &&
                    this.PostalCode == other.PostalCode);
        }
    }
}