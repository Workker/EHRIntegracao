using EHR.CoreShared.Interfaces;
using NHibernate.Criterion;
using System;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification
{
    public class PatientDateBirthdayEqualsSpecification : PatientSpecificationCriteria
    {
        public override void AddCriteria(IPatient candidate, NHibernate.ICriteria criteria)
        {
            if (IsSatisfiedBy(candidate))
                criteria.Add(Restrictions.Eq("p.DateBirthday", candidate.DateBirthday));
        }

        public override bool IsSatisfiedBy(IPatient candidate)
        {
            return candidate.DateBirthday != null && candidate.DateBirthday > DateTime.MinValue;
        }
    }
}
