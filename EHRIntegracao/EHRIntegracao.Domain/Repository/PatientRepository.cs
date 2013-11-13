using EHR.CoreShared.Entities;
using EHR.CoreShared.Interfaces;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EHRIntegracao.Domain.Repository
{

    public class PatientRepository : IntegrationRepository
    {
        public PatientRepository()
        {

        }

        public PatientRepository(ISession session)
            : base(session)
        {

        }

        public PatientRepository(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {

        }

        public virtual IList<Patient> GetAll()
        {
            return base.All<Patient>();
        }

        public IList<Domain.Patient> GetPatientsBy(IPatient patient)
        {
            var patientCriteria = Session.CreateCriteria<Patient>("p");

            FactoryPatientSpecification.CreateCriteria(patient, patientCriteria);

            return patientCriteria.List<Domain.Patient>().ToList();
        }

        public IList<EHRIntegracao.Domain.Domain.Patient> GetPatientsWithPeriod()
        {
            return Session.CreateQuery(
              "select p from Patient p, Treatment t where p.Id = t.Id and t.EntryDate  >= :data ")
              .SetParameter("data", DateTime.Now.AddMonths(-3).AddDays(-2))
              .List<EHRIntegracao.Domain.Domain.Patient>();
        }


        public virtual void SalvarLista(IList<EHRIntegracao.Domain.Domain.Patient> roots)
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
