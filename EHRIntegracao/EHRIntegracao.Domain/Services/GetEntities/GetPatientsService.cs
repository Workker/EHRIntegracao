using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHR.CoreShared.Interfaces;
using EHRCache;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;


namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetPatientsService
    {
        private IList<IPatient> patientsDTO;
        public virtual IList<IPatient> PatientsDTO
        {
            get { return patientsDTO ?? (patientsDTO = new List<IPatient>()); }
            set
            {
                patientsDTO = value;
            }
        }

        private PatientRepository patientRepository;
        public virtual PatientRepository PatientRepositoryObj
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

        public virtual IList<IPatient> GetPatientsPeriodicCharge(DbEnum db)
        {
            ClearPatient();

            using (var repository = new PatientRepository(FactorryNhibernate.GetSession(db)))
            {
                var patients = repository.GetPatientsWithPeriod();
                PatientConverter(patients, db);
            }

            return PatientsDTO;
        }

        public virtual IList<IPatient> GetPatients(DbEnum db, IPatient patient)
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
            if (BaseRepository.Session != null)
                PatientRepositoryObj.Dispose();

        }

        public virtual IList<IPatient> GetPatientsDbFor(DbEnum db, IPatient patient)
        {
            ClearPatient();

            PatientsDTO = PatientRepositoryDbFor.Todos(patient, db);

            return PatientsDTO;
        }

        public virtual IList<IPatient> GetPatientsDbFor()
        {
            ClearPatient();

            PatientsDTO = PatientRepositoryDbFor.Todos();

            return PatientsDTO;
        }

        private void ClearPatient()
        {
            patientsDTO = null;
        }

        private void PatientConverter(IList<EHRIntegracao.Domain.Domain.Patient> patients, DbEnum db)
        {
            foreach (var patient in patients)
            {
                var patientDto = new Patient()
                {
                    Id = patient.Id,
                    CPF = patient.Cpf == null ? null : Regex.Replace(patient.Cpf, "[^0-9]", string.Empty),
                    DateBirthday = patient.DateBirthday,
                    Identity = patient.Identity,
                    Name = patient.Name,
                    Hospital = db
                };
                patientDto.Records = new List<Record>();
                PatientsDTO.Add(patientDto);
            }
        }
    }
}


//public virtual IList<PatientDTO> GetPatientsMemCache(DbEnum db, IPatientDTO patient)
//      {
//          ClearPatient();

//          var service = new EHRCache.Service.GetPatientService();
//          var factory = new FactoryPatientSpecificationQuery();
//          var patients = factory.GetPatientsByQuery(patient, service.GetPatientByKey(DbEnum.QuintaDor));

//          return patients;
//      }

//      public virtual IList<PatientDTO> GetPatientsRedis(DbEnum db, IPatientDTO patient)
//      {
//          ClearPatient();

//          var service = new EHRCache.Service.GetPatientRedisService();
//          var factory = new FactoryPatientSpecificationQuery();
//          var patients = factory.GetPatientsByQuery(patient, service.GetPatientByKey(DbEnum.QuintaDor));

//          return patients.Take(30).ToList();
//      }
