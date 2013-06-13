using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.GetEntities;
using Workker.Framework.Domain;

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

        private List<ITreatmentDTO> treatments;
        public virtual List<ITreatmentDTO> Treatments
        {
            get { return treatments ?? (treatments = new List<ITreatmentDTO>()); }
            set
            {
                treatments = value;
            }
        }

        private List<ITreatmentDTO> treatmentsLucene;
        public virtual List<ITreatmentDTO> TreatmentsLucene
        {
            get { return treatmentsLucene ?? (treatmentsLucene = new List<ITreatmentDTO>()); }
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
            foreach (var db in dbs.Where(d=> d != DbEnum.Rios))
            {
                if (db == DbEnum.sumario)
                    continue;

                DoSearchTreatments(db);
            }
            SaveTreatments();
        }

        public virtual void DoSearchPeriodic()
        {
            var dbs = GetValues();
            foreach (var db in dbs)
            {
                if (db == DbEnum.sumario)
                    continue;

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

        private void DoSearchTreatments(DbEnum db)
        {
            var treatment = GetTreatmentService.GetTreatments(db);
            Treatments.AddRange(treatment);
        }

        private void DoSearchTreatmentsPeriodic(DbEnum db)
        {
            var treatment = GetTreatmentService.GetPeriodicTreatments(db);
            Treatments.AddRange(treatment);
        }

        private List<DbEnum> GetValues()
        {
            return GetValuesDbEnumService.GetValues();
        }

        private void SaveTreatments()
        {
            TreatmentsLuceneService.SaveTreatment(Treatments);
        }

        public bool NotExist(ITreatmentDTO treatment)
        {
            return !TreatmentsLucene.Any(
                t =>
                t.CheckOutDate == treatment.CheckOutDate && t.EntryDate == treatment.EntryDate &&
                t.Hospital == treatment.Hospital);
        }
    }
}
