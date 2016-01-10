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

        private string _luceneIndexPath;

        public GetTusFromLuceneService(string path)
        {
            _luceneIndexPath = path;
        }

        public virtual LuceneClientTUSS LuceneClientTus
        {
            get { return _luceneClientTus ?? (_luceneClientTus = new LuceneClientTUSS(_luceneIndexPath)); }
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
