﻿
using MassTransit;
using MassTransit.RabbitMqTransport;
using rabbitmq_message;
using System;

namespace rabbitmq_message
{
    public class RabbitMqBus
    {
        public static IBusControl ConfigureBus(IServiceProvider provider, Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost>
         registrationAction = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri(BusConstants.RabbitMqUri), hst =>
                {
                    hst.Username(BusConstants.UserName);
                    hst.Password(BusConstants.Password);
                });

                cfg.ConfigureEndpoints((IRegistration)provider);

                registrationAction?.Invoke(cfg, host);
            });
        }
    }
}
