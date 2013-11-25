using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using System.Collections.Generic;
using System.Text.RegularExpressions;


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

        private PatientDTORepository patientRepository;
        public virtual PatientDTORepository PatientRepositoryObj
        {
            get { return patientRepository ?? (patientRepository = new PatientDTORepository()); }
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

        public virtual IList<IPatient> GetPatientsPeriodicCharge(Hospital hospital)
        {
            ClearPatient();

            using (var repository = new PatientDTORepository(FactorryNhibernate.GetSession(hospital.Database)))
            {
                var patients = repository.GetPatientsWithPeriod();
                PatientConverter(patients, hospital);
            }

            return PatientsDTO;
        }

        public virtual IList<IPatient> GetPatients(Hospital hospital, IPatient patient)
        {
            ClearPatient();

            using (var repository = new PatientDTORepository(FactorryNhibernate.GetSession(hospital.Database)))
            {
                var patients = repository.GetPatientsBy(patient);
                PatientConverter(patients, hospital);
            }

            return PatientsDTO;
        }

        private void ClearRepository()
        {
            if (BaseRepository.Session != null)
                PatientRepositoryObj.Dispose();

        }

        public virtual IList<IPatient> GetPatientsDbFor(Hospital hospital, IPatient patient)
        {
            ClearPatient();

            PatientsDTO = PatientRepositoryDbFor.Todos(patient, hospital);

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

        private void PatientConverter(IList<PatientDTO> patients, Hospital hospital)
        {
            foreach (var patient in patients)
            {
                var patientDto = new Patient
                                     {
                                         Id = patient.Id,
                                         CPF =
                                             patient.Cpf == null
                                                 ? null
                                                 : Regex.Replace(patient.Cpf, "[^0-9]", string.Empty),
                                         DateBirthday = patient.DateBirthday,
                                         Identity = patient.Identity,
                                         Name = patient.Name,
                                         Genre = patient.Genre,
                                         Hospital = hospital,
                                         Records = new List<Record>()
                                     };
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
