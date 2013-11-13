using EHR.CoreShared.Entities;
using NHibernate.Criterion;

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
    }
}
