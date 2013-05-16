using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRLucene.Domain;

namespace EHRIntegracao.Domain.Services.GetEntities
{
   public   class GetDefFromLuceneService
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

        public List<DefDTO> GetTus(string code)
        {
            return LuceneClientDef.SimpleSearch(code).ToList();
        }
    }
}
