using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services.DTO;
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

        public override void AddCriteria(PatientDTO candidate, ICriteria criteria)
        {
            One.AddCriteria(candidate, criteria);
            Other.AddCriteria(candidate, criteria);
        }

        public override bool IsSatisfiedBy(PatientDTO candidate)
        {
            return true;
        }
    }
}
