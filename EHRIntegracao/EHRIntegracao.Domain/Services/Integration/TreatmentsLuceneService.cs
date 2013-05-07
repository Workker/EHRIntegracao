using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Services.DTO;
using EHRLucene.Domain;

namespace EHRIntegracao.Domain.Services.Integration
{
    public class TreatmentsLuceneService
    {
        private LuceneClientTreatment luceneClientTreatment;
        public virtual LuceneClientTreatment LuceneClientTreatment
        {
            get { return luceneClientTreatment ?? (luceneClientTreatment = new LuceneClientTreatment("")); }
            set
            {
                luceneClientTreatment = value;
            }
        }
        public virtual IList<ITreatmentDTO> GetTreatments(IPatientDTO patient)
        {
            var medicalRecord = new List<string>();

            medicalRecord.AddRange(patient.Records);
            medicalRecord.Add(patient.Id);

            return LuceneClientTreatment.AdvancedSearch(medicalRecord).ToList();
        }

        public virtual void SaveTreatment (List<ITreatmentDTO> treatments)
        {
            LuceneClientTreatment.AddUpdateLuceneIndex(treatments);
        }
    }
}
