using Transaction.Projection.Messaging.RabbitMq;
using Transaction.Projection.Messaging.Subscription;
using Transaction.Projection.Messaging.Subscription.MerchantCreated;
using Transaction.Projection.Messaging.Subscription.TransactionCreated;

namespace Transaction.Projection.Configuration
{
    public static class MessagingConfiguration
    {
        public static IServiceCollection AddMessaging(this IServiceCollection services, IConfiguration configuration)
        {
            var host = configuration["RabbitMQHost"];
            var port = int.Parse(configuration["RabbitMQPort"]);
            services.AddSingleton<IRabbitMQConfig>(_ => new RabbitMQConfig(host, port));
            services.AddSingleton<IEventProcessor, EventProcessor>();
            services.AddSingleton<IMessageBusClient, MessageBusClient>();
            services.AddHostedService<MessageBusSubscriber>();
            services.AddSingleton<ISubscriptionHandler<MerchantCreatedEvent>, MerchantCreatedHandler>();
            services.AddSingleton<ISubscriptionHandler<TransactionCreatedEvent>, TransactionCreatedHandler>();
            return services;
        }
    }
}
