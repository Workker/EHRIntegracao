using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using NHibernate;

namespace EHRIntegracao.Domain.Repository
{
    public class TreatmentRepository : BaseRepository
    {
        public TreatmentRepository() 
        {

        }

        public TreatmentRepository(ISession session)
            : base(session)
        {
 
        }

        public TreatmentRepository(ISessionFactory sessionFactory)
            : base(sessionFactory)
        {

        }

        public virtual IList<Treatment> GetAll() 
        {
            return base.All<Treatment>();
        }      
    }
}
