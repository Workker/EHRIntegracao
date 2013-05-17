using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRLucene.Domain;

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

        public List<CidDTO> GetCid(string code)
        {
            return LuceneClientCid.SimpleSearch(code).ToList();
        }
    }
}
