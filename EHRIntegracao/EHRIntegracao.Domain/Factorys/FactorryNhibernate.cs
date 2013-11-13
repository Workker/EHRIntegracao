using EHR.CoreShared.Entities;
using EHRIntegracao.Domain.Mapping;
using FluentNHibernate.Cfg;
using NHibernate;

namespace EHRIntegracao.Domain.Factorys
{
    public class FactorryNhibernate
    {
        public static ISessionFactory GetSession(Hospital hospital)
        {
            return
                 Fluently.Configure()
            .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
            .Database(FactoryIPersisterProvider.GetPersistence(hospital.Key)).Mappings(m => m.FluentMappings.AddFromAssemblyOf<PatientMap>()).BuildSessionFactory();
        }

    }
}
