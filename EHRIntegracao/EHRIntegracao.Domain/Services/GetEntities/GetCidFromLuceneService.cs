using EHR.CoreShared;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetCidFromLuceneService
    {
        private LuceneClientCID _luceneClientCid;
        public virtual LuceneClientCID LuceneClientCid
        {
            get { return _luceneClientCid ?? (_luceneClientCid = new LuceneClientCID("C:\\")); }
            set
            {
                _luceneClientCid = value;
            }
        }

        public List<CID> GetCid(string code)
        {
            return LuceneClientCid.SimpleSearch(code).ToList();
        }
    }
}
