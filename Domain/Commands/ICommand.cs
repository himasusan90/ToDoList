using Domain.Abstractions.Aggregates;
using MediatR;
using StrongTypedId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands
{
 public interface ICommand<TAggregate, TAggregateId> : IRequest<TAggregate>, IAggregateVisitor<TAggregate, TAggregateId>
where TAggregate : IAggregate<TAggregateId>
where TAggregateId : StrongTypedGuid<TAggregateId>
    {
    }
}
