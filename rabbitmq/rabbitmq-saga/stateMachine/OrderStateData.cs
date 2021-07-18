﻿using Automatonymous;
using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_saga.stateMachine
{
    public class OrderStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string CurrentState { get; set; }
        public DateTime? OrderCreationDateTime { get; set; }
        public DateTime? OrderCancelDateTime { get; set; }
        public Guid OrderId { get; set; }
        public string PaymentCardNumber { get; set; }
        public string ProductName { get; set; }
    }
}
