using System;
using System.Collections.Generic;

namespace StoreFront.DATA.EF.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleInitial { get; set; }
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string Country { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
