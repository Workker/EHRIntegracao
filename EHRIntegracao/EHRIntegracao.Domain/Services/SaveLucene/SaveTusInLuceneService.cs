using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRLucene.Domain;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveTusInLuceneService
    {
        public void SavePatientsLucene(List<TusDTO> tus)
        {
            var lucene = new LuceneClientTus("");
            lucene.AddUpdateLuceneIndex(tus);
        }
    }
}
