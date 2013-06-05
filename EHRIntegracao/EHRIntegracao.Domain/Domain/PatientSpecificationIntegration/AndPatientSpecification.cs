using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;

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

        public override bool IsSatisfiedBy(IPatientDTO candidate)
        {
            return One.IsSatisfiedBy(candidate) && Other.IsSatisfiedBy(candidate);
        }
    }
}
