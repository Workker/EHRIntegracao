using EHR.CoreShared;
using EHRLucene.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetPatientsLuceneService
    {
        public IPatientDTO GetPatientBy(string cpf)
        {
            var lucene = new LuceneClient("");
            return lucene.SearchBy(cpf);
        }

        public List<IPatientDTO> GetPatients(string name)
        {
            var lucene = new LuceneClient("");
            return lucene.SimpleSearch(name).Take(10).ToList();
        }
        //Todo: Mock
        public List<IPatientDTO> MockPatients(string name)
        {
            var lucene = new LuceneClient("E:\\Projects\\EHR\\EHR.Solution\\EHR.UI\\lucene_index");
            return lucene.SimpleSearch(name).Take(10).ToList();
        }

        public List<IPatientDTO> GetPatientsAdvancedSearch(IPatientDTO patient, List<string> hospitals)
        {
            var lucene = new LuceneClient("");
            return lucene.AdvancedSearch(patient, hospitals).ToList();
        }
    }
}
