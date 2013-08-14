using EHR.CoreShared;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetCidFromLuceneService
    {
        private LuceneClientCid luceneClientCid;
        public virtual LuceneClientCid LuceneClientCid
        {
            get { return luceneClientCid ?? (luceneClientCid = new LuceneClientCid("")); }
            set
            {
                luceneClientCid = value;
            }
        }

        public List<CID> GetCid(string code)
        {
            return LuceneClientCid.SimpleSearch(code).ToList();
        }
    }
}
