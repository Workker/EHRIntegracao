using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.Domain;
using EHRIntegracao.Domain.Services.GetEntities;
using EHRIntegracao.Domain.Services.InitialCharge;
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

        private List<IPatientDTO> patients;
        public virtual List<IPatientDTO> Patients
        {
            get { return patients ?? (patients = new List<IPatientDTO>()); }
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
        public virtual GetValuesDbEnumService GetValuesDbEnumService
        {
            get { return getValuesDbEnumService ?? (getValuesDbEnumService = new GetValuesDbEnumService()); }
            set
            {
                getValuesDbEnumService = value;
            }
        }


        #endregion

        public virtual void DoSearch(IPatientDTO patientDTO)
        {
            Assertion.NotNull(patientDTO, "Paciente não informado.").Validate();
            try
            {
                var dbs = GetValues();

                foreach (var db in dbs.Where(dv=> dv == DbEnum.QuintaDor))
                {
                    if (db == DbEnum.sumario)
                        continue;

                    DoSearchPatients(patientDTO, db);
                }

                Console.WriteLine("Removendo Pacientes");
                RemoveExistingPatients();
                Console.WriteLine("Agrupando Tratamentos");
                GroupTreatment();
                Console.WriteLine("Salvando Pacientes");
                SavePatients();
            }
            catch (Exception ex)
            {
                    
                throw ex;
            }
            
        }

        private List<DbEnum> GetValues()
        {
            return GetValuesDbEnumService.GetValues();
        }

        private void SavePatients()
        {
            //PatientRepositoryDbFor.inserirPacientes(Patients);
            SavePatientsLuceneService.SavePatientsLucene(Patients.ToList());
        }

        private void DoSearchPatients(IPatientDTO patientDTO, DbEnum db)
        {
            InitialChargeByHospitalFillPatientService.DoSearch(db, patientDTO);
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