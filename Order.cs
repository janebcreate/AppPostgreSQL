using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPostgreSQL
{
    public partial class Order
    {
        public int Id { get; set; }
        public int Productid { get; set; }
        public int Customerid { get; set; }
        public DateTime Createdat { get; set; }
        public int? Productcount { get; set; }
        public decimal Price { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

}
