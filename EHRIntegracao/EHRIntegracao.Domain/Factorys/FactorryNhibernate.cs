using EHR.CoreShared.Entities;
using EHRIntegracao.Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace EHRIntegracao.Domain.Factorys
{
    public class FactorryNhibernate
    {
        public static ISessionFactory GetSession(Database database)
        {
            return
                 Fluently.Configure()
            .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
            .Database(OracleClientConfiguration.Oracle10
            .ConnectionString(string.Concat("Data Source=", database.Host, "/", database.Service, "; User ID=", database.User, ";Password=", database.Password)))
            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PatientDTOMap>()).BuildSessionFactory();
        }
    }
}