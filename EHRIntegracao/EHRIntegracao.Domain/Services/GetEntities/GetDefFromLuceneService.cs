using EHR.CoreShared;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetDefFromLuceneService
    {
        private LuceneClientDEF _luceneClientDef;
        public virtual LuceneClientDEF LuceneClientDef
        {
            get { return _luceneClientDef ?? (_luceneClientDef = new LuceneClientDEF("C:\\")); }
            set
            {
                _luceneClientDef = value;
            }
        }

        public List<DEF> GetDef(string code)
        {
            return LuceneClientDef.SimpleSearch(code).ToList();
        }
    }
}
