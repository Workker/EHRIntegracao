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
            Patients = GetPatientsService.GetPatients(db, patientDTO);
            ValidateCPFPatient();
            ValidadeBirthday();
        }

        private void ValidadeBirthday()
        {
            Patients = Patients.Where(p => p.DateBirthday != null).ToList();
        }

        private void ValidateCPFPatient()
        {
            var validate = new ValidateCPF();
            Patients = Patients.Where(p => validate.isCPF(p.CPF)).ToList();
        }
    }
}
