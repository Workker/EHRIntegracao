using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;

namespace EHRIntegracao.Domain.Services.Domain
{
    public class RemoveDuplicatePatientService
    {
        private List<IPatientDTO> patientsDb;
        public List<IPatientDTO> PatientsDb
        {
            get { return patientsDb ?? (patientsDb = new List<IPatientDTO>()); }
            set
            {
                patientsDb = value;
            }
        }

        public List<IPatientDTO> RemoveExistingPatients(List<IPatientDTO> patients)
        {
            foreach (var patientGroup in patients.GroupBy(p => p.GetCPF()).GroupBy(e => e.Key))
            {
                foreach (var patientValue in patientGroup)
                {
                    IPatientDTO patientUnique = new PatientDTO();

                    foreach (var patient in patientValue)
                    {
                        if (string.IsNullOrEmpty(patientUnique.Id))
                        {
                            patientUnique = patient;
                            patient.AddRecord(new RecordDTO() { Code = patient.Id, Hospital = patient.Hospital.Value });
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



                            patientUnique.AddRecord(new RecordDTO() { Code = patient.Id, Hospital = patient.Hospital.Value });
                        }
                    }
                }
            }

            return PatientsDb;
        }
    }
}
