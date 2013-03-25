using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Domain.PatientSpecificationCriteria;
using EHRIntegracao.Domain.Services.DTO;
using NHibernate;

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
