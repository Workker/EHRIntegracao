using EHR.CoreShared;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveTusInLuceneService
    {
        public void Save(List<TUS> tus)
        {
            var lucene = new LuceneClientTus("");
            lucene.AddUpdateLuceneIndex(tus);
        }
    }
}
