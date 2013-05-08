using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using NHibernate;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria
{
    public abstract class PatientSpecificationCriteria : IPatientSpecificationCriteria
    {
        public abstract void AddCriteria(IPatientDTO candidate, ICriteria criteria);

        public abstract bool IsSatisfiedBy(IPatientDTO candidate);

        public IPatientSpecificationCriteria And(IPatientSpecificationCriteria other)
        {
            return new AndPatientSpecification(this, other);
        }


    }
}
