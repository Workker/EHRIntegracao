using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationIntegration
{
    public interface IPatientSpecificationIntegration
    {
        bool IsSatisfiedBy(IPatientDTO candidate);
        IPatientSpecificationIntegration And(IPatientSpecificationIntegration other);
    }
}
