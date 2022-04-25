namespace Transaction.Projection.Messaging.Publisher
{
    public interface IPublisher<in T> where T : IEvent
    {
        Task PublishAsync(T eventToPublish);
    }
}