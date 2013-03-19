using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;

namespace EHRIntegracao.Test.Mocks
{
    public class Criterion : ICriteria
    {
        public IList<ICriterion> criterions { get; set; }

        public ICriteria Add(NHibernate.Criterion.ICriterion expression)
        {
            AddCriterion(expression);

            return this;
        }

        private void AddCriterion(ICriterion expression)
        {
            if (this.criterions == null)
                criterions = new List<ICriterion>();

            this.criterions.Add(expression);
        }

        public ICriteria AddOrder(NHibernate.Criterion.Order order)
        {
            throw new NotImplementedException();
        }

        public string Alias
        {
            get { throw new NotImplementedException(); }
        }

        public void ClearOrders()
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateAlias(string associationPath, string alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateAlias(string associationPath, string alias, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateAlias(string associationPath, string alias)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria(string associationPath, string alias, NHibernate.SqlCommand.JoinType joinType, NHibernate.Criterion.ICriterion withClause)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria(string associationPath, string alias, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria(string associationPath, string alias)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria(string associationPath, NHibernate.SqlCommand.JoinType joinType)
        {
            throw new NotImplementedException();
        }

        public ICriteria CreateCriteria(string associationPath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Future<T>()
        {
            throw new NotImplementedException();
        }

        public IFutureValue<T> FutureValue<T>()
        {
            throw new NotImplementedException();
        }

        public ICriteria GetCriteriaByAlias(string alias)
        {
            throw new NotImplementedException();
        }

        public ICriteria GetCriteriaByPath(string path)
        {
            throw new NotImplementedException();
        }

        public Type GetRootEntityTypeIfAvailable()
        {
            throw new NotImplementedException();
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnlyInitialized
        {
            get { throw new NotImplementedException(); }
        }

        public IList<T> List<T>()
        {
            throw new NotImplementedException();
        }

        public void List(System.Collections.IList results)
        {
            throw new NotImplementedException();
        }

        public System.Collections.IList List()
        {
            throw new NotImplementedException();
        }

        public ICriteria SetCacheMode(CacheMode cacheMode)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetCacheRegion(string cacheRegion)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetCacheable(bool cacheable)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetComment(string comment)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetFetchMode(string associationPath, FetchMode mode)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetFetchSize(int fetchSize)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetFirstResult(int firstResult)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetFlushMode(FlushMode flushMode)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetLockMode(string alias, LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetLockMode(LockMode lockMode)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetMaxResults(int maxResults)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetProjection(params NHibernate.Criterion.IProjection[] projection)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetReadOnly(bool readOnly)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetResultTransformer(NHibernate.Transform.IResultTransformer resultTransformer)
        {
            throw new NotImplementedException();
        }

        public ICriteria SetTimeout(int timeout)
        {
            throw new NotImplementedException();
        }

        public T UniqueResult<T>()
        {
            throw new NotImplementedException();
        }

        public object UniqueResult()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
