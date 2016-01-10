using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetRecordsLuceneService
    {
        private string _luceneIndexPath;

        public GetRecordsLuceneService(string path)
        {
            _luceneIndexPath = path;
        }

        public List<Record> GetRecordBy(string cpf)
        {
            var lucene = new LuceneClientRecord(_luceneIndexPath);
            return lucene.SearchBy(cpf).ToList();
        }
    }
}
