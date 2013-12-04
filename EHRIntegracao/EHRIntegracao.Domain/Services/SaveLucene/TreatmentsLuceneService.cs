using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using EHRLucene.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services
{
    public class TreatmentsLuceneService
    {
        #region Properties

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

        #endregion

        #region Methods

        public virtual IList<ITreatment> GetTreatments(List<Record> records)
        {
            try
            {
                Totalrecords = records.Count;
                var treatments = new List<ITreatment>();
                while (totalRecordsProcess < Totalrecords)
                {
                    var recordsFatia = records.Skip(totalRecordsProcess).Take(fatia).ToList();
                    var treatmentsFatia = LuceneClientTreatment.SearchBy(recordsFatia).ToList();

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

        public virtual IList<ITreatment> GetTreatmentsPeriodic(List<ITreatment> treatmentDtos)
        {
            try
            {
                Totalrecords = treatmentDtos.Count;
                var treatments = new List<ITreatment>();
                while (totalRecordsProcess < Totalrecords)
                {
                    var treatmentDtosFatia = treatmentDtos.Skip(totalRecordsProcess).Take(fatia).ToList();
                    var treatmentsFatia = LuceneClientTreatment.AdvancedPeriodicSearch(treatmentDtosFatia).ToList();

                    treatments.AddRange(treatmentsFatia);

                    Fatiar();
                }

                if (treatmentDtos.Count == 0)
                    return new List<ITreatment>();

                return treatments;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public virtual void SaveTreatment(List<ITreatment> treatments)
        {
            LuceneClientTreatment.AddUpdateLuceneIndex(treatments);
        }

        private void Fatiar()
        {
            int totalOffRecords = Totalrecords - totalRecordsProcess;

            if (totalOffRecords < fatia)
                totalRecordsProcess += totalOffRecords;
            else
                totalRecordsProcess += fatia;

        }

        #endregion
    }
}
