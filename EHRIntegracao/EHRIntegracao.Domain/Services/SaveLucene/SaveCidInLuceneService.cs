using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRLucene.Domain;

namespace EHRIntegracao.Domain.Services.SaveLucene
{
    public class SaveCidInLuceneService
    {
        public void SavePatientsLucene(List<CidDTO> patients)
        {
            var lucene = new LuceneClientCid("");
            lucene.AddUpdateLuceneIndex(patients);
        }
    }
}
