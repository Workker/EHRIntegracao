using EHR.CoreShared;
using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetCidFromLuceneService
    {
        private LuceneClientCID _luceneClientCid;

        private string _luceneIndexPath;

        public GetCidFromLuceneService(string path)
        {
            _luceneIndexPath = path;
        }

        public virtual LuceneClientCID LuceneClientCid
        {
            get { return _luceneClientCid ?? (_luceneClientCid = new LuceneClientCID(_luceneIndexPath)); }
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
