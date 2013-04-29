using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.DTO;

namespace EHRIntegracao.Domain.Services.Integration
{
    public class GetTreatmentService
    {
        private IList<ITreatmentDTO> treatments;
        public IList<ITreatmentDTO> Treatments
        {
            get { return treatments ?? (treatments = new List<ITreatmentDTO>()); }
            set
            {
                treatments = value;
            }
        }


        private TreatmentRepository treatmentRepository;
        public TreatmentRepository TreatmentRepository
        {
            get { return treatmentRepository ?? (treatmentRepository = new TreatmentRepository()); }
            set
            {
                treatmentRepository = value;
            }
        }

        public IList<ITreatmentDTO> GetTreatments(DbEnum db)
        {
            ClearPatient();

            TreatmentRepository = new TreatmentRepository(FactorryNhibernate.GetSession(db));

            var treatment = TreatmentRepository.GetAll();
            PatientConverter(treatment);

            return Treatments;
        }

        private void ClearPatient()
        {
            Treatments = null;
        }

        private void PatientConverter(IList<Treatment> treatment)
        {
            foreach (var t in treatment)
            {
                var tratmentDto = new TreatmentDTO()
                {
                    Id = t.Id,
                    CheckOutDate = t.CheckOutDate,
                    EntryDate = t.EntryDate
                };

                Treatments.Add(tratmentDto);
            }
        }
    }
}
