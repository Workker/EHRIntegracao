using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services.DTO;
using NHibernate.Criterion;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification
{
    public class PatientIdentityEqualsSpecification : PatientSpecificationCriteria
    {
        public override void AddCriteria(PatientDTO candidate, NHibernate.ICriteria criteria)
        {
            if (IsSatisfiedBy(candidate))
                criteria.Add(Expression.Eq("p.Identity", candidate.Identity));
        }

        public override bool IsSatisfiedBy(PatientDTO candidate)
        {
            return !string.IsNullOrEmpty(candidate.Identity);
        }
    }
}
