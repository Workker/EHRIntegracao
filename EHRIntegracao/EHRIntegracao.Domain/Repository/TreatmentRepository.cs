using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using NHibernate;
using NHibernate.Transform;
using NHibernate.Criterion;

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

        public virtual IList<Treatment> GetPeriodicTreatment()
        {

            //var treatment = Session.CreateCriteria<Treatment>("t");
            //treatment.Add(Restrictions.Gt("t.EntryDate", DateTime.Now.AddMonths(-1).AddDays(-2)));
            //return treatment.List<Treatment>();

            return Session.CreateQuery(
                "select t from Treatment t where t.EntryDate  >= :data ")
                .SetParameter("data", DateTime.Now.AddMonths(-3).AddDays(-2))
                .List<Treatment>();

            //return Session.CreateQuery(
            //    "select t from Patient p, Treatment t where p.Id = t.Id and t.EntryDate  >= :data ")
            //    .SetParameter("data", DateTime.Now.AddMonths(-1).AddDays(-2))
            //    .List<Treatment>();
        }
    }

    
}
