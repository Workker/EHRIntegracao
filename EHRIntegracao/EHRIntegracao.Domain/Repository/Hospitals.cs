using EHR.CoreShared.Entities;
using NHibernate;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Repository
{
    public class Hospitals : EHRRepository
    {
        public Hospital GetBy(string key)
        {
            var criterio = Session.CreateCriteria<Hospital>();
            criterio.Add(Restrictions.Eq("Key", key));

            return criterio.UniqueResult<Hospital>();
        }

        public IList<Hospital> GetAllCached()
        {
            return Session.CreateCriteria(typeof(Hospital))
                    .SetCacheable(true)
                    .SetCacheRegion("Hospitals")
                    .SetCacheMode(CacheMode.Normal)
                    .AddOrder(Order.Asc("Id"))
                    .List<Hospital>();
        }
    }
}
