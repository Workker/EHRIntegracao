using EHR.CoreShared;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetTusFromLuceneService
    {
        private LuceneClientTus luceneClientTus;
        public virtual LuceneClientTus LuceneClientTus
        {
            get { return luceneClientTus ?? (luceneClientTus = new LuceneClientTus("")); }
            set
            {
                luceneClientTus = value;
            }
        }

        public List<TUS> GetTus(string code)
        {
            return LuceneClientTus.SimpleSearch(code).ToList();
        }

    }
}
