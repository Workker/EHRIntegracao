using EHR.CoreShared.Interfaces;
using System;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationIntegration
{
    public class PatientSpecificationIsGreater : PatientSpecificationIntegration
    {
        public override bool IsSatisfiedBy(IPatient candidate)
        {
            return (candidate.DateBirthday.HasValue && (DateTime.Today.Year - candidate.DateBirthday.Value.Year) >= 18);
        }
    }
}
