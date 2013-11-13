using EHR.CoreShared.Interfaces;
using NHibernate;
using System.Collections.Generic;

namespace EHRIntegracao.Domain.Repository
{
    public abstract class BaseRepository
    {
        #region Properties

        public const string NHibernateSessionKey = "nhibernate.session.key";
        public static ISessionFactory Factory;
        protected static ISession _session;
        protected static readonly object SyncObj = 1;
        public static ISession Session
        {
            get { return _session ?? (_session = GetCurrentSession()); }
            set { _session = value; }
        }

        #endregion

        #region Constructors

        public BaseRepository() { }

        public BaseRepository(ISession session)
        {
            Session = session;
        }

        public BaseRepository(ISessionFactory sessionFactory)
        {
            if (Factory != null)
                Factory.Dispose();

            Factory = sessionFactory;
            _session = Factory.OpenSession();
        }

        #endregion

        #region Methods Generics to acess Database

        public virtual IList<T> All<T>()
        {
            return Session.CreateCriteria(typeof(T)).List<T>();
        }

        public virtual void Save<T>(IAggregateRoot<T> root)
        {
            var transaction = Session.BeginTransaction();
            Session.SaveOrUpdate(root);
            transaction.Commit();
        }

        public virtual void Delete<T>(IAggregateRoot<T> root)
        {
            var transaction = Session.BeginTransaction();
            Session.Delete(root);
            transaction.Commit();
        }

        #endregion

        #region Methods of Session and Transaction

        public static void CloseTransaction(ITransaction transaction)
        {
            transaction.Dispose();
        }

        public static ISession GetCurrentSession()
        {
            ISession currentSession;
            lock (SyncObj)
                currentSession = Factory.OpenSession();
            return currentSession;


        }

        public abstract ISessionFactory CreateSessionFactory();

        #endregion
    }
}
