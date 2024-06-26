﻿namespace MyData.Data
{
    /// <summary>
    /// Data model for Person
    /// </summary>
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Address? Address { get; set; }
    }
}
