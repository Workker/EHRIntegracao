using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace EHRIntegracao.Domain.Factorys
{
    public class FactorryNhibernate
    {
        public static ISessionFactory GetSession(DbEnum conexao)
        {

            return
                 Fluently.Configure()
            .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
            .Database(FactoryIPersisterProvider.GetPersistence(conexao)).Mappings(m => m.FluentMappings.AddFromAssemblyOf<PatientMap>()).BuildSessionFactory();
        }

    }
}
