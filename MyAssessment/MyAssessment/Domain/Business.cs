namespace MyAssessment.Domain
{
    /// <summary>
    /// Domain model for Business
    /// </summary>
    public class Business: DomainModel, IEquatable<Business>
    {
        public string? Name { get;  }
        public Address? Address { get; }

        /// <summary>
        /// Constructor for creating empty Business
        /// </summary>
        public Business() { }

        public Business(string name, Address businessAddress)
        {
            Name = name;
            Address = businessAddress;
        }

        public static Business? Find(int? id)
        {
            var biz = new Business();
            return biz.Find<Business>(id ?? 0, biz);
        }

        public bool Equals(Business? other)
        {
            return (other != null &&
                   this.Name == other.Name &&
                   this.Address == other.Address);
        }
    }
}
