using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Domain.Services
{
    public class PatientIntegrationService
    {
        private IList<PatientDTO> patientsDTO;
        public IList<PatientDTO> PatientsDTO
        {
            get { return patientsDTO ?? (patientsDTO = new List<PatientDTO>()); }
            set
            {
                patientsDTO = value;
            }
        }

        private GetPatientsService getPatientsService;
        public GetPatientsService GetPatientsService
        {
            get { return getPatientsService ?? (getPatientsService = new GetPatientsService()); }
            set
            {
                getPatientsService = value;
            }
        }

        public IList<PatientDTO> GetAllPatients(PatientDTO Patient) 
        {
            var patientQuintaDor = GetPatientsService.GetPatients(DbEnum.QuintaDor,Patient);

            var PatientCopador = GetPatientsService.GetPatients(DbEnum.CopaDor, Patient);

            ((List<PatientDTO>)patientsDTO).AddRange(patientQuintaDor);
            ((List<PatientDTO>)patientsDTO).AddRange(PatientCopador);

            return patientsDTO;
        }
    }
}
