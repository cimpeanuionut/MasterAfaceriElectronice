using System;
using System.Collections.Generic;

#nullable disable

namespace ProiectMaster.Models.Entites
{
    public partial class Order : IEntity<int>
    {
        public Order()
        {
            OrdersProducts = new HashSet<OrdersProduct>();
        }

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual ICollection<OrdersProduct> OrdersProducts { get; set; }
    }
}
