using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.InitialCharge
{
    public class AssociatePatientsToTreatmentsService
    {
        private TreatmentsLuceneService getTreatmentsLuceneService;
        public TreatmentsLuceneService GetTreatmentsLuceneService
        {
            get { return getTreatmentsLuceneService ?? (getTreatmentsLuceneService = new TreatmentsLuceneService()); }
            set
            {
                getTreatmentsLuceneService = value;
            }
        }

        private TreatmensDbFor treatmensDbFor;
        public TreatmensDbFor TreatmensDbFor
        {
            get { return treatmensDbFor ?? (treatmensDbFor = new TreatmensDbFor()); }
            set
            {
                treatmensDbFor = value;
            }
        }

        public void Associate(List<IPatient> patients)
        {
            try
            {
                foreach (var patient in patients)
                {
                    var treatments = new List<ITreatment>();

                    foreach (var recordsBysHospital in patient.Records.GroupBy(r => r.Hospital).GroupBy(b => b.Key))
                    {
                        var treatmentsCheck = new List<ITreatment>();

                        foreach (var record in recordsBysHospital.ToList())
                        {
                            treatments.AddRange(GetTreatmentsLuceneService.GetTreatments(record.ToList()));
                        }

                        patient.AddTreatments(treatments.ToList());
                    }

                    patient.SetLastTreatment();
                }
                Console.WriteLine("Lote");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }


}
