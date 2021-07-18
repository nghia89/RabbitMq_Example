﻿using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_message
{
    public interface IOrderStartEvent
    {
        public Guid OrderId { get; }
        public string PaymentCardNumber { get; }
        public string ProductName { get; }
    }
}
