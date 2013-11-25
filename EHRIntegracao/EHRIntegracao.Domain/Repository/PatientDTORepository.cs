using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Repository
{

    public class PatientDTORepository : IntegrationRepository
    {
        public PatientDTORepository()
        {

        }

        public PatientDTORepository(ISession session)
            : base(session)
        {

        }

        public PatientDTORepository(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {

        }

        public virtual IList<PatientDTO> GetAll()
        {
            return base.All<PatientDTO>();
        }

        public IList<PatientDTO> GetPatientsBy(IPatient patient)
        {
            var patientCriteria = Session.CreateCriteria<PatientDTO>("p");

            FactoryPatientSpecification.CreateCriteria(patient, patientCriteria);

            return patientCriteria.List<PatientDTO>().ToList();
        }

        public IList<PatientDTO> GetPatientsWithPeriod()
        {
            return Session.CreateQuery(
              "select p from Patient p, Treatment t where p.Id = t.Id and t.EntryDate  >= :data ")
              .SetParameter("data", DateTime.Now.AddMonths(-3).AddDays(-2))
              .List<EHRIntegracao.Domain.Domain.PatientDTO>();
        }


        public virtual void SalvarLista(IList<PatientDTO> roots)
        {
            //var transaction = Session.BeginTransaction();

            try
            {
                foreach (var root in roots)
                {
                    Save<string>(root);
                }
                //  transaction.Commit();
            }
            catch (System.Exception ex)
            {
                //    transaction.Rollback();
                throw ex;
            }
        }
    }
}
