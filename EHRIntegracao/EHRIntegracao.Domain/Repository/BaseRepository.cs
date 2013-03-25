﻿using System;
using EHRIntegracao.Domain.Factorys;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Common;
using EHRIntegracao.Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace EHRIntegracao.Domain.Repository
{
    public abstract class BaseRepository
    {
        public const string NHibernateSessionKey = "nhibernate.session.key";
        public static ISessionFactory Factory = CreateSessionFactory();

        private static ISession _session;
        private static readonly object SyncObj = 1;

        public static ISession Session
        {
            get { return _session ?? (_session = GetCurrentSession()); }
            set { _session = value; }
        }

        #region Métodos Genericos para acesso ao BD

        public BaseRepository() { }

        public BaseRepository(ISession session)
        {
            Session = session;
        }

        public BaseRepository(ISessionFactory sessionFactory)
        {
            Factory = sessionFactory;
        }

        public void AlterFactory(DbEnum db)
        {
            Factory = FactorryNhibernate.GetSession(db);
            _session = null;
        }

        public void Dispose() 
        {
            _session.Disconnect();
            _session.Dispose();
            _session = null;
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

        public virtual IList<T> All<T>()
        {
            return Session.CreateCriteria(typeof(T)).List<T>();
        }

        public virtual T Get<T>(int id)
        {
            return Session.Get<T>(id);
        }

        public virtual void SalvarLista(List<IAggregateRoot<int>> roots)
        {
            var transaction = Session.BeginTransaction();

            try
            {
                foreach (var root in roots)
                {
                    Session.SaveOrUpdate(root);
                }
                transaction.Commit();
            }
            catch (System.Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
        }

        #endregion

        #region Métodos de Sessão e Transação

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


        public static ISessionFactory CreateSessionFactory()
        {
            if (Factory == null)
                return FactorryNhibernate.GetSession(DbEnum.sumario);
            else
                return Factory;
               
        }

        #endregion
    }
}
