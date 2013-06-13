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
        public int fatia = 300;
        public int Totalrecords;
        public int TotalDePacientesEmProcessamento = 0;
        public int totalRecordsProcess = 0;

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
                Totalrecords = records.Count;
                var treatments = new List<ITreatmentDTO>();
                while (totalRecordsProcess < Totalrecords)
                {

                    var recordsFatia = records.Skip(totalRecordsProcess).Take(fatia).ToList();
                    var treatmentsFatia = LuceneClientTreatment.AdvancedSearch(recordsFatia).ToList();
                    treatments.AddRange(treatmentsFatia);
                    Fatiar();
                }

                return treatments;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void Fatiar()
        {
            int totalOffRecords = Totalrecords - totalRecordsProcess;

            if (totalOffRecords < fatia)
                totalRecordsProcess += totalOffRecords;
            else
                totalRecordsProcess += fatia;

        }

        public virtual IList<ITreatmentDTO> GetTreatmentsPeriodic(List<ITreatmentDTO> treatmentDtos)
        {
            try
            {
                Totalrecords = treatmentDtos.Count;
                var treatments = new List<ITreatmentDTO>();
                while (totalRecordsProcess < Totalrecords)
                {
                    var treatmentDtosFatia = treatmentDtos.Skip(totalRecordsProcess).Take(fatia).ToList();
                    var treatmentsFatia = LuceneClientTreatment.AdvancedPeriodicSearch(treatmentDtosFatia).ToList();

                    treatments.AddRange(treatmentsFatia);

                    Fatiar();
                }

                if (treatmentDtos.Count == 0)
                    return new List<ITreatmentDTO>();

                 return treatments;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public virtual void SaveTreatment(List<ITreatmentDTO> treatments)
        {
            LuceneClientTreatment.AddUpdateLuceneIndex(treatments);
        }
    }
}
