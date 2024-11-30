using System;

namespace RenterInsuranceApp.Models
{
    public class Item
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public decimal Value { get; set; }
        public string Category { get; set; }
    }
}
