using EHRIntegracao.Domain.Services.DTO;
using EHRLucene.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Domain.Services
{
    public class SavePatientsLuceneService
    {
        public  void SavePatientsLucene(List<IPatientDTO> patients)
        {
            var lucene = new LuceneClient("");
            lucene.AddUpdateLuceneIndex(patients);
        }
    }
}
