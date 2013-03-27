using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRCache.Service;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Domain.Services
{
    public class SavePatientsMemCacheService
    {
        private SavePatientService savePatientService;

        public virtual SavePatientService SavePatientService 
        {
            get { return savePatientService ?? (savePatientService = new SavePatientService()); }
            set { savePatientService = value; }
        }

        public virtual void Save(DbEnum db)
        {
            GetPatientsService service = new GetPatientsService();

            var patients = service.GetPatients(db,new PatientDTO());

            SavePatientService.SavePatient(db, patients.ToList());
        }
    }
}
