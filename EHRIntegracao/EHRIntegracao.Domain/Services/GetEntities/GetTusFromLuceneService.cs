using EHR.CoreShared;
using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetTusFromLuceneService
    {
        private LuceneClientTUSS _luceneClientTus;
        public virtual LuceneClientTUSS LuceneClientTus
        {
            get { return _luceneClientTus ?? (_luceneClientTus = new LuceneClientTUSS("C:\\")); }
            set
            {
                _luceneClientTus = value;
            }
        }

        public List<TUSS> GetTus(string code)
        {
            return LuceneClientTus.SimpleSearch(code).ToList();
        }

    }
}
