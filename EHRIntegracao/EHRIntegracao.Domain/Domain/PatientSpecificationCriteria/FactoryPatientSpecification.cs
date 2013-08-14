using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification;

using NHibernate;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria
{
    public class FactoryPatientSpecification
    {
        public static void CreateCriteria(IPatient patient, ICriteria criteria)
        {
            var nameEqualsSpecification = new PatientNameEqualsSpecification();
            var dateBirthayEqualsSpecification = new PatientDateBirthdayEqualsSpecification();
            var identityEquals = new PatientIdentityEqualsSpecification();

            nameEqualsSpecification
                .And(dateBirthayEqualsSpecification)
                .And(identityEquals)
                .AddCriteria(patient, criteria);
        }
    }
}
