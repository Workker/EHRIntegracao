using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationIntegration
{
    public class PatientSpecificationIsGreater : PatientSpecificationIntegration
    {
        public override bool IsSatisfiedBy(EHR.CoreShared.IPatientDTO candidate)
        {
            return (candidate.DateBirthday.HasValue && (DateTime.Today.Year - candidate.DateBirthday.Value.Year) >= 18);
        }
    }
}
