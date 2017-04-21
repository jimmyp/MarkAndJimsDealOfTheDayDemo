using System;
using MarkAndJimsDealOfTheDay.FulfillingOrders;

namespace MarkAndJimsDealOfTheDay
{
    public class DomainOperationResult
    {
        public IEntity Entity { get; }
        public IEvent Event { get; }

        public DomainOperationResult(IEntity entity, IEvent evt)
        {
            Entity = entity;
            Event = evt;
        }
    }

    public interface IEntity
    {
    }

    public interface IEvent
    {
    }

    public interface IUow
    {
        IRepository Repository { get; set; }
        IBus Bus { get; set; }
        void Commit();
    }

    public interface IBus
    {
        void Publish(IEvent evt);
    }

    public interface IRepository
    {
        T Get<T>(Guid id);
        T Get<T>(string id);
        void Save<T>(T entity);
        T GetAll<T>();
    }


    public interface IHandle<T>
        where T : IEvent
    {
        void Handle(T evt);
    }
}
