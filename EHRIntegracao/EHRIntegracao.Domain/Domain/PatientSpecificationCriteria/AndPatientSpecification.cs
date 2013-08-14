using EHR.CoreShared.Interfaces;
using NHibernate;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria
{
    public class AndPatientSpecification : PatientSpecificationCriteria
    {
        private IPatientSpecificationCriteria One;
        private IPatientSpecificationCriteria Other;

        public AndPatientSpecification(IPatientSpecificationCriteria patientA, IPatientSpecificationCriteria patientB)
        {
            One = patientA;
            Other = patientB;
        }

        public override void AddCriteria(IPatient candidate, ICriteria criteria)
        {
            One.AddCriteria(candidate, criteria);
            Other.AddCriteria(candidate, criteria);
        }

        public override bool IsSatisfiedBy(IPatient candidate)
        {
            return true;
        }
    }
}
