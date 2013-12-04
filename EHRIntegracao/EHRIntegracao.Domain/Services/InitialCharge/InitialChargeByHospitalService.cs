using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.Domain;
using EHRIntegracao.Domain.Services.GetEntities;
using EHRIntegracao.Domain.Services.SaveLucene;
using System;
using System.Collections.Generic;
using System.Linq;
using Workker.Framework.Domain;

namespace EHRIntegracao.Domain.Services.InitialCharge
{
    public class InitialChargeByHospitalService
    {
        #region Property

        private PatientsDbFor patientRepositoryDbFor;
        public virtual PatientsDbFor PatientRepositoryDbFor
        {
            get { return patientRepositoryDbFor ?? (patientRepositoryDbFor = new PatientsDbFor()); }
            set
            {
                patientRepositoryDbFor = value;
            }
        }

        private SaveRecordsLuceneService _saveRecordsLuceneService;
        public virtual SaveRecordsLuceneService SaveRecordsLuceneService
        {
            get { return _saveRecordsLuceneService ?? (_saveRecordsLuceneService = new SaveRecordsLuceneService()); }
            set { _saveRecordsLuceneService = value; }
        }

        private SavePatientsLuceneService savePatientsLuceneService;
        public virtual SavePatientsLuceneService SavePatientsLuceneService
        {
            get { return savePatientsLuceneService ?? (savePatientsLuceneService = new SavePatientsLuceneService()); }
            set { savePatientsLuceneService = value; }
        }

        private InitialChargeByHospitalFillPatientService initialChargeByHospitalFillPatientService;
        public virtual InitialChargeByHospitalFillPatientService InitialChargeByHospitalFillPatientService
        {
            get { return initialChargeByHospitalFillPatientService ?? (initialChargeByHospitalFillPatientService = new InitialChargeByHospitalFillPatientService()); }
            set
            {
                initialChargeByHospitalFillPatientService = value;
            }
        }

        private List<IPatient> patients;
        public virtual List<IPatient> Patients
        {
            get { return patients ?? (patients = new List<IPatient>()); }
            set
            {
                patients = value;
            }
        }

        private AssociateTreatmentsAsyncService associatePatientsToTreatmentsService;

        private RemoveDuplicatePatientService removeDuplicatePatientService;
        public virtual RemoveDuplicatePatientService RemoveDuplicatePatientService
        {
            get { return removeDuplicatePatientService ?? (removeDuplicatePatientService = new RemoveDuplicatePatientService()); }
            set
            {
                removeDuplicatePatientService = value;
            }
        }

        private GetValuesDbEnumService getValuesDbEnumService;
        public virtual GetValuesDbEnumService GetHospitalsService
        {
            get { return getValuesDbEnumService ?? (getValuesDbEnumService = new GetValuesDbEnumService()); }
            set
            {
                getValuesDbEnumService = value;
            }
        }

        #endregion

        public virtual void DoSearch(IPatient patientDTO)
        {
            Assertion.NotNull(patientDTO, "Patient uninformed.").Validate();
            try
            {
                Console.WriteLine("Start");

                var hospitals = GetValues();

                foreach (var hospital in hospitals)
                {
                    if (hospital.Database != null)
                    {
                        DoSearchPatients(patientDTO, hospital);
                    }
                }

                Console.WriteLine("Removing Patients.");
                RemoveExistingPatients();

                Console.WriteLine("Save Records");
                SaveRecords();

                // Console.WriteLine("Grouping Treatments");
                //    GroupTreatment();

                Console.WriteLine("Saving Patients.");
                SavePatients();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private IList<Hospital> GetValues()
        {
            return GetHospitalsService.GetValues();
        }

        private void SavePatients()
        {
            //PatientRepositoryDbFor.inserirPacientes(Patients);
            SavePatientsLuceneService.SavePatientsLucene(Patients.ToList());
        }

        private void SaveRecords()
        {
            SaveRecordsLuceneService.SavePatientsLucene(Patients);
        }

        private void DoSearchPatients(IPatient patientDTO, Hospital hospital)
        {
            InitialChargeByHospitalFillPatientService.DoSearch(hospital, patientDTO);
            Patients.AddRange(initialChargeByHospitalFillPatientService.Patients);
        }

        private void RemoveExistingPatients()
        {
            Patients = RemoveDuplicatePatientService.RemoveExistingPatients(Patients);
        }

        private void GroupTreatment()
        {
            associatePatientsToTreatmentsService = new AssociateTreatmentsAsyncService(this.Patients);
            associatePatientsToTreatmentsService.Executar();
        }
    }
}