﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _81MY_SignalROrderMan.DtoLayer.MessageDtos
{
    public class CreateMessageDto
    {
        public string NameSurname { get; set; }

        public string Mail { get; set; }

        public string Phone { get; set; }

        public string Subject { get; set; }

        public string MessageContent { get; set; }

        public DateTime MessageDate { get; set; }

        public bool Status { get; set; }
    }
}
