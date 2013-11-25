using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EHR.CoreShared;
using EHR.CoreShared.Entities;
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
            var repositoryH = new Hospitals();
            var hospital = repositoryH.GetBy("QuintaDor");
            PatientDTORepository pacientes = new PatientDTORepository(FactorryNhibernate.GetSession(hospital.Database));

            var resultados = pacientes.All<Patient>();

            Assert.NotNull(resultados);

        }

        [Test]
        [Ignore]
        public void AllPatientWithPeriod()
        {
            var repositoryH = new Hospitals();
            var hospital = repositoryH.GetBy("QuintaDor");
            PatientDTORepository pacientes = new PatientDTORepository(FactorryNhibernate.GetSession(hospital.Database));

            var resultados = pacientes.GetPatientsWithPeriod();

            Assert.NotNull(resultados);

        }

        [Test]
        public void AllPatientByCriterion()
        {
            var repositoryH = new Hospitals();
            var hospital = repositoryH.GetBy("QuintaDor");
            PatientDTORepository pacientes = new PatientDTORepository(FactorryNhibernate.GetSession(hospital.Database));

            var resultados = pacientes.GetPatientsBy(new Patient() { Identity = "198000" });

            Assert.AreEqual(resultados.Count ,1);

        }
    }
}
