using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Services.GetEntities;


namespace EHRIntegracao.Domain.Services
{
    public class SavePatientsDbforToLuceneService
    {
        public virtual void Save(DbEnum db)
        {
            var service = new GetPatientsService();
            var serviceLucene = new SavePatientsLuceneService();

            var patients = service.GetPatientsDbFor();

            serviceLucene.SavePatientsLucene(patients.ToList());
        }
    }
}
