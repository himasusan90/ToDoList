using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Queries
{
    public interface IQuery<TResult> : IRequest<TResult>
    {
    }

}
