using EHR.CoreShared.Interfaces;
using NHibernate.Criterion;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification
{
    public class PatientIdentityEqualsSpecification : PatientSpecificationCriteria
    {
        public override void AddCriteria(IPatient candidate, NHibernate.ICriteria criteria)
        {
            if (IsSatisfiedBy(candidate))
                criteria.Add(Expression.Eq("p.Identity", candidate.Identity));
        }

        public override bool IsSatisfiedBy(IPatient candidate)
        {
            return !string.IsNullOrEmpty(candidate.Identity);
        }
    }
}
