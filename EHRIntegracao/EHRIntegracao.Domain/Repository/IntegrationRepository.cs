using EHR.CoreShared.Entities;
using EHRIntegracao.Domain.Factorys;
using NHibernate;
using System;
using System.Configuration;

namespace EHRIntegracao.Domain.Repository
{
    public abstract class IntegrationRepository : BaseRepository, IDisposable
    {
        #region Constructors

        public IntegrationRepository()
        {
            Factory = CreateSessionFactory();
        }

        public IntegrationRepository(ISession session)
        {
            Session = session;
        }

        public IntegrationRepository(ISessionFactory sessionFactory)
        {
            if (Factory != null)
                Factory.Dispose();

            Factory = sessionFactory;
            _session = Factory.OpenSession();
        }

        #endregion

        #region Methods Generics to acess Database

        #endregion

        #region Methods of Session and Transaction

        public override sealed ISessionFactory CreateSessionFactory()
        {
            if (Factory == null && NotConsole())
            {
                var hospitals = new Hospitals();
                var hospital = hospitals.GetBy("Sumario");

                return FactorryNhibernate.GetSession(hospital);
            }
            return Factory;
        }

        public void AlterFactory(Hospital hospital)
        {
            Factory = FactorryNhibernate.GetSession(hospital);
            _session = null;
        }

        private static bool NotConsole()
        {
            return ConfigurationManager.AppSettings["Ambiente"] != "Console";
        }

        public void Dispose()
        {
            _session.Disconnect();
            _session.Dispose();
            _session = null;
        }

        #endregion
    }
}
