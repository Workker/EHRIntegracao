using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRCache;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Domain.PatientSpecificationQuery;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Domain.Services
{
    public class GetPatientsService
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

        private PatientRepository patientRepository;
        public PatientRepository PatientRepository
        {
            get { return patientRepository ?? (patientRepository = new PatientRepository()); }
            set
            {
                patientRepository = value;
            }
        }


        public IList<IPatientDTO> GetPatients(DbEnum db, IPatientDTO patient)
        {
            ClearPatient();

            patientRepository = new PatientRepository(FactorryNhibernate.GetSession(db));

            var patients = patientRepository.GetPatientsBy(patient);
            PatientConverter(patients);

            return patientsDTO;
        }

        public IList<IPatientDTO> GetPatientsMemCache(DbEnum db, IPatientDTO patient)
        {
            ClearPatient();

            var service = new EHRCache.Service.GetPatientService();
            var factory = new FactoryPatientSpecificationQuery();
            var patients = factory.GetPatientsByQuery(patient, service.GetPatientByKey(DbEnum.QuintaDorWorkker));

            return patients;
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
