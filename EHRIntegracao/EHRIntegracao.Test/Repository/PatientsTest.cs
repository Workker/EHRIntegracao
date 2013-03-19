using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHRIntegracao.Domain.Domain;
using EHRIntegracao.Domain.Factorys;
using EHRIntegracao.Domain.Repository;
using EHRIntegracao.Domain.Services.DTO;
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
        public void AllPatientByCriterion()
        {
            PatientRepository pacientes = new PatientRepository(FactorryNhibernate.GetSession(DbEnum.QuintaDor));

            var resultados = pacientes.GetPatientsBy(new PatientDTO() { Identity = "198000" });

            Assert.AreEqual(resultados.Count ,1);

        }
    }
}
