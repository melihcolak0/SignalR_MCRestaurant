using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderManUI.DTOs.NotificationDtos
{
    public class GetNotificationDto
    {
        public int NotificationId { get; set; }

        public string Type { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool Status { get; set; }
    }
}
