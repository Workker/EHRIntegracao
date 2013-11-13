using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using System.Collections.Generic;


namespace EHRIntegracao.Domain.Services.GetEntities
{
    public class GetTreatmentService
    {
        private IList<ITreatment> treatments;
        public virtual IList<ITreatment> Treatments
        {
            get { return treatments ?? (treatments = new List<ITreatment>()); }
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

        public virtual IList<ITreatment> GetTreatments(Hospital hospital)
        {
            ClearPatient();

            TreatmentRepository = new TreatmentRepository(FactorryNhibernate.GetSession(hospital));

            var treatment = TreatmentRepository.GetAll();
            TreatmentConverter(treatment, hospital);

            return Treatments;
        }

        public virtual IList<ITreatment> GetPeriodicTreatments(Hospital hospital)
        {
            ClearPatient();

            TreatmentRepository = new TreatmentRepository(FactorryNhibernate.GetSession(hospital));

            var treatment = TreatmentRepository.GetPeriodicTreatment();
            TreatmentConverter(treatment, hospital);

            return Treatments;
        }

        private void ClearPatient()
        {
            Treatments = null;
        }

        private void TreatmentConverter(IList<EHRIntegracao.Domain.Domain.Treatment> treatment, Hospital hospital)
        {
            foreach (var t in treatment)
            {
                if (t == null)
                    continue;
                var tratmentDto = new Treatment()
                {
                    Id = t.Id,
                    CheckOutDate = t.CheckOutDate,
                    EntryDate = t.EntryDate,
                    Hospital = hospital
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
