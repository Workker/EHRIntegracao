using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using NHibernate.Criterion;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria;


namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification
{
    public class PatientNameEqualsSpecification : PatientSpecificationCriteria
    {
        public override void AddCriteria(IPatientDTO candidate, NHibernate.ICriteria criteria)
        {
            if (IsSatisfiedBy(candidate))
                criteria.Add(Expression.Eq("p.Name", candidate.Name));
        }

        public override bool IsSatisfiedBy(IPatientDTO candidate)
        {
            return !string.IsNullOrEmpty(candidate.Name);
        }
    }
}
