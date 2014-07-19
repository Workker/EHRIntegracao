using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveCidInLuceneService
    {
        public void Save(List<CID> cids)
        {
            var lucene = new LuceneClientCID(string.Empty);
            lucene.UpdateIndex(cids);
        }
    }
}
