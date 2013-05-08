﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRCache.Service;
using EHRIntegracao.Domain.Factorys;


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
            var service = new GetPatientsService();
            var serviceLucene = new SavePatientsLuceneService();

            var patients = service.GetPatientsDbFor();

          //SavePatientService.SavePatient(db, patients.ToList());
            serviceLucene.SavePatientsLucene(patients.ToList());

        }
    }
}
