using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EHR.CoreShared;
using NHibernate;
using System.Threading.Tasks;


namespace EHRIntegracao.Domain.Domain.PatientSpecificationCriteria
{
    public interface IPatientSpecificationCriteria
    {
        void AddCriteria(IPatientDTO candidate, ICriteria criteria);
        bool IsSatisfiedBy(IPatientDTO candidate);
        IPatientSpecificationCriteria And(IPatientSpecificationCriteria other);
    }
}
