using EHR.CoreShared;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetDefFromLuceneService
    {
        private LuceneClientDef luceneClientDef;
        public virtual LuceneClientDef LuceneClientDef
        {
            get { return luceneClientDef ?? (luceneClientDef = new LuceneClientDef("")); }
            set
            {
                luceneClientDef = value;
            }
        }

        public List<DEF> GetDef(string code)
        {
            return LuceneClientDef.SimpleSearch(code).ToList();
        }
    }
}
