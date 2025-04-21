using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.EntityLayer.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public int RestaurantTableId { get; set; }
        public RestaurantTable RestaurantTable { get; set; }

        public string Description { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
