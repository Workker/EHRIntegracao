using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace EHRIntegracao.Test.InfraStructure
{
    [TestFixture]
    [Ignore]
    public class CreateDataBaseTest
    {
        
        [Test]
        public void CreateDataBaseQuintaDOrWorkkerTest()
        {
            try
            {
                CreateDataBase("QuintaDorWorkker");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [Test]
        public void CreateDataBaseQuintaDOrTest()
        {
            try
            {
                CreateDataBase("QuintaDor");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Test]
        public void CreateDataBaseCopaDOrTest()
        {
            try
            {
                CreateDataBase("CopaDor");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateDataBase(string conexao) 
        {
            Fluently.Configure().Database(MsSqlConfiguration.MsSql2005.ConnectionString(c => c
           .FromAppSetting(conexao)
            ).ShowSql()).Mappings(m => m.FluentMappings.AddFromAssemblyOf<PatientMap>()).Mappings(m => m.MergeMappings())
            .ExposeConfiguration(BuildSchema).BuildSessionFactory();
        }

        private void BuildSchema(NHibernate.Cfg.Configuration config)
        {
            new SchemaExport(config)
                 .Drop(true, true);

            new SchemaExport(config)
                .Create(true, true);
        }
    }
}
