using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.EntityLayer.Entities
{
    public class Basket
    {
        public int BasketId { get; set; }        

        public decimal Price { get; set; }

        public int Count { get; set; }

        public decimal TotalPrice { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int RestaurantTableId { get; set; }
        public RestaurantTable RestaurantTable { get; set; }
    }
}
