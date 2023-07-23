using System;
using System.Collections.Generic;

namespace Server.Models
{
    public partial class Member
    {
        public Member()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
        }

        public int MemberId { get; set; }
        public string? Email { get; set; }
        public string? CompanyName { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
