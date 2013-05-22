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


namespace EHRIntegracao.Domain.Services.InitialCharge
{
    public class InitialChargeByHospitalFillPatientService
    {


        private GetPatientsService getPatientsService;
        public GetPatientsService GetPatientsService
        {
            get { return getPatientsService ?? (getPatientsService = new GetPatientsService()); }
            set
            {
                getPatientsService = value;
            }
        }

        private IList<IPatientDTO> patients;
        public IList<IPatientDTO> Patients
        {
            get { return patients ?? (patients = new List<IPatientDTO>()); }
            set
            {
                patients = value;
            }
        }

        public virtual void DoSearch(DbEnum db, IPatientDTO patientDTO)
        {
            ClearPatient();
            Patients = GetPatientsService.GetPatients(db, patientDTO);
            ValidateCPFPatient();
            ValidadeBirthday();

        }

        private void ClearPatient()
        {
            Patients = null;
        }

        private void ValidadeBirthday()
        {
            Patients = Patients.Where(p => p.DateBirthday != null).ToList();
            Patients = Patients.Where(p => IsGreater(p.DateBirthday.Value)).ToList();
        }

        private void ValidateCPFPatient()
        {
            var validate = new ValidateCPF();
            Patients = Patients.Where(p => validate.isCPF(p.CPF)).ToList();
        }

        private bool IsGreater(DateTime birthday)
        {
            return (DateTime.Today.Year - birthday.Year) >= 18;
        }
    }
}
