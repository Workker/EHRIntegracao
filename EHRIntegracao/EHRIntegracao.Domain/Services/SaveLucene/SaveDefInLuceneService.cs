using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveDefInLuceneService
    {
        private string _luceneIndexPath;

        public SaveDefInLuceneService(string path)
        {
            _luceneIndexPath = path;
        }

        public void Save(List<DEF> defs, string path)
        {
            var lucene = new LuceneClientDEF(path);
            lucene.UpdateIndex(defs);
        }
    }
}
