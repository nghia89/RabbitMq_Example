﻿using rabbitmq_message;
using System;
using System.Collections.Generic;
using System.Text;

namespace rabbitmq_saga.stateMachine
{
    public class CardValidateEvent : ICardValidatorEvent
    {
        private readonly OrderStateData orderSagaState;
        public CardValidateEvent(OrderStateData orderStateData)
        {
            this.orderSagaState = orderStateData;
        }

        public Guid OrderId => orderSagaState.OrderId;
        public string PaymentCardNumber => orderSagaState.PaymentCardNumber;
        public string ProductName => orderSagaState.ProductName;
    }
}
