// ****************************************************************
//  Assembly         : Millon.TecnicalTest.RealEstate.Domain
//  Author           :  Carlos Fernando Malagón Cano
//  Created          : 11-03-2024
//
//  Last Modified By : Carlos Fernando Malagón Cano
//  Last Modified On : 11-03-2024
//  ****************************************************************
//  <copyright file="Entity.cs"
//      company="Cafemaca - CAFEMACA Colombia">
//      Cafemaca - CAFEMACA Colombia
//  </copyright>
//

using Millon.TecnicalTest.RealEstate.Common.Domain.Interfaces;

namespace Millon.TecnicalTest.RealEstate.Common.Domain.Abstractions
{
    //
    // Resumen:
    //     Basic implementation of IEntity interface. An entity can inherit this class of
    //     directly implement to IEntity interface.
    //
    // Parámetros de tipo:
    //   TPrimaryKey:
    //     Type of the primary key of the entity
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
     where TPrimaryKey : IComparable, IEquatable<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }

        protected Entity()
        {
        }

        protected Entity(TPrimaryKey id)
        {
            Id = id;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Entity<TPrimaryKey> other)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetUnProxiedType(this) != GetUnProxiedType(other))
                return false;

            if (Id.Equals(default) || other.Id.Equals(default))
                return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity<TPrimaryKey> a, Entity<TPrimaryKey> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<TPrimaryKey> a, Entity<TPrimaryKey> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetUnProxiedType(this).ToString() + Id).GetHashCode();
        }

        internal static Type GetUnProxiedType(object obj)
        {
            const string EFCoreProxyPrefix = "Castle.Proxies.";
            const string NHibernateProxyPostfix = "Proxy";

            Type type = obj.GetType();
            string typeString = type.ToString();

            if (typeString.Contains(EFCoreProxyPrefix) || typeString.EndsWith(NHibernateProxyPostfix))
                return type.BaseType;

            return type;
        }
    }
}
