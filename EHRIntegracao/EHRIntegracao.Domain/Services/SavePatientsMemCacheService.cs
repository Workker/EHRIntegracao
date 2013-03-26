using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRCache.Service;
using EHRIntegracao.Domain.Factorys;

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
            GetPatientService service = new GetPatientService();

            var patients = service.GetPatientByKey(db);

            SavePatientService.SavePatient(db, patients);
        }
    }
}
