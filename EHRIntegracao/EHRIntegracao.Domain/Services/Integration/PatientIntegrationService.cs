using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;


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

        public IList<PatientDTO> GetAllPatients(IPatientDTO Patient,DbEnum source) 
        {
            try
            {
                PatientsDTO = GetPatientsService.GetPatientsRedis(source, Patient);
            }
            catch (Exception ex)
            {    
                throw ex;
            }

            return patientsDTO;
        }

    }
}
