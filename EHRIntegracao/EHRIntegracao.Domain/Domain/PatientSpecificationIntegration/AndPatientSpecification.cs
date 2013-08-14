using EHR.CoreShared.Interfaces;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationIntegration
{
    public class AndPatientSpecification : PatientSpecificationIntegration
    {
        private IPatientSpecificationIntegration One;
        private IPatientSpecificationIntegration Other;

        public AndPatientSpecification(IPatientSpecificationIntegration patientA, IPatientSpecificationIntegration patientB)
        {
            One = patientA;
            Other = patientB;
        }

        public override bool IsSatisfiedBy(IPatient candidate)
        {
            return One.IsSatisfiedBy(candidate) && Other.IsSatisfiedBy(candidate);
        }
    }
}
