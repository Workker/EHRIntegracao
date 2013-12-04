using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetRecordsLuceneService
    {
        public List<Record> GetRecordBy(string cpf)
        {
            var lucene = new LuceneClientRecord("");
            return lucene.SearchBy(cpf).ToList();
        }
    }
}
