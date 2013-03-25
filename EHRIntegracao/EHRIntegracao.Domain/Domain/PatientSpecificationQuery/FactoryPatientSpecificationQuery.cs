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
        public IList<IPatientDTO> GetPatientsByQuery(IPatientDTO patient,List<IPatientDTO> patients)
        {
            return patients.Where(p => p.Name.Contains(patient.Name)).ToList();
        }
    }
}
