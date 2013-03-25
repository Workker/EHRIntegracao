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
        private IList<IPatientDTO> patientsDTO;
        public IList<IPatientDTO> PatientsDTO
        {
            get { return patientsDTO ?? (patientsDTO = new List<IPatientDTO>()); }
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

        public IList<IPatientDTO> GetAllPatients(IPatientDTO Patient,DbEnum source) 
        {
            try
            {
                PatientsDTO = GetPatientsService.GetPatients(source, Patient);
            }
            catch (Exception ex)
            {    
                throw ex;
            }

            return patientsDTO;
        }
    }
}
