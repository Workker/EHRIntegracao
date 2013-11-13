using EHR.CoreShared;
using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveDefInLuceneService
    {
        public void Save(List<DEF> defs)
        {
            var lucene = new LuceneClientDEF("C:\\");
            lucene.UpdateIndex(defs);
        }
    }
}
