using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.GetEntities;
using EHRIntegracao.Domain.Services.InitialCharge;

namespace EHRIntegracao.Domain.Services.InitialCharge
{
    public class InitialChargeByHospitalService
    {
        private GetTreatmentService getTreatmentService { get; set; }
        public GetTreatmentService GetTreatmentService
        {
            get { return getTreatmentService ?? (getTreatmentService = new GetTreatmentService()); }
            set
            {
                getTreatmentService = value;
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

        private TreatmensDbFor treatmensDbFor;
        public TreatmensDbFor TreatmensDbFor
        {
            get { return treatmensDbFor ?? (treatmensDbFor = new TreatmensDbFor()); }
            set
            {
                treatmensDbFor = value;
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

        private List<ITreatmentDTO> treatments;
        public List<ITreatmentDTO> Treatments
        {
            get { return treatments ?? (treatments = new List<ITreatmentDTO>()); }
            set
            {
                treatments = value;
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

        private AssociatePatientsToTreatmentsService associatePatientsToTreatmentsService;
        public AssociatePatientsToTreatmentsService AssociatePatientsToTreatmentsService
        {
            get { return associatePatientsToTreatmentsService ?? (associatePatientsToTreatmentsService = new AssociatePatientsToTreatmentsService()); }
            set
            {
                associatePatientsToTreatmentsService = value;
            }
        }

        private TreatmentsLuceneService treatmentsLuceneService;
        public TreatmentsLuceneService TreatmentsLuceneService
        {
            get { return treatmentsLuceneService ?? (treatmentsLuceneService = new TreatmentsLuceneService()); }
            set
            {
                treatmentsLuceneService = value;
            }
        }

        public virtual void DoSearch(IPatientDTO patientDTO)
        {
            //TODO: Criar essa Chamada Assincrona com TASK
            //TODO: chamar coleção de hospitais
            for (int i = 0; i < 1; i++)
            {
                DoSearchPatients(patientDTO, DbEnum.QuintaDor);
                DoSearchTreatments(DbEnum.QuintaDor);
            }

            RemoveExistingPatients();
            SaveTreatments();
            //AssociatePatientsToTreatmentsService.Associate(Patients);
            GroupTreatment();
            SavePatients();
        }

        private void SaveTreatments()
        {
            TreatmensDbFor.inserir(Treatments);
            TreatmentsLuceneService.SaveTreatment(Treatments);
        }

        private void SavePatients()
        {
            PatientRepositoryDbFor.inserirPacientes(PatientsDb);
            SavePatientsLuceneService.SavePatientsLucene(PatientsDb.ToList());
        }


        private void DoSearchTreatments(DbEnum db)
        {
            var treatment = GetTreatmentService.GetTreatments(DbEnum.QuintaDor);
            Treatments.AddRange(treatment);
        }

        private void DoSearchPatients(IPatientDTO patientDTO, DbEnum db)
        {
            InitialChargeByHospitalFillPatientService = new InitialChargeByHospitalFillPatientService();
            InitialChargeByHospitalFillPatientService.DoSearch(db, patientDTO);
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
                            patient.AddRecord(new RecordDTO() { Code = patient.Id, Hospital = patient.Hospital });
                            PatientsDb.Add(patient);
                        }
                        else
                        {
                            patientUnique.AddRecord(new RecordDTO() { Code = patient.Id, Hospital = patient.Hospital });
                        }
                    }
                }
            }
        }

        private void GroupTreatment()
        {
            int i = 0;
            foreach (var patient in PatientsDb)
            {
                
                foreach (var recordsBysHospital in patient.Records.GroupBy(r => r.Hospital).GroupBy(b => b.Key))
                {
                    foreach (var records in recordsBysHospital.ToList())
                    {
                        List<ITreatmentDTO> treatmentsCheck = new List<ITreatmentDTO>();
                        foreach (var record in records.ToList())
                        {
                            treatmentsCheck = (from t in Treatments
                                               where t.Hospital == record.Hospital
                                               && t.Id == record.Code
                                               select t).ToList();
                                
                                //Treatments.Where(t => t.Hospital == record.Hospital && t.Id == record.Code).ToList();

                        }

                        patient.AddTreatments(treatmentsCheck);
                       
                        //treatments = (from t in Treatments
                        //              where t.Hospital == item.FirstOrDefault().Hospital
                        //              && item.Any(i => i.Code == t.Id)
                        //              select t).ToList();
                    }
                   
                }
                i++;
                Console.WriteLine(i.ToString());
            }
        }
    }
}