using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRLucene.Domain;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveCidInLuceneService
    {
        public void Save(List<CidDTO> cids)
        {
            var lucene = new LuceneClientCid("");
            lucene.AddUpdateLuceneIndex(cids);
        }
    }
}
