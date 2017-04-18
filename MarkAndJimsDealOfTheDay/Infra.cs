using System;

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
        void Save<T>(T entity);
    }


    public interface IHandle<T>
    {
        void Handle(T evt);
    }
}
