using EHR.CoreShared.Interfaces;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services
{
    public class SavePatientsLuceneService
    {
        private string _luceneIndexPath;

        public SavePatientsLuceneService(string path)
        {
            _luceneIndexPath = path;
        }

        public virtual void SavePatientsLucene(List<IPatient> patients)
        {
            var lucene = new LuceneClient(_luceneIndexPath);
            lucene.AddUpdateLuceneIndex(patients);
        }
    }
}
