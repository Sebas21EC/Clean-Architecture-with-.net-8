using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Primitives
{
    public abstract class AgregateRoot
    {
        private readonly List<DomainEvents> _domainEvents = new ();

        public ICollection<DomainEvents> GetDomainEvents() => _domainEvents;

        protected void Raise(DomainEvents domainEvent) => _domainEvents.Add(domainEvent);
    }
}
