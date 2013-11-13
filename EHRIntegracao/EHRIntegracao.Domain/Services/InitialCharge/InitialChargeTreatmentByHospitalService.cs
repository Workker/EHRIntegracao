using EHR.CoreShared;
using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Services.GetEntities;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Services.InitialCharge
{
    public class InitialChargeTreatmentByHospitalService
    {
        private GetValuesDbEnumService getValuesDbEnumService;
        public virtual GetValuesDbEnumService GetValuesDbEnumService
        {
            get { return getValuesDbEnumService ?? (getValuesDbEnumService = new GetValuesDbEnumService()); }
            set
            {
                getValuesDbEnumService = value;
            }
        }

        private GetTreatmentService getTreatmentService { get; set; }
        public virtual GetTreatmentService GetTreatmentService
        {
            get { return getTreatmentService ?? (getTreatmentService = new GetTreatmentService()); }
            set
            {
                getTreatmentService = value;
            }
        }

        private List<ITreatment> treatments;
        public virtual List<ITreatment> Treatments
        {
            get { return treatments ?? (treatments = new List<ITreatment>()); }
            set
            {
                treatments = value;
            }
        }

        private List<ITreatment> treatmentsLucene;
        public virtual List<ITreatment> TreatmentsLucene
        {
            get { return treatmentsLucene ?? (treatmentsLucene = new List<ITreatment>()); }
            set
            {
                treatmentsLucene = value;
            }
        }

        private TreatmentsLuceneService treatmentsLuceneService;
        public virtual TreatmentsLuceneService TreatmentsLuceneService
        {
            get { return treatmentsLuceneService ?? (treatmentsLuceneService = new TreatmentsLuceneService()); }
            set
            {
                treatmentsLuceneService = value;
            }
        }

        public virtual void DoSearch()
        {
            var dbs = GetValues();
            //foreach (var db in dbs.Where(d => d != DbEnum.RiosDor))
            //{
            //    DoSearchTreatments(db);
            //} todo: alterar
            SaveTreatments();
        }

        public virtual void DoSearchPeriodic()
        {
            var dbs = GetValues();
            foreach (var db in dbs)
            {
                DoSearchTreatmentsPeriodic(db);
            }

            RemoveTreatments();
            SaveTreatments();
        }

        private void RemoveTreatments()
        {
            TreatmentsLucene = TreatmentsLuceneService.GetTreatmentsPeriodic(Treatments).ToList();

            Treatments = Treatments.Where(NotExist).ToList();
        }

        private void DoSearchTreatments(Hospital hospital)
        {
            var treatment = GetTreatmentService.GetTreatments(hospital);
            Treatments.AddRange(treatment);
        }

        private void DoSearchTreatmentsPeriodic(Hospital hospital)
        {
            var treatment = GetTreatmentService.GetPeriodicTreatments(hospital);
            Treatments.AddRange(treatment);
        }

        private IList<Hospital> GetValues()
        {
            return GetValuesDbEnumService.GetValues();
        }

        private void SaveTreatments()
        {
            TreatmentsLuceneService.SaveTreatment(Treatments);
        }

        public bool NotExist(ITreatment treatment)
        {
            return !TreatmentsLucene.Any(
                t =>
                t.CheckOutDate == treatment.CheckOutDate && t.EntryDate == treatment.EntryDate &&
                t.Hospital == treatment.Hospital);
        }
    }
}
