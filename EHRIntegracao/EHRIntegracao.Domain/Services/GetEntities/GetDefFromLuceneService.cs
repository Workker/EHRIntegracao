using EHR.CoreShared;
using EHR.CoreShared.Entities;
using EHRLucene.Domain;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetDefFromLuceneService
    {
        private LuceneClientDEF _luceneClientDef;

        private string _luceneIndexPath;

        public GetDefFromLuceneService(string path)
        {
            _luceneIndexPath = path;
        }

        public virtual LuceneClientDEF LuceneClientDef
        {
            get { return _luceneClientDef ?? (_luceneClientDef = new LuceneClientDEF(_luceneIndexPath)); }
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
