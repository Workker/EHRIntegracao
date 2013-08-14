using EHR.CoreShared;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveCidInLuceneService
    {
        public void Save(List<CID> cids)
        {
            var lucene = new LuceneClientCid("");
            lucene.AddUpdateLuceneIndex(cids);
        }
    }
}
