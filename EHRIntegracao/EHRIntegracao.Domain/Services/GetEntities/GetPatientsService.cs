using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRCache;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Domain.PatientSpecificationQuery;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;


namespace EHRIntegracao.Domain.Services.GetEntities
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
        public PatientRepository PatientRepositoryObj
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

            using (var repository = new PatientRepository(FactorryNhibernate.GetSession(db)))
            {
                var patients = repository.GetPatientsBy(patient);
                PatientConverter(patients, db);
            }

            return PatientsDTO;
        }

        private void ClearRepository()
        {
            if (PatientRepository.Session != null)
                PatientRepositoryObj.Dispose();

        }

        public IList<IPatientDTO> GetPatientsDbFor(DbEnum db, IPatientDTO patient)
        {
            ClearPatient();

            PatientsDTO = PatientRepositoryDbFor.Todos(patient, db);

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

        private void PatientConverter(IList<Patient> patients, DbEnum db)
        {
            foreach (var patient in patients)
            {
                var patientDto = new PatientDTO()
                {
                    Id = patient.Id,
                    CPF = patient.Cpf == null ? null : Regex.Replace(patient.Cpf, "[^0-9]", string.Empty),
                    DateBirthday = patient.DateBirthday,
                    Identity = patient.Identity,
                    Name = patient.Name,
                    Hospital = db
                };
                patientDto.Records = new List<RecordDTO>();
                PatientsDTO.Add(patientDto);
            }
        }
    }
}
