using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using FluentNHibernate.Cfg.Db;

namespace EHRIntegracao.Domain.Factorys
{
    public class FactoryIPersisterProvider
    {
        public static IPersistenceConfigurer GetPersistence(DbEnum conexaoEnum)
        {
            switch (conexaoEnum)
            {
                case DbEnum.BarraDor:
                    return OracleClientConfiguration.Oracle10.ShowSql().ConnectionString(c => c
                  .FromAppSetting(FacotoryAppValues.GetValue(conexaoEnum))
                  );

                case DbEnum.QuintaDor:
                    return OracleClientConfiguration.Oracle10.ShowSql().ConnectionString(c => c
                    .FromAppSetting(FacotoryAppValues.GetValue(conexaoEnum))
                    );

                case DbEnum.sumario:
                    return MsSqlConfiguration.MsSql2008.ConnectionString(c => c
                .FromAppSetting(FacotoryAppValues.GetValue(conexaoEnum))
                );
                case DbEnum.QuintaDorProd:
                    return OracleClientConfiguration.Oracle10.ShowSql().ConnectionString(c => c
                   .FromAppSetting(FacotoryAppValues.GetValue(conexaoEnum))
                   );
                default:
                    return MsSqlConfiguration.MsSql2008.ShowSql().ConnectionString(c => c
             .FromAppSetting(FacotoryAppValues.GetValue(conexaoEnum))
             );

            }
        }
    }
}
