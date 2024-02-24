using StrongTypedId;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObjects
{
    public sealed class TodoId : StrongTypedGuid<TodoId>
    {
        public TodoId(Guid primitiveId) : base(primitiveId)
        {
        }
    }

}
