using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Domain.PatientSpecificationIntegration;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.GetEntities;
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

        private IList<IPatientDTO> patients;
        public virtual IList<IPatientDTO> Patients
        {
            get { return patients ?? (patients = new List<IPatientDTO>()); }
            set
            {
                patients = value;
            }
        }

        public virtual void DoSearch(DbEnum db, IPatientDTO patientDTO)
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

        private bool IsGreater(IPatientDTO patient)
        {
            var specification = new PatientSpecificationIsGreater();
            return specification.IsSatisfiedBy(patient);
        }
    }
}
