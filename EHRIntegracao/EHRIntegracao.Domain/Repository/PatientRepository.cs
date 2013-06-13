using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria;

using NHibernate;
using NHibernate.Transform;

namespace EHRIntegracao.Domain.Repository
{

    public class PatientRepository : BaseRepository
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

        public IList<Patient> GetPatientsBy(IPatientDTO patientDTO)
        {
            var patientCriteria = Session.CreateCriteria<Patient>("p");

            FactoryPatientSpecification.CreateCriteria(patientDTO, patientCriteria);

            return patientCriteria.List<Patient>().ToList();
        }

        public IList<Patient> GetPatientsWithPeriod()
        {
            return Session.CreateQuery(
              "select p from Patient p, Treatment t where p.Id = t.Id and t.EntryDate  >= :data ")
              .SetParameter("data", DateTime.Now.AddMonths(-3).AddDays(-2))
              .List<Patient>();
        }


        public virtual void SalvarLista(IList<Patient> roots)
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
