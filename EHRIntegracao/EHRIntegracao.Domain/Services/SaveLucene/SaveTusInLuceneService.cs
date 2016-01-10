using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveTusInLuceneService
    {
        private string _luceneIndexPath;

        public SaveTusInLuceneService(string path)
        {
            _luceneIndexPath = path;
        }

        public void Save(List<TUSS> tuss)
        {
            var lucene = new LuceneClientTUSS(_luceneIndexPath);
            lucene.UpdateIndex(tuss);
        }
    }
}
