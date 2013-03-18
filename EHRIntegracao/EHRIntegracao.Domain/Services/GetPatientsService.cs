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
    public class GetPatientsService
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

        private PatientRepository patientRepository;
        public PatientRepository PatientRepository
        {
            get { return patientRepository ?? (patientRepository = new PatientRepository()); }
            set
            {
                patientRepository = value;
            }
        }


        public IList<PatientDTO> GetPatients(DbEnum db,PatientDTO patient)
        {
            ClearPatient();

            patientRepository = new PatientRepository(FactorryNhibernate.GetSession(db));

            var patients = patientRepository.GetPatientsBy(patient);
            PatientConverter(patients);
           
            return patientsDTO;
        }

        private void ClearPatient()
        {
            patientsDTO = null;
        }
        
        private void PatientConverter(IList<Patient> patients) 
        {
            foreach (var patient in patients)
            {
                var patientDto = new PatientDTO()
                {
                    CPF = patient.Cpf,
                    DateBirthday = patient.DateBirthday,
                    Identity = patient.Identity,
                    Name = patient.Name
                };

                PatientsDTO.Add(patientDto);
            }

        }
    }
}
