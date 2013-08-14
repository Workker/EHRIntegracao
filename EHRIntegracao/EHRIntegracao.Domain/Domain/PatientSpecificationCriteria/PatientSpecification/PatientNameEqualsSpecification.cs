using EHR.CoreShared.Interfaces;
using NHibernate.Criterion;


namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification
{
    public class PatientNameEqualsSpecification : PatientSpecificationCriteria
    {
        public override void AddCriteria(IPatient candidate, NHibernate.ICriteria criteria)
        {
            if (IsSatisfiedBy(candidate))
                criteria.Add(Expression.Like("p.Name", candidate.Name, MatchMode.Anywhere));
        }

        public override bool IsSatisfiedBy(IPatient candidate)
        {
            return !string.IsNullOrEmpty(candidate.Name);
        }
    }
}
