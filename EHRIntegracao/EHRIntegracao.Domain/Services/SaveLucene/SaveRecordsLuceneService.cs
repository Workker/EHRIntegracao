using EHR.CoreShared.Interfaces;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveRecordsLuceneService
    {
        public virtual void SavePatientsLucene(List<IPatient> patients)
        {
            var lucene = new LuceneClientRecord(string.Empty);
            lucene.AddRecordsOnIndexFrom(patients);
        }
    }
}
