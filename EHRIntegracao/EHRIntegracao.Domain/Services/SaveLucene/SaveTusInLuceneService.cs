using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveTusInLuceneService
    {
        public void Save(List<TUSS> tuss)
        {
            var lucene = new LuceneClientTUSS(string.Empty);
            lucene.UpdateIndex(tuss);
        }
    }
}
