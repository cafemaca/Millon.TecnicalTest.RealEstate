// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 01-07-2024 
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 01-07-2024
//  ****************************************************************
//  <copyright file="AggregateRoot.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces;

namespace Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions
{
    public abstract class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>
     where TPrimaryKey : IComparable, IEquatable<TPrimaryKey>
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();
        public virtual IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;

        protected virtual void AddDomainEvent(IDomainEvent newEvent)
        {
            _domainEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            _domainEvents.Clear();
        }
    }
}
