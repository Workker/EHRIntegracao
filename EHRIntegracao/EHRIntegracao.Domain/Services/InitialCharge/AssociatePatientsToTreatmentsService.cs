using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Repository;

using EHRIntegracao.Domain.Services.Integration;
using EHRLucene.Domain;

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

        private IList<ITreatmentDTO> treatments;
        public IList<ITreatmentDTO> Treatments
        {
            get { return treatments ?? (treatments = new List<ITreatmentDTO>()); }
            set
            {
                treatments = value;
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

        public void Associate(List<IPatientDTO> patients)
        {
            //foreach (var patient in patients)
            //{
            //    Treatments = GetTreatmentsLuceneService.GetTreatments(patient);
            //    patient.AddTreatments(Treatments.ToList());
            //}
        }
    }


}
