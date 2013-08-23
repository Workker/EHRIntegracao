using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;

using NUnit.Framework;

namespace EHRIntegracao.Test.Repository
{
    [TestFixture]
    [Ignore]
    public class PatientsTest
    {
        [Test]
        [Ignore]
        //Teste de massa grande não executar
        public void AllPatient()
        {
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));

            var resultados = pacientes.All<Patient>();

            Assert.NotNull(resultados);

        }

        [Test]
        [Ignore]
        public void AllPatientWithPeriod()
        {
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.CopaDor));

            var resultados = pacientes.GetPatientsWithPeriod();

            Assert.NotNull(resultados);

        }

        [Test]
        public void AllPatientByCriterion()
        {
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));

            var resultados = pacientes.GetPatientsBy(new Patient() { Identity = "198000" });

            Assert.AreEqual(resultados.Count ,1);

        }
    }
}
