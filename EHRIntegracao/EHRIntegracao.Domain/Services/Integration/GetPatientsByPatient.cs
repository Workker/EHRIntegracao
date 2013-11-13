using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.GetEntities;
using System.Collections.Generic;
using System.Linq;
using Workker.Framework.Domain;

namespace EHRIntegracao.Domain.Services.Integration
{
    public class GetPatientsByPatient
    {

        private GetPatientsService getPatientsService;
        public virtual GetPatientsService GetPatientsService
        {
            get { return getPatientsService ?? (getPatientsService = new GetPatientsService()); }
            set
            {
                getPatientsService = value;
            }
        }

        private IList<IPatient> patients;
        public virtual IList<IPatient> Patients
        {
            get { return patients ?? (patients = new List<IPatient>()); }
            set
            {
                patients = value;
            }
        }

        public IList<IPatient> GetAll(IPatient patient)
        {
            Assertion.NotNull(patient, "Paticiente não informado.").Validate();

            if (patient.Hospital != null)
            {
                var patients = GetPatientsService.GetPatients(patient.Hospital, patient);
                return patients;
            }

            var repository = new Hospitals();
            var hospitals = repository.All<Hospital>();
            
            foreach (var item in hospitals)
            {
                var hospital = item;
                if (item.Key.Equals("Sumario"))
                    continue;

                //TODO Acessar query com filtro de 6 dias de Range.
                var patients = GetPatientsService.GetPatients(hospital, patient);

                if (patients != null)
                    Patients.ToList().AddRange(patients);
            }

            return Patients;
        }
    }
}
