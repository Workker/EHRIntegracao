using EHRIntegracao.Domain.Services.DTO;
using EHRLucene.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Domain.Services
{
    public class GetPatientsLuceneService
    {
        public IPatientDTO GetPatientBy(string id)
        {
            var lucene = new LuceneClient("");
            return lucene.SearchBy(id);
        }

        public List<IPatientDTO> GetPatients(string name)
        {
            var lucene = new LuceneClient("");
            return lucene.SimpleSearch(name).Take(10).ToList();
        }

        public List<IPatientDTO> GetPatientsAdvancedSearch(IPatientDTO patient, List<string> hospitals)
        {
            var lucene = new LuceneClient("");
            return lucene.AdvancedSearch(patient, hospitals).ToList();
        }
    }
}
