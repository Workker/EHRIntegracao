using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRLucene.Domain;

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

        public List<TusDTO> GetTus(string code) 
        {
            return LuceneClientTus.SimpleSearch(code).ToList();
        }

    }
}
