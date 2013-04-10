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

        private PatientsDbFor patientRepositoryDbFor;
        public PatientsDbFor PatientRepositoryDbFor
        {
            get { return patientRepositoryDbFor ?? (patientRepositoryDbFor = new PatientsDbFor()); }
            set
            {
                patientRepositoryDbFor = value;
            }
        }


        public IList<IPatientDTO> GetPatients(DbEnum db, IPatientDTO patient)
        {
            ClearPatient();

            PatientRepository = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.sumario));

            var patients = PatientRepository.GetPatientsBy(patient);
            PatientConverter(patients,db);

            return PatientsDTO;
        }

        public IList<IPatientDTO> GetPatientsDbFor(DbEnum db, IPatientDTO patient)
        {
            ClearPatient();

            PatientsDTO = PatientRepositoryDbFor.Todos(patient,db);

            return PatientsDTO;
        }

        public IList<IPatientDTO> GetPatientsDbFor()
        {
            ClearPatient();

            PatientsDTO = PatientRepositoryDbFor.Todos();

            return PatientsDTO;
        }

        public IList<PatientDTO> GetPatientsMemCache(DbEnum db, IPatientDTO patient)
        {
            ClearPatient();

            var service = new EHRCache.Service.GetPatientService();
            var factory = new FactoryPatientSpecificationQuery();
            var patients = factory.GetPatientsByQuery(patient, service.GetPatientByKey(DbEnum.QuintaDor));

            return patients;
        }

        public IList<PatientDTO> GetPatientsRedis(DbEnum db, IPatientDTO patient)
        {
            ClearPatient();

            var service = new EHRCache.Service.GetPatientRedisService();
            var factory = new FactoryPatientSpecificationQuery();
            var patients = factory.GetPatientsByQuery(patient, service.GetPatientByKey(DbEnum.QuintaDor));

            return patients.Take(30).ToList();
        }

        private void ClearPatient()
        {
            patientsDTO = null;
        }

        private void PatientConverter(IList<Patient> patients,DbEnum db)
        {
            foreach (var patient in patients)
            {
                var patientDto = new PatientDTO()
                {
                    CPF = patient.Cpf,
                    DateBirthday = patient.DateBirthday.ToShortDateString(),
                    Identity = patient.Identity,
                    Name = patient.Name,
                    Hospital  = db
                };

                PatientsDTO.Add(patientDto);
            }

        }
    }
}
