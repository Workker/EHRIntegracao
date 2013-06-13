using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;


namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetTreatmentService
    {
        private IList<ITreatmentDTO> treatments;
        public virtual IList<ITreatmentDTO> Treatments
        {
            get { return treatments ?? (treatments = new List<ITreatmentDTO>()); }
            set
            {
                treatments = value;
            }
        }


        private TreatmentRepository treatmentRepository;
        public virtual TreatmentRepository TreatmentRepository
        {
            get { return treatmentRepository ?? (treatmentRepository = new TreatmentRepository()); }
            set
            {
                treatmentRepository = value;
            }
        }

        public virtual IList<ITreatmentDTO> GetTreatments(DbEnum db)
        {
            ClearPatient();

            TreatmentRepository = new TreatmentRepository(FactorryNhibernate.GetSession(db));

            var treatment = TreatmentRepository.GetAll();
            TreatmentConverter(treatment, db);

            return Treatments;
        }

        public virtual IList<ITreatmentDTO> GetPeriodicTreatments(DbEnum db)
        {
            ClearPatient();

            TreatmentRepository = new TreatmentRepository(FactorryNhibernate.GetSession(db));

            var treatment = TreatmentRepository.GetPeriodicTreatment();
            TreatmentConverter(treatment, db);

            return Treatments;
        }

        private void ClearPatient()
        {
            Treatments = null;
        }

        private void TreatmentConverter(IList<Treatment> treatment,DbEnum db)
        {
            foreach (var t in treatment)
            {
                if(t == null)
                    continue;
                var tratmentDto = new TreatmentDTO()
                {
                    Id = t.Id,
                    CheckOutDate = t.CheckOutDate,
                    EntryDate = t.EntryDate,
                    Hospital = db
                };

                Treatments.Add(tratmentDto);
            }
        }

        //private void TreatmentConverter(IList<TreatmentResultSet> treatment, DbEnum db)
        //{
        //    foreach (var t in treatment)
        //    {
        //        if (t == null)
        //            continue;
        //        var tratmentDto = new TreatmentDTO()
        //        {
        //            Id = t.Id,
        //            CheckOutDate = t.CheckOutDate,
        //            EntryDate = t.EntryDate,
        //            Hospital = db
        //        };

        //        Treatments.Add(tratmentDto);
        //    }
        //}
    }
}
