using EHR.CoreShared.Interfaces;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationIntegration
{
    public interface IPatientSpecificationIntegration
    {
        bool IsSatisfiedBy(IPatient candidate);
        IPatientSpecificationIntegration And(IPatientSpecificationIntegration other);
    }
}
