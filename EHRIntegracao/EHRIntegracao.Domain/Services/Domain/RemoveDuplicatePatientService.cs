using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.Domain
{
    public class RemoveDuplicatePatientService
    {
        private List<IPatient> patientsDb;
        public List<IPatient> PatientsDb
        {
            get { return patientsDb ?? (patientsDb = new List<IPatient>()); }
            set
            {
                patientsDb = value;
            }
        }

        public List<IPatient> RemoveExistingPatients(List<IPatient> patients)
        {
            foreach (var patientGroup in patients.GroupBy(p => p.GetCPF()).GroupBy(e => e.Key))
            {
                foreach (var patientValue in patientGroup)
                {
                    IPatient patientUnique = new Patient();

                    foreach (var patient in patientValue)
                    {
                        if (string.IsNullOrEmpty(patientUnique.Id))
                        {
                            patientUnique = patient;
                            patient.AddRecord(new Record() { Code = patient.Id, Hospital = patient.Hospital });
                            PatientsDb.Add(patient);
                        }
                        else
                        {
                            if (patientUnique.Records != null)
                            {
                                var record = patientUnique.Records.Find(r => r.Code == patient.Id);

                                if (record != null)
                                    continue;
                            }

                            patientUnique.AddRecord(new Record() { Code = patient.Id, Hospital = patient.Hospital });
                        }
                    }
                }
            }

            return PatientsDb;
        }
    }
}
