using Domain.Abstractions.Aggregates;
using StrongTypedId;

namespace Domain.Commands
{
    public interface IAggregateVisitor<TAggregate, TAggregateId>
        where TAggregate : IAggregate<TAggregateId>
        where TAggregateId : StrongTypedGuid<TAggregateId>
    {
    }
}