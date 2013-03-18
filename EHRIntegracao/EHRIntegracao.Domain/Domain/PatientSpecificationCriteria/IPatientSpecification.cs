using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria
{
    public interface IPatientSpecificationCriteria
    {
        void AddCriteria(PatientDTO candidate, ICriteria criteria);
        bool IsSatisfiedBy(PatientDTO candidate);
        IPatientSpecificationCriteria And(IPatientSpecificationCriteria other);
    }
}
