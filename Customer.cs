using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPostgreSQL
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
