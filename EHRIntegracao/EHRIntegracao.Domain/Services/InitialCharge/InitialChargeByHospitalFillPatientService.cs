using EHR.CoreShared;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Domain.PatientSpecificationIntegration;
using EHRIntegracao.Domain.Services.GetEntities;
using System.Collections.Generic;
using System.Linq;
using Workker.Framework.Domain;

namespace EHRIntegracao.Domain.Services.InitialCharge
{
    public class InitialChargeByHospitalFillPatientService
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

        public virtual void DoSearch(DbEnum db, IPatient patientDTO)
        {
            Assertion.NotNull(db, "Banco não informado.").Validate();
            Assertion.NotNull(patientDTO, "Paciente não informado.").Validate();

            ClearPatient();
            Patients = GetPatientsService.GetPatients(db, patientDTO);
            ValidateCPFPatient();
            ValidadeBirthday();
        }

        public virtual void DoSearchPeriodicCharge(DbEnum db)
        {
            Assertion.NotNull(db, "Banco não informado.").Validate();

            ClearPatient();
            Patients = GetPatientsService.GetPatientsPeriodicCharge(db);
            ValidateCPFPatient();
            ValidadeBirthday();
        }

        private void ClearPatient()
        {
            Patients = null;

            Assertion.Equals(Patients.Count(), 0, "Lista de pacientes não foi zerada").Validate();
        }

        private void ValidadeBirthday()
        {
            Patients = Patients.Where(IsGreater).ToList();
        }

        private void ValidateCPFPatient()
        {
            var validate = new ValidateCPF();
            Patients = Patients.Where(p => validate.isCPF(p.CPF)).ToList();
        }

        private bool IsGreater(IPatient patient)
        {
            var specification = new PatientSpecificationIsGreater();
            return specification.IsSatisfiedBy(patient);
        }
    }
}
