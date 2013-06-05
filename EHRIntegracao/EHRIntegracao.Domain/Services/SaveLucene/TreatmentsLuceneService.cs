using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRLucene.Domain;

namespace EHRIntegracao.Domain.Services
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
        public virtual IList<ITreatmentDTO> GetTreatments(List<RecordDTO> records)
        {
            try
            {
                return LuceneClientTreatment.AdvancedSearch(records).ToList();
            }
            catch (Exception ex)
            {
                    
                throw ex;
            }
           
        }
        public virtual void SaveTreatment (List<ITreatmentDTO> treatments)
        {
            LuceneClientTreatment.AddUpdateLuceneIndex(treatments);
        }
    }
}
