using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.DtoLayer.OrderDtos
{
    public class CreateOrderDto
    {
        public string TableNumber { get; set; }

        public string Description { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
