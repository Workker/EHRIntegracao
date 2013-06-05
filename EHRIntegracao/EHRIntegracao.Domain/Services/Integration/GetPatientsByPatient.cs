using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Services.GetEntities;
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

        private IList<IPatientDTO> patients;
        public virtual IList<IPatientDTO> Patients
        {
            get { return patients ?? (patients = new List<IPatientDTO>()); }
            set
            {
                patients = value;
            }
        }

        public IList<IPatientDTO> GetAll(IPatientDTO patient)
        {
            Assertion.NotNull(patient, "Paticiente não informado.").Validate();

            if (patient.Hospital != null)
            {
                var patients = GetPatientsService.GetPatients(patient.Hospital.Value, patient);
                return patients;
            }

            var dbs = Enum.GetValues(typeof(DbEnum));
            foreach (var db in dbs)
            {
                var banco = (DbEnum)db;
                if (banco == DbEnum.sumario)
                    continue;

                //TODO Acessar query com filtro de 6 dias de Range.
                var patients = GetPatientsService.GetPatients(banco, patient);

                if (patients != null)
                    Patients.ToList().AddRange(patients);
            }

            return Patients;
        }
    }
}
