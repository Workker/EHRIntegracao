using EHR.CoreShared.Interfaces;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveRecordsLuceneService
    {
        private string _luceneIndexPath;

        public SaveRecordsLuceneService(string path)
        {
            _luceneIndexPath = path;
        }
        public virtual void SavePatientsLucene(List<IPatient> patients)
        {
            var lucene = new LuceneClientRecord(_luceneIndexPath);
            lucene.AddRecordsOnIndexFrom(patients);
        }
    }
}
