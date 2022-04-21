using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPostgreSQL
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string Productname { get; set; }
        public string Company { get; set; }
        public int? Productcount { get; set; }
        public decimal Price { get; set; }
        public object Orders { get; internal set; }
    }
    }
