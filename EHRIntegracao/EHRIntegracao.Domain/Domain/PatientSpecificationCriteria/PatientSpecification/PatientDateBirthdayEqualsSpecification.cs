using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services.DTO;
using NHibernate.Criterion;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification
{
    public class PatientDateBirthdayEqualsSpecification : PatientSpecificationCriteria
    {
        public override void AddCriteria(PatientDTO candidate, NHibernate.ICriteria criteria)
        {
            if (IsSatisfiedBy(candidate))
                criteria.Add(Expression.Eq("p.DateBirthday", candidate.DateBirthday));
        }

        public override bool IsSatisfiedBy(PatientDTO candidate)
        {
            return candidate.DateBirthday != null && candidate.DateBirthday > DateTime.MinValue;
        }
    }
}
