using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationIntegration
{
    public abstract class PatientSpecificationIntegration : IPatientSpecificationIntegration
    {
        public abstract bool IsSatisfiedBy(IPatientDTO candidate);

        public IPatientSpecificationIntegration And(IPatientSpecificationIntegration other)
        {
            return new AndPatientSpecification(this, other);
        }
    }
}
