using EHR.CoreShared.Entities;
using FluentNHibernate.Mapping;

namespace EHRIntegracao.Domain.Mapping
{
    public abstract class ValueObjectMap<T> : ClassMap<T> where T : ValueObject
    {
        protected ValueObjectMap()
        {
            Id(x => x.Id);
            Map(x => x.Description);
        }
    }
}
