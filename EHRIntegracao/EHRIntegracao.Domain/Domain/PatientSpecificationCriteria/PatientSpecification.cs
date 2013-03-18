using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services.DTO;
using NHibernate;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria
{
    public abstract class PatientSpecificationCriteria : IPatientSpecificationCriteria
    {
        public abstract void AddCriteria(PatientDTO candidate, ICriteria criteria);

        public abstract bool IsSatisfiedBy(PatientDTO candidate);

        public IPatientSpecificationCriteria And(IPatientSpecificationCriteria other)
        {
            return new AndPatientSpecification(this, other);
        }


    }
}
