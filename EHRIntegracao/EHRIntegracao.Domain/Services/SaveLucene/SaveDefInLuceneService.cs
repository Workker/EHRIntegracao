using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRLucene.Domain;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveDefInLuceneService
    {
        public void Save(List<DefDTO> defs)
        {
            var lucene = new LuceneClientDef("");
            lucene.AddUpdateLuceneIndex(defs);
        }
    }
}
