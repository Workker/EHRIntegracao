using EHR.CoreShared.Interfaces;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services
{
    public class SavePatientsLuceneService
    {
        public virtual void SavePatientsLucene(List<IPatient> patients)
        {
            var lucene = new LuceneClient("");
            lucene.AddUpdateLuceneIndex(patients);
        }
    }
}
