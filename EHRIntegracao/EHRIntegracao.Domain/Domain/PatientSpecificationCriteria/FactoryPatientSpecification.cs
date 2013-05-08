using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria.PatientSpecification;

using NHibernate;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria
{
    public class FactoryPatientSpecification
    {
        public static void CreateCriteria(IPatientDTO patient, ICriteria criteria) 
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
