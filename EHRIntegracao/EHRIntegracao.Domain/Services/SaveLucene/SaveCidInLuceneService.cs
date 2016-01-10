using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveCidInLuceneService
    {
        private string _luceneIndexPath;

        public SaveCidInLuceneService(string path)
        {
            _luceneIndexPath = path;
        }

        public void Save(List<CID> cids)
        {
            var lucene = new LuceneClientCID(_luceneIndexPath);
            lucene.UpdateIndex(cids);
        }
    }
}
