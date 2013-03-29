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
    public class SavePatientsCacheService
    {
        private SavePatientRedisService savePatientService;

        public virtual SavePatientRedisService SavePatientService 
        {
            get { return savePatientService ?? (savePatientService = new SavePatientRedisService()); }
            set { savePatientService = value; }
        }

        public virtual void Save(DbEnum db)
        {
            GetPatientsService service = new GetPatientsService();

            var patients = service.GetPatientsDbFor();

            SavePatientService.SavePatient(db, patients.ToList());
        }
    }
}
