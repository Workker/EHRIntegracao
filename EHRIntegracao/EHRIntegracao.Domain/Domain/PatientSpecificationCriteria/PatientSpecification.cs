using EHR.CoreShared.Interfaces;
using NHibernate;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria
{
    public abstract class PatientSpecificationCriteria : IPatientSpecificationCriteria
    {
        public abstract void AddCriteria(IPatient candidate, ICriteria criteria);

        public abstract bool IsSatisfiedBy(IPatient candidate);

        public IPatientSpecificationCriteria And(IPatientSpecificationCriteria other)
        {
            return new AndPatientSpecification(this, other);
        }
    }
}
