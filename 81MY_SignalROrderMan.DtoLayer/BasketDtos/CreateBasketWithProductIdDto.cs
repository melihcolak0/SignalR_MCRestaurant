using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.DtoLayer.BasketDtos
{
    public class CreateBasketWithProductIdDto
    {
        public int ProductId { get; set; }

        public int RestaurantTableId { get; set; }
    }
}
