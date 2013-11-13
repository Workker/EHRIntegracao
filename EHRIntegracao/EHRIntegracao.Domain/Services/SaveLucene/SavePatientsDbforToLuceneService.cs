using EHR.CoreShared.Entities;
using EHRIntegracao.Domain.Services.GetEntities;
using System.Linq;

namespace EHRIntegracao.Domain.Services
{
    public class SavePatientsDbforToLuceneService
    {
        public virtual void Save(Hospital hospital)
        {
            var service = new GetPatientsService();
            var serviceLucene = new SavePatientsLuceneService();

            var patients = service.GetPatientsDbFor();

            serviceLucene.SavePatientsLucene(patients.ToList());
        }
    }
}
