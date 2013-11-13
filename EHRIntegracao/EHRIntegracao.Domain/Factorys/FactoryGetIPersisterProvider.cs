using FluentNHibernate.Cfg.Db;

namespace EHRIntegracao.Domain.Factorys
{
    public class FactoryIPersisterProvider
    {
        public static IPersistenceConfigurer GetPersistence(string key)
        {
            switch (key)
            {
                case "QuintaDor":
                    return OracleClientConfiguration.Oracle10.ShowSql().ConnectionString(c => c
                    .FromAppSetting(key)
                    );

                case "Sumario":
                    return MsSqlConfiguration.MsSql2008.ConnectionString(c => c
                .FromAppSetting(key)
                );
                default:
                    return OracleClientConfiguration.Oracle10.ShowSql().ConnectionString(c => c
             .FromAppSetting(key)
             );

            }
        }
    }
}
