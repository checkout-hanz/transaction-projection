using System.Text.Json;
using Transaction.Projection.Messaging.Publisher;
using Transaction.Projection.Messaging.Subscription;
using Microsoft.Extensions.DependencyInjection;
using Transaction.Projection.Messaging.Subscription.MerchantCreated;
using Transaction.Projection.Messaging.Subscription.TransactionCreated;

namespace Transaction.Projection.Messaging.RabbitMq
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public EventProcessor(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public void ProcessEvent(string message)
        {
            var eventType = JsonSerializer.Deserialize<GenericEvent>(message);

            var @event = (from asm in AppDomain.CurrentDomain.GetAssemblies()
                from type in asm.GetTypes()
                where type.IsClass && type.Name == eventType.EventName && typeof(IMessage).IsAssignableFrom(type)
                select type).FirstOrDefault();

            if (@event == null)
            {
                return;
            }

            using var scope = _scopeFactory.CreateScope();
            var eventData = JsonSerializer.Deserialize(message, @event);
                
            switch (eventType?.EventName)
            {
                case nameof(MerchantCreatedEvent):
                    GetHandler(scope.ServiceProvider, eventData as MerchantCreatedEvent);
                    break;
                case nameof(TransactionCreatedEvent):
                    GetHandler(scope.ServiceProvider, eventData as TransactionCreatedEvent);
                    break;
            }
        }

        private static void GetHandler<T>(IServiceProvider sp, T content) where T : IMessage?
        {
            var handler = sp.GetRequiredService<ISubscriptionHandler<T>>();
            handler.Handle(content);
        }
    }
}
