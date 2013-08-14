using EHR.CoreShared.Interfaces;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationIntegration
{
    public abstract class PatientSpecificationIntegration : IPatientSpecificationIntegration
    {
        public abstract bool IsSatisfiedBy(IPatient candidate);

        public IPatientSpecificationIntegration And(IPatientSpecificationIntegration other)
        {
            return new AndPatientSpecification(this, other);
        }
    }
}
