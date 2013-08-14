﻿using EHR.CoreShared;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.Domain;
using EHRIntegracao.Domain.Services.GetEntities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.InitialCharge
{
    public class PeriodicChargeByHospitalService
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

        private List<IPatient> patientsLucene;
        public virtual List<IPatient> PatientsLucene
        {
            get { return patientsLucene ?? (patientsLucene = new List<IPatient>()); }
            set
            {
                patientsLucene = value;
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
        public virtual GetValuesDbEnumService GetValuesDbEnumService
        {
            get { return getValuesDbEnumService ?? (getValuesDbEnumService = new GetValuesDbEnumService()); }
            set
            {
                getValuesDbEnumService = value;
            }
        }
        private GetPatientsLuceneService getPatientsLuceneService;
        public virtual GetPatientsLuceneService GetPatientsLuceneService
        {
            get { return getPatientsLuceneService ?? (getPatientsLuceneService = new GetPatientsLuceneService()); }
            set
            {
                getPatientsLuceneService = value;
            }
        }



        #endregion

        public void DoSearch()
        {
            var dbs = GetValues();
            try
            {
                foreach (var db in dbs)
                {
                    if (db == DbEnum.sumario)
                        continue;

                    DoSearchPatients(db);
                }

                RemoveExistingPatients();
                GroupTreatment();
                SavePatients();
                Console.WriteLine("Finalizei");
            }
            catch (Exception ex)
            {

            }
        }

        private void SavePatients()
        {
            //PatientRepositoryDbFor.inserirPacientes(Patients);
            SavePatientsLuceneService.SavePatientsLucene(Patients.ToList());
        }

        private List<DbEnum> GetValues()
        {
            return GetValuesDbEnumService.GetValues();
        }

        private void DoSearchPatients(DbEnum db)
        {
            InitialChargeByHospitalFillPatientService.DoSearchPeriodicCharge(db);
            Patients.AddRange(initialChargeByHospitalFillPatientService.Patients);
        }

        private void RemoveExistingPatients()
        {
            Patients = RemoveDuplicatePatientService.RemoveExistingPatients(Patients);
            PatientsLucene = GetPatientsLuceneService.GetPatientPeriodic(Patients);

            Patients = Patients.Where(RemoveExistinPatient).ToList();
        }

        private bool RemoveExistinPatient(IPatient patient)
        {
            return !PatientsLucene.Any(p => p.GetCPF() == patient.GetCPF());
        }

        private void GroupTreatment()
        {
            associatePatientsToTreatmentsService = new AssociateTreatmentsAsyncService(this.Patients);
            associatePatientsToTreatmentsService.Executar();
        }

    }
}
