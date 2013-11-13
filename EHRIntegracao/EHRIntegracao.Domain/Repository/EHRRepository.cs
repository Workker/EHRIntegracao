using EHRIntegracao.Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;

namespace EHRIntegracao.Domain.Repository
{
    public abstract class EHRRepository : BaseRepository
    {
        #region Constructors

        protected EHRRepository()
        {
            Factory = CreateSessionFactory();
        }

        protected EHRRepository(ISession session)
        {
            Session = session;
        }

        #endregion

        #region Methods Generics to acess Database

        #endregion

        #region Methods of Session and Transaction

        public override sealed ISessionFactory CreateSessionFactory()
        {
            if (ConfigurationManager.AppSettings["Environment"].Equals("Deploy"))
            {
                return Fluently.Configure().Database(OracleClientConfiguration.Oracle10.ConnectionString(c => c
                  .FromAppSetting("connection"))).Mappings(m => m.FluentMappings.AddFromAssemblyOf<HospitalMap>()).BuildSessionFactory();
            }
            if (ConfigurationManager.AppSettings["Environment"].Equals("Development"))
            {
                return Fluently.Configure().Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c
                    .FromAppSetting("connection"))).Mappings(m => m.FluentMappings.AddFromAssemblyOf<HospitalMap>()).BuildSessionFactory();
            }
            return null;
        }

        #endregion
    }
}
