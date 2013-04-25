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
    public class InitialChargeByHospitalService
    {
        private PatientsDbFor patientRepositoryDbFor;
        public PatientsDbFor PatientRepositoryDbFor
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
        public InitialChargeByHospitalFillPatientService InitialChargeByHospitalFillPatientService
        {
            get { return initialChargeByHospitalFillPatientService ?? (initialChargeByHospitalFillPatientService = new InitialChargeByHospitalFillPatientService()); }
            set
            {
                initialChargeByHospitalFillPatientService = value;
            }
        }

        private List<IPatientDTO> patients;
        public List<IPatientDTO> Patients
        {
            get { return patients ?? (patients = new List<IPatientDTO>()); }
            set
            {
                patients = value;
            }
        }

        private List<IPatientDTO> patientsDb;
        public List<IPatientDTO> PatientsDb
        {
            get { return patientsDb ?? (patientsDb = new List<IPatientDTO>()); }
            set
            {
                patientsDb = value;
            }
        }

        public virtual void DoSearch(IPatientDTO patientDTO)
        {
            //TODO: Criar essa Chamada Assincrona com TASK
            for (int i = 0; i < 1; i++)
            {
                DoSearchPatients(patientDTO);
                //   DoSearchTreatment(patientDTO);
            }

            RemoveExistingPatients();

            PatientRepositoryDbFor.inserirPacientes(PatientsDb);
            SavePatientsLuceneService.SavePatientsLucene(PatientsDb.ToList());
        }

        private void DoSearchTreatment(IPatientDTO patientDTO)
        {
            throw new NotImplementedException();
        }

        private void DoSearchPatients(IPatientDTO patientDTO)
        {
            InitialChargeByHospitalFillPatientService = new InitialChargeByHospitalFillPatientService();
            InitialChargeByHospitalFillPatientService.DoSearch(DbEnum.QuintaDorProd, patientDTO);
            Patients.AddRange(initialChargeByHospitalFillPatientService.Patients);
        }

        private void RemoveExistingPatients()
        {
            foreach (var patientGroup in Patients.GroupBy(p => p.GetCPF()).GroupBy(e => e.Key))
            {
                foreach (var patientValue in patientGroup)
                {
                    IPatientDTO patientUnique = new PatientDTO();

                    foreach (var patient in patientValue)
                    {
                        if (string.IsNullOrEmpty(patientUnique.Id))
                        {
                            patientUnique = patient;
                            PatientsDb.Add(patient);
                        }
                        else
                        {
                            patientUnique.AddRecord(patient.Id);
                        }
                    }
                }
            }
        }
    }
}