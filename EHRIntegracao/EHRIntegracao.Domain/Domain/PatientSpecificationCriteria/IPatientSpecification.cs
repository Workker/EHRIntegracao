using EHR.CoreShared.Interfaces;
using NHibernate;


namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria
{
    public interface IPatientSpecificationCriteria
    {
        void AddCriteria(IPatient candidate, ICriteria criteria);
        bool IsSatisfiedBy(IPatient candidate);
        IPatientSpecificationCriteria And(IPatientSpecificationCriteria other);
    }
}
