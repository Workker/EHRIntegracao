using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Domain.Domain.PatientSpecificationQuery
{
    public class FactoryPatientSpecificationQuery
    {
        public IList<PatientDTO> GetPatientsByQuery(IPatientDTO patient,List<PatientDTO> patients)
        {
            return patients.Where(p => !string.IsNullOrEmpty( p.Name) &&  p.Name.Length >= patient.Name.Length && p.Name.Substring(0,patient.Name.Length).Contains(patient.Name)).ToList();
        }
    }
}
