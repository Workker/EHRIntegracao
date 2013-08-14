using EHR.CoreShared;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Services.GetEntities;
using System;
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
