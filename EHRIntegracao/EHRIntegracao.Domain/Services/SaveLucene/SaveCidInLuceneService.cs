using EHR.CoreShared;
using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveCidInLuceneService
    {
        public void Save(List<CID> cids)
        {
            var lucene = new LuceneClientCID("C:\\");
            lucene.UpdateIndex(cids);
        }
    }
}
